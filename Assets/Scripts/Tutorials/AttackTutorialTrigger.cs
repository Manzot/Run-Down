using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTutorialTrigger : MonoBehaviour {

	public GameObject AttackTutorial;
	public GameObject DialogBox;
	private BoxCollider2D boxCol;
	public GameObject AttackButtonOriginal;
	// Use this for initialization
	void Start () 
	{
		boxCol = GetComponent<BoxCollider2D>();	
		AttackButtonOriginal.SetActive(false);
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
			AttackTutorial.SetActive(true);
			DialogBox.SetActive(true);
			AttackButtonOriginal.SetActive(true);
		}
	}
	public void AttackButtonTut()
	{
		FindObjectOfType<PlayerControls>().Speed = FindObjectOfType<PlayerControls>().SpeedAfterBoosts;
		FindObjectOfType<PlayerControls>().AccelSpeed = FindObjectOfType<PlayerControls>().AccelSpeedAfterStop;
		FindObjectOfType<PlayerControls>().attacking = true;
		boxCol.enabled = false;
	}

	IEnumerator DisableTutorial()
	{
		if(AttackTutorial.activeInHierarchy && FindObjectOfType<PlayerControls>().attacking)
		{
			yield return new WaitForSeconds(0.2f);
			AttackTutorial.SetActive(false);
			DialogBox.SetActive(false);
		}
	}
}
