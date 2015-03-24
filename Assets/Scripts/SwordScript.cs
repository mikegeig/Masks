using UnityEngine;
using System.Collections;

public class SwordScript : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Swing()
	{
		anim.SetTrigger("Swing");
	}
}
