using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applyOrbitalForce : MonoBehaviour {

	private GameObject Sun;
	public float orbitalForceMultiplierMin = 1.1f;
	public float orbitalForceMultiplierMax = 4.0f;
	private float orbitalForceMultiplier = 1.0f;
	public bool bothRotations = true;

	private Vector3 orbitalForce;

	// Use this for initialization
	void Start () 
	{
		orbitalForceMultiplier = Random.Range(orbitalForceMultiplierMin, orbitalForceMultiplierMax);
		if (bothRotations)
		{
			orbitalForceMultiplier *= Random.Range(0,2)*2-1;
		}
		Sun = GameObject.FindGameObjectWithTag("SUN");
		orbitalForce = Vector3.Cross(transform.position-Sun.transform.position, Vector3.up).normalized*orbitalForceMultiplier;
		gameObject.GetComponent<Rigidbody>().AddForce(orbitalForce);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		
	}
}
