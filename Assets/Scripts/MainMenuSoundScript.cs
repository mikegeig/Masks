using UnityEngine;
using System.Collections;

public class MainMenuSoundScript : MonoBehaviour {

	public MusicPlayerScript music;

	// Use this for initialization
	void Start () {
		int song = Random.Range(0, 4);
		if(song == 0)
			music.PlayRed();
		else if(song == 1)
			music.PlayBlue();
		else if(song == 2)
			music.PlayGreen();
		else
			music.PlayOrange();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
