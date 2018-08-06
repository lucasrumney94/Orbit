using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyRandomForceOnSpawn : MonoBehaviour {

	public float minForce = 1.0f;
	public float maxForce = 1.0f;
	


	// Use this for initialization
	void Start () 
	{
		gameObject.GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere*Random.Range(minForce, maxForce), ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
