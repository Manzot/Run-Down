using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCoinsSystem : MonoBehaviour {


	private PlayerStats stats;
	public Text GoldCountText;
	// Use this for initialization
	void Start () 
	{
		stats = FindObjectOfType<PlayerStats> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			stats.Gold += 1;
			Destroy(gameObject);
			GoldCountText.text = "Gold: " + stats.Gold.ToString ();
		}
	}
}
