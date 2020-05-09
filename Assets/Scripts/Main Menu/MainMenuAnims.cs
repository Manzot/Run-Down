using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnims : MonoBehaviour {

	private MainMenuManager mmm;
	private Animator anim;
	// Use this for initialization
	void Start () 
	{
		mmm = FindObjectOfType<MainMenuManager> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (mmm.OptionClicked) 
		{
			anim.SetBool ("OptionsAnim", true);
		} 
		else 
		{
			anim.SetBool ("OptionsAnim", false);
		}

		if (!mmm.OptionClicked) 
		{
			anim.enabled = true;
		}
	}
	public void AnimStopped()
	{
		anim.enabled = false;
	}
}
