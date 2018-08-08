using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateRandomly : MonoBehaviour {

	public float speed = 5.0f;
	public float amplitude = 10.0f;

	private Vector3 direction;

	// Use this for initialization
	void Start () 
	{
		direction = Random.insideUnitSphere*speed*Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(direction*amplitude*Mathf.Sin(speed*Time.time));
	}
}
