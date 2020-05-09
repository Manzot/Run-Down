using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemiesMovements : MonoBehaviour {

	public float speed;
	public bool isMoving;

	public int MoveDirection;

	private Rigidbody2D rbody;

	public Collider2D walkArea;
	private Vector3 maxAreaPos;
	private Vector3 minAreaPos;
	private bool hasWalkArea;
	public float waitTime;

	public float TotalHealth;
	// Use this for initialization
	void Start () 
	{
		rbody = GetComponent<Rigidbody2D>();
		isMoving = true;
	
		InvokeRepeating("ChooseDirection", 2f, 1f);
		

		if (walkArea != null) 
		{
			maxAreaPos = walkArea.bounds.max;
			minAreaPos = walkArea.bounds.min;
			hasWalkArea = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(TotalHealth <= 0)
		{
			gameObject.SetActive(false);
		}

		waitTime -= Time.deltaTime;

		if(!isMoving)
		{
			MoveDirection = 4;
		}
		if(waitTime <= 0)
		{
			isMoving = true;
		}
		else
			isMoving = false;

		switch (MoveDirection) 
		 {
		 	case 0:
			rbody.velocity = new Vector2 (Random.Range(-1,1), speed);
				if (hasWalkArea && transform.position.y > maxAreaPos.y || transform.position.x > maxAreaPos.x || transform.position.x < minAreaPos.x) 
				{
					isMoving = false;
					waitTime = 0.5f;
				}
				break;
			case 1:
				rbody.velocity = new Vector2 (Random.Range(-1,1), -speed);
				if (hasWalkArea && transform.position.y < minAreaPos.y || transform.position.x > maxAreaPos.x || transform.position.x < minAreaPos.x) 
				{
					isMoving = false;
					waitTime = 0.5f;
				}
				break;
			case 2:
				rbody.velocity = new Vector2 (speed, Random.Range(-1,1));
				if (hasWalkArea && transform.position.x > maxAreaPos.x || transform.position.y < minAreaPos.y || transform.position.y > maxAreaPos.y) 
				{
					isMoving = false;
					waitTime = 0.5f;
				}
				break;
			case 3:
				rbody.velocity = new Vector2 (-speed, Random.Range(-1,1));
				if (hasWalkArea && transform.position.x < minAreaPos.x || transform.position.y < minAreaPos.y || transform.position.y > maxAreaPos.y) 
				{
					isMoving = false;
					waitTime = 0.5f;
				}
				break;
			case 4:
				rbody.velocity = Vector2.zero; 
				break;
			}
	}

	public void ChooseDirection()
	{
	
		MoveDirection = Random.Range(0, 5);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Sword")
		{
			TotalHealth -= FindObjectOfType<PlayerStats>().Damage;
		}
	}
}
