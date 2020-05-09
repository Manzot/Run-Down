using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableOnPlayer : MonoBehaviour {

	public int damage;
	public float throwSpeed;
	Vector2 direction;
	Rigidbody2D rbody;
	// Use this for initialization
	
	void Start ()
	{
		rbody = GetComponent<Rigidbody2D>();
		direction = (GameObject.FindWithTag("Player").transform.position - transform.position).normalized * throwSpeed * Time.deltaTime;
		rbody.velocity = new Vector2 (direction.x, direction.y);
		Destroy (gameObject, 5f);
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if(other.gameObject != null)
		{
			Destroy(gameObject);
		}

		if(other.gameObject.tag == "Player")
		{
			FindObjectOfType<PlayerStats>().CurrentHealth -= damage;
			Destroy(gameObject);
		}
	}

}
