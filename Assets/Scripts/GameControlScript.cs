using UnityEngine;
using System.Collections;

public class GameControlScript : MonoBehaviour {

	enum Mask{Red, Blue, Green, Orange, Init};

	Mask mask = Mask.Init;
	ArrayList blocks = new ArrayList();
	ArrayList enemies = new ArrayList();
	public GameObject playerMask;
	public FaderScript fadeScript;
	public MusicPlayerScript music;

	void Awake()
	{
		//DontDestroyOnLoad (this.gameObject);
	}

	// Use this for initialization
	void Start () {
		ChangeMaskInitial (Mask.Red);
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Alpha1))
			ChangeMask(Mask.Red);
		else if(Input.GetKeyDown(KeyCode.Alpha2))
			ChangeMask(Mask.Blue);
		else if(Input.GetKeyDown(KeyCode.Alpha3))
			ChangeMask(Mask.Green);
		else if(Input.GetKeyDown(KeyCode.Alpha4))
			ChangeMask(Mask.Orange);

	}

	void ChangeMask(Mask newMask)
	{
		StartCoroutine(fadeScript.ChangeMask());
		ManageBlocks(newMask);
		ManageEnemies(newMask);

		mask = newMask;
	}

	void ChangeMaskInitial(Mask newMask)
	{
		//StartCoroutine(fadeScript.ChangeMask());
		ManageBlocks(newMask);
		ManageEnemies(newMask);
		
		mask = newMask;
	}

	public void RegisterBlock(GameObject block)
	{
		blocks.Add(block);
	}

	public void RegisterEnemy(GameObject enemy)
	{
		enemies.Add(enemy);
	}

	void ManageBlocks(Mask newMask)
	{
		string tag1 = "";
		switch(mask)
		{
		case Mask.Red:
			tag1 = "RedBlock";
			break;
		case Mask.Blue:
			tag1 = "BlueBlock";
			break;
		case Mask.Green:
			tag1 = "GreenBlock";
			break;
		case Mask.Orange:
			tag1 = "OrangeBlock";
			break;
		};
		
		string tag2 = "";
		switch(newMask)
		{
		case Mask.Red:
			tag2 = "RedBlock";
			break;
		case Mask.Blue:
			tag2 = "BlueBlock";
			break;
		case Mask.Green:
			tag2 = "GreenBlock";
			break;
		case Mask.Orange:
			tag2 = "OrangeBlock";
			break;
		};
		
		foreach(GameObject block in blocks)
		{
			if(block.name == tag1)
				block.SetActive (true);
			if(block.name == tag2)
				block.SetActive (false);
		}
	}

	void ManageEnemies(Mask newMask)
	{
		string tag1 = "";
		string tag2 = "";
		switch(newMask)
		{
		case Mask.Red:
			tag2 = "BlueMon";
			tag1 = "RedMon";
			playerMask.GetComponent<SpriteRenderer>().color = Color.red;
			music.PlayRed();
			break;
		case Mask.Blue:
			tag2 = "RedMon";
			tag1 = "BlueMon";
			playerMask.GetComponent<SpriteRenderer>().color = Color.blue;
			music.PlayBlue();
			break;
		case Mask.Green:
			tag2 = "OrangeMon";
			tag1 = "GreenMon";
			playerMask.GetComponent<SpriteRenderer>().color = Color.green;
			music.PlayGreen();
			break;
		case Mask.Orange:
			tag2 = "GreenMon";
			tag1 = "OrangeMon";
			playerMask.GetComponent<SpriteRenderer>().color = new Color(255, 174, 0);
			music.PlayOrange();
			break;
		};
		
		foreach(GameObject enemy in enemies)
		{
			enemy.collider2D.enabled = false;
			enemy.GetComponent<EnemyScript>().ChangeState(0);

			if(enemy.tag == tag1)
			{
				enemy.collider2D.enabled = true;
				enemy.GetComponent<EnemyScript>().ChangeState(1);
			}
			else if(enemy.tag == tag2)
			{
				enemy.collider2D.enabled = true;
				enemy.GetComponent<EnemyScript>().ChangeState(2);
			}
		}
	}

	public void PlayerHit()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	public bool AllGhostsDead()
	{
		foreach(GameObject enemy in enemies)
		{
			if(enemy.gameObject.activeSelf)
				return false;
		}

		return true;
	}
}
