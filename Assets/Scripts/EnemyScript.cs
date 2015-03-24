using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	int state = 0;
	Animator anim;
	GameObject player;
	float monSpeed = 15;
	float humSpeed = 9;
	float ghostSpeed = 3;
	GameControlScript control;
	public GameObject bloodSpatter;

	void Awake()
	{
		control = GameObject.Find ("GameControl").GetComponent<GameControlScript>();
		control.RegisterEnemy(this.gameObject);
		anim = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(state == 0)
			GhostUpdate();
		else if (state == 1)
			HumanUpdate();
		else 
			MonsterUpdate();
	}

	public void ChangeState(int state)
	{
		this.state = state;

		anim.SetInteger("State", state);
		anim.SetTrigger("Change");
	}

	void GhostUpdate()
	{
		transform.Rotate(0, 0, Random.Range(-10, 10));
		
		rigidbody2D.AddForce(gameObject.transform.up * ghostSpeed);

		var pos = transform.position;
		if(pos.x > 7)
			pos.x = 7;
		else if(pos.x < -7)
			pos.x = -7;

		if(pos.y > 4)
			pos.y = 4;
		else if(pos.y < -4)
			pos.y = -4;

		transform.position = pos;

	}

	void HumanUpdate()
	{
		rigidbody2D.transform.eulerAngles = new Vector3(0,0,Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x))*Mathf.Rad2Deg - 90);
		transform.Rotate(0, 0, 180);

		rigidbody2D.AddForce(gameObject.transform.up * humSpeed);
	}

	void MonsterUpdate()
	{
		rigidbody2D.transform.eulerAngles = new Vector3(0,0,Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x))*Mathf.Rad2Deg - 90);
		
		rigidbody2D.AddForce(gameObject.transform.up * monSpeed);
	}

	public bool Hit()
	{
		if(state == 1){
			this.gameObject.SetActive(false);
			//var rot = new Vector3(0,0,Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x))*Mathf.Rad2Deg - 90);
			Instantiate(bloodSpatter, transform.position, transform.rotation);
			//splatter.transform.eulerAngles = new Vector3(0,0,Mathf.Atan2((player.transform.position.y - splatter.transform.position.y), (player.transform.position.x - splatter.transform.position.x))*Mathf.Rad2Deg - 90);
			//splatter.transform.Rotate(0, 0, 180);
			return true;
		}

		return false;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(state == 2 && other.gameObject.tag == "Player")
			control.PlayerHit();
	}
}
