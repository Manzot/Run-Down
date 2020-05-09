using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public float MaxHealth;
	public float CurrentHealth;

	public GameObject OnHitEffect;
	public Transform hitEffectPos;

	public GameObject MainEnemy;

	// Use this for initialization
	void Start () 
	{
		CurrentHealth = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if(CurrentHealth <= 0)
		{
			Destroy(MainEnemy);
		}

	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Sword")
		{
			CurrentHealth -= FindObjectOfType<PlayerStats>().Damage;
			GameObject HitEffect = (GameObject)Instantiate(OnHitEffect);
			HitEffect.transform.position = hitEffectPos.position;
		}
	}
}
