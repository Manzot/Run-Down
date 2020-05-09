using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float camSpeed;
	public Transform target;
	//public float zoom;
	Camera cam;
	// Use this for initialization
	void Start () 
	{	
		cam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//cam.orthographicSize = (Screen.height / 100f) / zoom;
		transform.position = Vector3.Lerp (transform.position, target.position, camSpeed) + new Vector3 (0,0, -10);
	}
}
