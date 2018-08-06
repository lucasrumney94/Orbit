using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomBodies : MonoBehaviour {

	public GameObject Body;
	public int NumBodiesToSpawn = 30;
	public float spawnRadius = 100;

	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < NumBodiesToSpawn; i++)
		{
			Instantiate(Body, Random.insideUnitSphere*spawnRadius, Random.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
