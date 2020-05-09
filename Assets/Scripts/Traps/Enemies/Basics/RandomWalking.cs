using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalking : MonoBehaviour {

	private Animator anim;
	private Rigidbody2D rbody;
// Movement Variables
	public float speed;
	private bool isMoving;
	public float walkTime;
	public float walkTimeCounter;
    public float TotalHP;
// Direction and WalkAreas
	private Vector2 direction;
	public Collider2D walkArea;
	private Vector2 maxAreaPos;
	private Vector2 minAreaPos;
	private bool hasWalkArea;
 	public float waitTime;

	// Use this for initialization
	void Start () 
	{
		rbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

		isMoving = true;
		
		walkTimeCounter = walkTime;

		//ThrowWaitTime = 0;

		if (walkArea != null) 
		{
			maxAreaPos = walkArea.bounds.max;
			minAreaPos = walkArea.bounds.min;
			hasWalkArea = true;
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		
        if(TotalHP <= 0)
        {
            Destroy(gameObject);
        }
		// Movements Randomly
		walkTimeCounter -= Time.deltaTime;

		if(walkTimeCounter >= 0 && isMoving)
		{
			rbody.velocity = (direction * speed * Time.deltaTime);

			anim.SetBool("isWalking", true);
			anim.SetFloat("Input_X", direction.x);
			anim.SetFloat("Input_Y", direction.y);
			
			if(hasWalkArea && transform.position.x > maxAreaPos.x)
			{
				direction = new Vector2 (-1,0);
			}
			if(hasWalkArea && transform.position.x < minAreaPos.x)
			{
				direction = new Vector2 (1,0);
			}
			if(hasWalkArea && transform.position.y > maxAreaPos.y)
			{
				direction = new Vector2 (0,-1);
			}
			if(hasWalkArea && transform.position.y < minAreaPos.y)
			{
				direction = new Vector2 (0,1);
			}
		}
		else
			rbody.velocity = (direction * 0 * Time.deltaTime);

		if(walkTimeCounter <= -waitTime)
		{
			isMoving = true;
			direction = new Vector2 (Random.Range(-1,1), Random.Range(-1,1));
			//walkTime = 3f;
			walkTimeCounter = walkTime;
		}

       
        }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TotalHP -= FindObjectOfType<PlayerStats>().Damage;
            
        }
    }
}
