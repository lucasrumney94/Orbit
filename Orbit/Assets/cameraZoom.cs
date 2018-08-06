using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraZoom : MonoBehaviour {

	public Transform Sun;
	private Transform farthestBody;

	public SpawnRandomBodies spawner;


	private const float DISTANCE_MARGIN = 10.0f;


	private Vector3 middlePoint;
	private float distanceFromMiddlePoint;
	private float distanceBetweenPlayers;
	private float cameraDistance;
	private float aspectRatio;
	private float fov;
	private float tanFov;

	void Start() {
		aspectRatio = Screen.width / Screen.height;
		tanFov = Mathf.Tan(Mathf.Deg2Rad * Camera.main.fieldOfView / 2.0f);
	}

	void Update () {
		// Position the camera in the center.
		Vector3 newCameraPos = Camera.main.transform.position;
		newCameraPos.x = middlePoint.x;
		Camera.main.transform.position = newCameraPos;

		
		float maxDistance = 0.0f;
		foreach (GameObject body in spawner.bodies)
		{
			float myDistance = Vector3.Distance(body.transform.position, Sun.position);
			if (myDistance > maxDistance)
			{
				farthestBody = body.transform;
				maxDistance = myDistance;
			}
		}


		// Find the middle point between players.
		Vector3 vectorBetweenPlayers = farthestBody.position - Sun.position;
		middlePoint = Sun.position + 0.5f * vectorBetweenPlayers;

		// Calculate the new distance.
		distanceBetweenPlayers = vectorBetweenPlayers.magnitude;
		cameraDistance = (distanceBetweenPlayers / 2.0f / aspectRatio) / tanFov;

		// Set camera to new position.
		Vector3 dir = (Camera.main.transform.position - middlePoint).normalized;
		Camera.main.transform.position = middlePoint + dir * (cameraDistance + DISTANCE_MARGIN);
	}
}
