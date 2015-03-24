using UnityEngine;
using System.Collections;

public class PlayerMotorScript : MonoBehaviour {

	public float speed = 1f;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {      
		
		var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);		
		Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward );		
		transform.rotation = rot;   
		transform.eulerAngles = new Vector3(0, 0,transform.eulerAngles.z); 
		rigidbody2D.angularVelocity = 0;

		float input = Input.GetAxis("Vertical");

		rigidbody2D.AddForce(gameObject.transform.up * speed * input);

		anim.SetFloat ("Speed", Mathf.Abs(input));
	}
}
