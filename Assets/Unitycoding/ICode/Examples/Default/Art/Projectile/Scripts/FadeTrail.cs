using UnityEngine;
using System.Collections;

public class FadeTrail : MonoBehaviour {

	public float fadeInTime=0.1f;
	public float stayTime=1.0f;
	public float fadeOutTime=0.7f;
	private TrailRenderer thisTrail;
	private float timeElapsed;
	private float timeElapsedLast;
	private float percent;

	private void Start ()
	{
		thisTrail = GetComponent<TrailRenderer> ();
		thisTrail.material.SetColor ("_TintColor", new Color(0.5f,0.5f,0.5f,1.0f));
		if (fadeInTime < 0.01f) {
			fadeInTime = 0.01f;
		}
		percent=timeElapsed/fadeInTime;
	}

	private void Update () {
		timeElapsed+=Time.deltaTime;
		if(timeElapsed<=fadeInTime) //fade in
		{
			percent=timeElapsed/fadeInTime;
			thisTrail.material.SetColor ("_TintColor", new Color(0.5f,0.5f,0.5f, percent));
		}
		
		if((timeElapsed>fadeInTime)&&(timeElapsed<fadeInTime+stayTime)) //set the normal color
		{
			thisTrail.material.SetColor ("_TintColor", new Color(0.5f,0.5f,0.5f,1.0f));
		}
		
		if(timeElapsed>=fadeInTime+stayTime&&timeElapsed<fadeInTime+stayTime+fadeOutTime) //fade out
		{
			timeElapsedLast+=Time.deltaTime;
			percent=1.0f-(timeElapsedLast/fadeOutTime);
			thisTrail.material.SetColor ("_TintColor", new Color(0.5f,0.5f,0.5f, percent));
		}
	}
}
