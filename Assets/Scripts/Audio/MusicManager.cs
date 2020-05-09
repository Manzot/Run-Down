using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	private AudioSource audioS;
	public AudioClip musicLevel1;
	public bool musicPlaying;
	//public bool mCanPlay = false;
	// Use this for initialization
	
	void Start()
	{
		audioS = GetComponent<AudioSource>();
		audioS.Stop();
		musicPlaying = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!musicPlaying)
		{
			audioS.clip = musicLevel1;
			audioS.Play();
		}
		
		if(FindObjectOfType<PlayerControls>().keepRunning)
		{
			musicPlaying = true;
		}else {
			musicPlaying = false;
		}
	}

}
