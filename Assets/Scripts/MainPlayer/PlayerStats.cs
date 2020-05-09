using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	private PlayerControls player;
	private Rigidbody2D rbody;
	private Animator anim;


	public float MaxHealth;
	public float CurrentHealth;

	public int Damage;
	public int Gold;

	public bool isDead;
	//public Text healthValue;

	public Slider HealthBar;

	// Use this for initialization
	void Start() 
	{
		anim = GetComponent<Animator>();
		rbody = GetComponent<Rigidbody2D>();
		player = FindObjectOfType<PlayerControls>();
		CurrentHealth = MaxHealth;
		//Gold = 0;
		isDead = false;
		//DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Health Show Text
	//	healthValue.text = "Health: " + CurrentHealth.ToString () + "/" + MaxHealth.ToString ();
		HealthBar.maxValue = MaxHealth;
		HealthBar.value = CurrentHealth;
		// If Player runs out of health
		if (CurrentHealth <= 0) 
		{
			FindObjectOfType<RestartAndLevelLoadManager>().RestartButtonsObject.SetActive (true);
			//rbody.velocity =  Vector2.zero;
			//this.gameObject.SetActive (false);
			anim.SetBool("isDead", true);
			isDead = true;
		}
	}

	public void AnimationPaused()
	{
		anim.enabled = false;
		player.keepRunning = false;
		rbody.velocity = new Vector2 (0,0);
	}
}


