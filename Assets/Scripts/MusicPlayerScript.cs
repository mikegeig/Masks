using UnityEngine;
using System.Collections;

public class MusicPlayerScript : MonoBehaviour {

	public AudioClip[] clips;
	int currentSound = -1;

	// Use this for initialization
	void Start () {
		audio.volume = .8f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void PlayRed()
	{
		if(currentSound == 0) return;

		currentSound = 0;
		audio.clip = clips[currentSound];
		audio.Play();
	}
	public void PlayBlue()
	{
		if(currentSound == 1) return;
		
		currentSound = 1;
		audio.clip = clips[currentSound];
		audio.Play();
	}

	public void PlayGreen()
	{
		if(currentSound == 2) return;
		
		currentSound = 2;
		audio.clip = clips[currentSound];
		audio.Play();
	}

	public void PlayOrange()
	{
		if(currentSound == 3) return;
		
		currentSound = 3;
		audio.clip = clips[currentSound];
		audio.Play();
	}

}
