using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

	//private JoystickUI Vjoy;

	private Animator anim;
	private Vector3 movement;
	private Rigidbody2D rbody;

	public float Speed;
	public float SpeedAfterBoosts; 
	public float AccelSpeed;
	public float AccelSpeedAfterStop;

	public bool Jumping;
	public float jumpTime;
	private float jumpTimeCounter;
	private bool JumpWait;
	private float jumpWaitingTime;

	public bool attacking;
	public float attackTime;
	private float attackTimeCounter;
	//public float damageToGive;

	public bool keepRunning;
	public GameObject tapToStart;

	private sfxmanager sfx;
	public bool sfxPlaying;
	// Use this for initialization
	void Start () 
		{
		//Vjoy = FindObjectOfType <JoystickUI> ();
		anim = GetComponent <Animator> ();
		rbody = GetComponent <Rigidbody2D> ();	
		attackTimeCounter = attackTime;
		jumpTimeCounter = jumpTime;
		Jumping = false;
		jumpWaitingTime = 0.2f;
		keepRunning = false;
		tapToStart.SetActive (true);
		sfx = FindObjectOfType<sfxmanager>();
	}
	
	// Update is called once per frame
	void Update () 
	{	
		// Making Collisions with traps when not Jumping
		Physics2D.IgnoreLayerCollision (8, 9, false);

		// Using Accelometer
		transform.Translate (Input.acceleration.x * AccelSpeed * Time.deltaTime, 0, 0);

		JumpingFunction ();

		AttackingFunction();

		if (keepRunning) 
		{
			//var movementy = Vector3.down;
			//rbody.MovePosition (transform.position + movementy * speed * Time.deltaTime);
			rbody.velocity = new Vector2(0, -1) * Speed * Time.deltaTime;

			if (rbody.velocity != Vector2.zero) {
				anim.SetBool ("isWalking", true);
				//anim.SetFloat ("input_x", movement.x);
				anim.SetFloat ("input_y", rbody.velocity.y);
			}
		}
		else {
			rbody.velocity = new Vector2(0, 0);
			anim.SetBool ("isWalking", false);
		}

		if(Speed == 0)
		{
			anim.SetBool ("isWalking", false);
		}
		
		/*if(FindObjectOfType<FollowEnemyMovements>().distanceToPlayer <= 1f)
		{
			Speed = 10f;
			AccelSpeed = 1f;
		}*/
		
	}

	// Keyboard Control function
	/*public void KeyboardControls()
	{

		if (!attacking) 
		{
			movement = new Vector3 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), 0);
			rbody.MovePosition (transform.position + movement * Speed * Time.deltaTime);

			anim.SetBool ("isWalking", true);
			anim.SetFloat ("input_x", movement.x);
			anim.SetFloat ("input_y", movement.y);
		}

		if (Input.GetKeyDown (KeyCode.K)) 
		{
			attacking = true;
		}

	}*/

	// Virtual joystick Control function
	/*
	public void JoystickControls()
	{
		if (!attacking && Vjoy.InputDirection != Vector2.zero) 
		{
			movement = new Vector2(Vjoy.InputDirection.x, Vjoy.InputDirection.y / 1.2f);
			rbody.MovePosition (transform.position + movement * Speed * Time.deltaTime);
		}

		if (!attacking && movement != Vector3.zero) 
		{
			anim.SetBool ("isWalking", true);
			anim.SetFloat ("input_x", movement.x);
			anim.SetFloat ("input_y", movement.y);
		} 
		else 
		{
			anim.SetBool ("isWalking", false);
		}

	}*/
	public void AttackingFunction()
	{
		// Attacking Function
		if (attacking) 
		{
			if(!sfxPlaying && !FindObjectOfType<PlayerStats>().isDead)
			{
				sfx.audioSrc.clip = sfx.attack_sfx1;
				sfx.audioSrc.Play();
				sfxPlaying = true;
			}
			anim.SetBool ("isWalking", false);
			attackTimeCounter -= Time.deltaTime;
			anim.SetBool ("isAttacking", true);
		}

		if (attackTimeCounter <= 0) 
		{
			attacking = false;
			anim.SetBool ("isAttacking", false);
			attackTimeCounter = attackTime;
			sfxPlaying = false;
		}

	}

	public void JumpingFunction()
	{
		if (Jumping && !JumpWait) 
		{
			if(!sfxPlaying && !FindObjectOfType<PlayerStats>().isDead)
			{
				sfx.audioSrc.clip = sfx.jump_sfx1;
				sfx.audioSrc.Play();
				sfxPlaying = true;
			}

			jumpTimeCounter -= Time.deltaTime;
			Physics2D.IgnoreLayerCollision (8, 9, true);
			anim.SetBool ("jump", true);
		} 

		if (jumpTimeCounter < 0) 
		{
			anim.SetBool ("jump", false);
			JumpWait = true;
			sfxPlaying = false;
			jumpWaitingTime -= Time.deltaTime;
		}

		if (jumpWaitingTime < 0) 
		{
			Jumping = false;
			JumpWait = false;
			jumpTimeCounter = jumpTime;
			jumpWaitingTime = 0.1f;
		}

	}

	// Attacking Button for Android
	public void AttackButton()
	{
		attacking = true;
	}

	public void JumpButton()
	{
		Jumping = true;
	}

	public void StartRun()
	{
		keepRunning = true;
		tapToStart.SetActive (false);

	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if(other.gameObject.tag == "Mines")
		{
			//keepRunning = false;
			rbody.velocity = Vector3.up * 50f * Time.deltaTime;
		}
	}

	public void PlayerDied()
	{
		Speed = 0;
		AccelSpeed = 0;
		rbody.velocity = Vector2.zero;
	}

}

