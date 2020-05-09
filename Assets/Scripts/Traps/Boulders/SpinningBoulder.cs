using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBoulder : MonoBehaviour {

	private Rigidbody2D rbody;
	public float Speed;
	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
			rbody.velocity = new Vector2 (0, 1) * Speed * Time.deltaTime;
	}
	
}
