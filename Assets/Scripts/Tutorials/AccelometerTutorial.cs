using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelometerTutorial : MonoBehaviour {

	public GameObject Tutorial;

	// Use this for initialization
	void Start () 
	{
		Tutorial.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(FindObjectOfType<PlayerControls>().keepRunning)
		{
			Tutorial.SetActive(false);
		}
	}
}
