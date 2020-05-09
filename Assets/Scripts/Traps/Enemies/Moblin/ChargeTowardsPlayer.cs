using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeTowardsPlayer : MonoBehaviour {

	public int damage;
	public float throwSpeed;

	Vector2 direction;
	Rigidbody2D rbody;

	private Animator anim;

	[SerializeField]
	private FindingPlayer playerSpotted;
	// Use this for initialization
	void Start ()
	{
		rbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		//Destroy (gameObject, 5f);
	}

	void Update(){
		if(playerSpotted.playerInSight){
			direction = (GameObject.FindWithTag("Player").transform.position - transform.position).normalized * throwSpeed * Time.deltaTime;
			rbody.velocity = new Vector2 (direction.x, direction.y);
			anim.SetBool("isAttacking", true);
		}
		else{
			anim.SetBool("isAttacking", false);
			rbody.velocity = Vector2.zero;
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{

		if(other.gameObject.tag == "Player")
		{
			FindObjectOfType<PlayerStats>().CurrentHealth -= damage;
			//Destroy(gameObject);
		}
	}
}
