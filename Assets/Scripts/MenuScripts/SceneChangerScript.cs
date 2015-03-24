using UnityEngine;
using System.Collections;

public class SceneChangerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("PlayLogo", 2);
		Invoke ("NextScene", 5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void NextScene()
	{
		Application.LoadLevel(1);
	}

	void PlayLogo()
	{
		audio.Play();
	}
}
