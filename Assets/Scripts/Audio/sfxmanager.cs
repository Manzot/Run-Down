using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxmanager : MonoBehaviour {

	public AudioClip attack_sfx1, jump_sfx1, mines_blast;

	public AudioSource audioSrc;
	public  bool sfxPlayed;
	// Use this for initialization
	void Start () 
	{
		sfxPlayed = false;
		audioSrc = GetComponent<AudioSource>();
	}

}
