using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersTutorialTrigger : MonoBehaviour {

	public GameObject PowerUpsTutorial;
	private BoxCollider2D boxCol;
	private bool ButtonPressed;

	// Use this for initialization
	void Start () 
	{
		boxCol = GetComponent<BoxCollider2D>();	
		ButtonPressed = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		StartCoroutine (DisableTutorial());
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			FindObjectOfType<PlayerControls>().Speed = 0f;
			FindObjectOfType<PlayerControls>().AccelSpeed = 0f;
			PowerUpsTutorial.SetActive(true);
		}
	}
	public void EmptyButtonTut()
	{
		FindObjectOfType<PlayerControls>().Speed = FindObjectOfType<PlayerControls>().SpeedAfterBoosts;
		FindObjectOfType<PlayerControls>().AccelSpeed = FindObjectOfType<PlayerControls>().AccelSpeedAfterStop;
		ButtonPressed = true;
		boxCol.enabled = false;
	}

	IEnumerator DisableTutorial()
	{
		if(PowerUpsTutorial.activeInHierarchy && ButtonPressed)
		{
			yield return new WaitForSeconds(0.4f);
			PowerUpsTutorial.SetActive(false);
		}
	}
}
