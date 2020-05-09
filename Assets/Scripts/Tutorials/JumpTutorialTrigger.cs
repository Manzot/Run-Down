using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTutorialTrigger : MonoBehaviour {

	public GameObject JumpTutorial;
	public GameObject DialogBox;
	public GameObject JumpButtonOriginal;
	private BoxCollider2D boxCol;
	// Use this for initialization
	void Start () 
	{
		boxCol = GetComponent<BoxCollider2D>();	
		JumpButtonOriginal.SetActive(false);
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
			JumpTutorial.SetActive(true);
			DialogBox.SetActive(true);
			JumpButtonOriginal.SetActive(true);
		}
	}
	public void JumpButtonTut()
	{
		FindObjectOfType<PlayerControls>().Speed = FindObjectOfType<PlayerControls>().SpeedAfterBoosts;
		FindObjectOfType<PlayerControls>().AccelSpeed = FindObjectOfType<PlayerControls>().AccelSpeedAfterStop;
		FindObjectOfType<PlayerControls>().Jumping = true;
		boxCol.enabled = false;
	}

	IEnumerator DisableTutorial()
	{
		if(JumpTutorial.activeInHierarchy && FindObjectOfType<PlayerControls>().Jumping)
		{
			yield return new WaitForSeconds(0.2f);
			JumpTutorial.SetActive(false);
			DialogBox.SetActive(false);
		}
	}

}