using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctorokThrowingRocks : MonoBehaviour {

	private Rigidbody2D rbody;
	private Animator anim;

	[SerializeField] private FindingPlayer octrokSpottingPlayer;

	//Throwing Rock Variables
	public Transform throwPosition;
	public GameObject rockThrowObject;
	public GameObject player;

	public float ThrowWaitTime;
	public float ThrowTimer;

// Octorok SFX
	private AudioSource audioSrc;
	public AudioClip throwSfx;

	// Use this for initialization
	void Start () 
	{
		rbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		audioSrc = GetComponent<AudioSource>();
		player = GameObject.FindWithTag ("Player");
		//octrokSpottingPlayer = FindObjectOfType<OctrokFindingPlayer>();
	}


	// Update is called once per frame
	void Update () 
	{
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	// If Player is Sighted
		if(octrokSpottingPlayer.playerInSight)
		{
			anim.SetBool("isAttacking", true);
		}
		else
		{
				anim.SetBool("isAttacking", false);
		}

	}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	public void RockThrow()
	{
		GameObject projectile = (GameObject)Instantiate(rockThrowObject);
		projectile.transform.position = throwPosition.position;
		audioSrc.clip = throwSfx;
		audioSrc.Play();
	}
}
