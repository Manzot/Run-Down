using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeedPowerUp : MonoBehaviour {

	private PlayerControls player;
	
	public float BoostSpeed;
	private bool Boosted;
	public int BoostTime;
	public SpriteRenderer thissprite;
	public GameObject PowerUp;
	
	// Use this for initialization
	void Start () 
	{
		player = FindObjectOfType<PlayerControls>();
		Boosted = false;
		//player.Speed = OriginalSpeed;
	}
	
	// Update is called once per frame
	void Update () 
	{
		StartCoroutine(DestroyThis());
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			Boosted = true;
			player.Speed = BoostSpeed;
			thissprite.enabled = false;
		}
	}

	IEnumerator DestroyThis()
	{
		if(Boosted)
		{
			yield return new WaitForSeconds(BoostTime);
			player.Speed = player.SpeedAfterBoosts;
			yield return new WaitForSeconds(0.5f);
			Destroy(PowerUp);
		}
	}
}
