#pragma strict

var rend : SpriteRenderer;

public var fadein : boolean = true;
public var fadeout : boolean = true;
var initialPause : float = 1;
var fadeInTime : float = 2;
var fadeOutTime : float = 2;


function Start () {
	rend = GetComponent(SpriteRenderer);
	if(fadein){
		rend.color.a = 0F;
		yield WaitForSeconds (initialPause);
		yield Fade(0.0, 1.0, fadeInTime);     // fade up
	}
	//GetComponent(AudioSource).Play();
	if(fadeout){
		yield Fade(1.0, 0.0, fadeOutTime);     // fade down
		rend.color.a = 0.0;
	}
}

function Fade (startLevel :float, endLevel :float, duration :float) {
	var speed : float = 1.0/duration;   
	for (var t :float = 0.0; t < 1.0; t += Time.deltaTime*speed) {
	    rend.color.a = Mathf.Lerp(startLevel, endLevel, t);
	    yield;
	}
}