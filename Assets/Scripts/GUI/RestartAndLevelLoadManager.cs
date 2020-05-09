using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartAndLevelLoadManager : MonoBehaviour {

	public GameObject RestartButtonsObject;
	public GameObject continueToNextLevelButton;
	public int LevelNumber;

	private PlayerControls player;
	// Use this for initialization

	void Start () 
	{
		player = FindObjectOfType<PlayerControls> ();
		RestartButtonsObject.SetActive (false);
		continueToNextLevelButton.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene (LevelNumber);
		RestartButtonsObject.SetActive (false);
		continueToNextLevelButton.SetActive (false);
		player.gameObject.SetActive (true);
	}

	public void Quit()
	{
		Application.Quit ();
	}

	public void ContinueButton()
	{
		SceneManager.LoadScene(FindObjectOfType<LevelID>().levelID + 1);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			RestartButtonsObject.SetActive (true);
			continueToNextLevelButton.SetActive (true);
			//player.gameObject.SetActive (false);
			player.keepRunning = false;
		}
	}
}
