using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	GameControlScript control;

	// Use this for initialization
	void Start () {
		control = GameObject.Find("GameControl").GetComponent<GameControlScript>();
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
			if(control.AllGhostsDead())
				Application.LoadLevel(Application.loadedLevel + 1);
	}
}
