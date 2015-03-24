using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {

	void Awake()
	{
		GameObject.Find ("GameControl").GetComponent<GameControlScript>().RegisterBlock(this.gameObject);
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
