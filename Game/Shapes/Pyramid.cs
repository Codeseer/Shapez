using UnityEngine;
using System.Collections;

public class Pyramid : MonoBehaviour {
	
	public float initialSpeed = 10f;
	public float heightFactor = 10f;
	public float rotationX,rotationY,rotationZ;
	
	private Vector3 startPosition;
	
	private float timeSinceStart; 	// variables needed to calculate 
	private float timeToTarget;		// the new position of the pyramid in update.
	
	private Transform t;	// cache built-in transform variable for performance
	
	private float speed; // allows speed to be set after the pyramid is initialized
	
	// Use this for initialization
	void Start () {
		t = transform;
		speed = initialSpeed;
		
		float dist = Vector3.Distance(t.position, GameData.convergencePoint);
		timeToTarget = dist / speed;
			
		timeSinceStart = 0f; // reset timeSinceStart/startPosition so LERP works correctly in the update method
		startPosition = t.position;
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceStart += Time.deltaTime;
		t.position = getNewPosition();
		spin();
		
		if ((t.position - GameData.convergencePoint).magnitude < 2)
		{
			Destroy(gameObject);
		}
	}
	// make the pyramid spin
	private void spin(){
		t.Rotate(Vector3.right * rotationX * Time.deltaTime);
		t.Rotate(Vector3.down * rotationY * Time.deltaTime);
		t.Rotate(Vector3.forward * rotationZ * Time.deltaTime);
		
	}
	
	// new position of the pyramid
	private Vector3 getNewPosition(){
		float lerp = timeSinceStart / timeToTarget;
		float deltaX = Mathf.Lerp(startPosition.x, GameData.convergencePoint.x, lerp);
		float deltaY = Mathf.Lerp(startPosition.y, GameData.convergencePoint.y, lerp) + heightFactor * (1 - lerp) * Mathf.Sin(timeSinceStart);
		float deltaZ = Mathf.Lerp(startPosition.z, GameData.convergencePoint.z, lerp);
		
		return new Vector3(deltaX, deltaY, deltaZ);
	}
}
