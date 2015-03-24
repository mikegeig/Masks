using UnityEngine;
using System.Collections;

public class FaderScript : MonoBehaviour {

	SpriteRenderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer>();
		FadeOut();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FadeOut()
	{
		StartCoroutine(Fade(1.0f, 0.0f, .5f));     // fade down
	}
	
	void FadeIn()
	{
		StartCoroutine(Fade(0.0f, 1.0f, .5f));     // fade down
	}

	public IEnumerator ChangeMask()
	{
		float speed = 1.0f/.15f;   
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime*speed) {
			Color col = rend.color;
			col.a = Mathf.Lerp(0f, 1f, t);
			rend.color = col;
			yield return null;
		}
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime*speed) {
			Color col = rend.color;
			col.a = Mathf.Lerp(1f, 0f, t);
			rend.color = col;
			yield return null;
		}
	}

	IEnumerator Fade (float startLevel , float endLevel , float duration) {
		float speed = 1.0f/duration;   
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime*speed) {
			Color col = rend.color;
			col.a = Mathf.Lerp(startLevel, endLevel, t);
			rend.color = col;
			yield return null;
		}
	}
}