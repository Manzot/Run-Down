using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastingMines : MonoBehaviour {

	private Animator anim;
	public float destroyAfterSeconds;
	public bool blasted;
	private sfxmanager sfx;
	// Use this for initialization
	void Start () 
	{
		sfx = FindObjectOfType<sfxmanager>();
		anim = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		DestroyedAfterSeconds();
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			blasted = true;
			anim.SetBool ("isBlasted", true);
			sfx.audioSrc.clip = sfx.mines_blast;
			sfx.audioSrc.Play();
		}
	}

	public void DestroyedAfterSeconds()
	{
		if(blasted)
		{
			destroyAfterSeconds -= Time.deltaTime;
		}

		if(destroyAfterSeconds <= 0)
		{
			Destroy(gameObject);
		}
	}
}
