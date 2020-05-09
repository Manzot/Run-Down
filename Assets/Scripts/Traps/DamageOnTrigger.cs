using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTrigger : MonoBehaviour {

	private PlayerStats playerStats;

	public int DamageToGive;
	// Use this for initialization
	void Start () {
		playerStats = FindObjectOfType<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			playerStats.CurrentHealth -= DamageToGive;
		}
	}
}
