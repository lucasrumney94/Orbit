using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalAttraction : MonoBehaviour {

	public float attractionRadius = 2;
    public float attractionMultiplier = 1;
 

	private Vector3 forceDirection;

	public void FixedUpdate()
	{
		foreach (Collider collider in Physics.OverlapSphere(transform.position, attractionRadius)) 
		{
			// calculate direction from target to me
			forceDirection = new Vector3((transform.position.x-collider.transform.position.x),
										(transform.position.y-collider.transform.position.y),
										(transform.position.z-collider.transform.position.z));

			forceDirection.x = Mathf.Sign(forceDirection.x)*forceDirection.x*forceDirection.x;
			forceDirection.y = Mathf.Sign(forceDirection.y)*forceDirection.y*forceDirection.y;
			forceDirection.z = Mathf.Sign(forceDirection.z)*forceDirection.z*forceDirection.z;
			
			Debug.DrawRay(collider.transform.position, forceDirection, Color.red);							
			//(transform.position - collider.transform.position);
	

			// apply force on target towards me
			collider.GetComponent<Rigidbody>().AddForce(forceDirection * attractionMultiplier * Time.fixedDeltaTime);
		}
	}
}
