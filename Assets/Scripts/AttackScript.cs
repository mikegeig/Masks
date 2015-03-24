using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {

	PolygonCollider2D polyCol;
	bool attacking = false;
	SwordScript sword;
	
	void Start () {
		polyCol = GetComponent<PolygonCollider2D>();
		sword = GetComponentInChildren<SwordScript>();
	}

	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			if(!polyCol.enabled)
			{
				attacking = true;
				sword.Swing();
			}
		}
	}

	void FixedUpdate()
	{
		if(attacking){
			polyCol.enabled = true;
			attacking = false;
		}
		else
			polyCol.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Wall" || other.tag == "Block" || other.tag == "Floor") return;

		if(other.GetComponent<EnemyScript>().Hit())
			audio.Play();
	}
}
