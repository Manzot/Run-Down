using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemyMovements : MonoBehaviour {

	// Use this for initialization
	
	public float speed;
	public float PlayerEnemyDistance;
	public float TotalHP;

	private Transform player;

	public float distanceToPlayer;

	public bool canMove;
	public float thrust;
	public float knockTime;

	void Start () 
	{
		canMove = true;
		player = GameObject.FindWithTag("Player").transform;
		knockTime = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(TotalHP <= 0)
		{
			gameObject.SetActive(false);
		}

		distanceToPlayer = Vector2.Distance(transform.position, player.position);
		
		if(distanceToPlayer <= PlayerEnemyDistance && canMove)
		{
			transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
		}

		if(!canMove)
		{
			knockTime -= Time.deltaTime;
		}
		if(knockTime <= 0)
		{
			canMove = true;
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			canMove = false;

			float horizontalPush = (other.gameObject.transform.position.x - transform.position.x);
			float vertticalPush = (other.gameObject.transform.position.y - transform.position.y);
			
			if(!canMove)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(-horizontalPush, -vertticalPush) * thrust * Time.deltaTime;
				knockTime = 0.8f;
			}
			else
				transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			TotalHP -= FindObjectOfType<PlayerStats>().Damage;
			canMove = false;

			float horizontalPush = (other.gameObject.transform.position.x - transform.position.x);
			float vertticalPush = (other.gameObject.transform.position.y - transform.position.y);
			
			if(!canMove)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(-horizontalPush, -vertticalPush) * thrust * Time.deltaTime;
				knockTime = 0.8f;
			}
			else
				transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
		}
	}

}
