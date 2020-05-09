using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindingPlayer : MonoBehaviour {
	
	public bool playerInSight;

// Throwing Rock Variables
//	public Transform throwPosition;
//	public GameObject rockThrowObject;
//	public GameObject player;

//	public float ThrowWaitTime;
//	public float ThrowTimer;

// Octorok SFX
//	private AudioSource audioSrc;
//	public AudioClip throwSfx;

	// Use this for initialization
	void Start () 
	{
		//rbody = GetComponent<Rigidbody2D>();
		//anim = GetComponent<Animator>();
		//audioSrc = GetComponent<AudioSource>();
	//	player = GameObject.FindWithTag ("Player");
	}


	// Update is called once per frame
	void Update () 
	{
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// If Player is Sighted
		/*if(playerInSight)
		{
			octorokWalking.anim.SetBool("isAttacking", true);
		}
		else
		{
			octorokWalking.anim.SetBool("isAttacking", false);
		}*/

	}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/*public void RockThrow()
	{
		GameObject projectile = (GameObject)Instantiate(rockThrowObject);
		projectile.transform.position = throwPosition.position;
		audioSrc.clip = throwSfx;
		audioSrc.Play();
	}*/

	public void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			playerInSight = true;
		}
	}
	
	public void OnTriggerStay2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			playerInSight = true;
		}
	}

	public void OnTriggerExit2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			playerInSight = false;
		}
	}

}

