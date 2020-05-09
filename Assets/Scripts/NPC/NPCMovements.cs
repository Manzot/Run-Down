using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovements : MonoBehaviour {

	public float WalkTime;
	public float WaitTime;

	private float waitCounter;
	private float walkCounter;
	private int MoveDirection;
	public float speed;

	private Rigidbody2D rbody;

	public bool isMoving;

	public Collider2D walkArea;
	private Vector3 maxAreaPos;
	private Vector3 minAreaPos;
	private bool hasWalkArea;

	// Use this for initialization
	void Start () 
	{
		rbody = GetComponent<Rigidbody2D> ();
		walkCounter = WalkTime;
		waitCounter = WaitTime;
		isMoving = false;

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
		if (isMoving) {
			walkCounter -= Time.deltaTime;

			switch (MoveDirection) {
			case 0:
				rbody.velocity = new Vector2 (0, speed);
				if (hasWalkArea && transform.position.y > maxAreaPos.y) 
				{
					isMoving = false;
					waitCounter = WaitTime;
				}
				break;
			case 1:
				rbody.velocity = new Vector2 (0, -speed);
				if (hasWalkArea && transform.position.y < minAreaPos.y) 
				{
					isMoving = false;
					waitCounter = WaitTime;
				}
				break;
			case 2:
				rbody.velocity = new Vector2 (speed, 0);
				if (hasWalkArea && transform.position.x > maxAreaPos.x) 
				{
					isMoving = false;
					waitCounter = WaitTime;
				}
				break;
			case 3:
				rbody.velocity = new Vector2 (-speed, 0);
				if (hasWalkArea && transform.position.x < minAreaPos.x) 
				{
					isMoving = false;
					waitCounter = WaitTime;
				}
				break;
			}

			if (walkCounter < 0) {
				isMoving = false;
				rbody.velocity = Vector2.zero;
				waitCounter = WaitTime;
			}
		}

		// if isMoving Boolean is False than the wait counter will decrease
		if(!isMoving)
		{
			waitCounter -= Time.deltaTime;
			rbody.velocity = Vector2.zero;
			if (waitCounter < 0) 
			{
				ChooseDirection ();
				walkCounter = WalkTime;
			} 
		}
	
	}
	public void ChooseDirection()
	{
		isMoving = true;
		MoveDirection = Random.Range (0, 4);
	}
}
