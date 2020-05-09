using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour {

	public bool OptionClicked;

	private AudioSource MenuSfx;
	public AudioClip buttonSfx1;
	public bool mp;
	// Use this for initialization
	void Start () 
	{
		OptionClicked = false;
		MenuSfx = GetComponent<AudioSource>();
		//sfx = FindObjectOfType<sfxmanager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NewGame()
	{
		SceneManager.LoadScene (1);
		MenuSfx.PlayOneShot(buttonSfx1);	
		//mp = true;
	}

	public void LoadLevel(int LevelToLoad)
	{
		SceneManager.LoadScene (LevelToLoad);
		MenuSfx.PlayOneShot(buttonSfx1);	
		//mp = true;
	}

	public void OptionsScreen()
	{
		OptionClicked = true;
		MenuSfx.PlayOneShot(buttonSfx1);	
		//mp = true;
	}

	public void BacktoMenu ()
	{
		OptionClicked = false;
		MenuSfx.PlayOneShot(buttonSfx1);		
		//mp = true;
	}

	public void ExitGame()
	{
		Application.Quit ();
		MenuSfx.PlayOneShot(buttonSfx1);		
		//mp = true;
	}
}
