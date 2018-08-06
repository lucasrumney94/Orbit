using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomBodies : MonoBehaviour {

	public GameObject Body;
	public int NumBodiesToSpawn = 30;
	public float spawnRadius = 100;
	public float accretionDiskFlattenFactor = 1.0f;

	public List<GameObject> bodies;


	private Vector3 spawnPosition;

	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < NumBodiesToSpawn; i++)
		{
			spawnPosition = Random.insideUnitSphere*spawnRadius;
			spawnPosition.y /= accretionDiskFlattenFactor;

			GameObject g = Instantiate(Body, spawnPosition, Random.rotation) as GameObject;
			g.transform.parent = gameObject.transform;
			g.GetComponent<Rigidbody>().AddForce(accretionDiskFlattenFactor, 0, accretionDiskFlattenFactor);
			bodies.Add(g);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
