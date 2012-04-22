using UnityEngine;
using System.Collections;

/**
 * This script should be attached to the cube prefab
 * A cube will fly at the camera and rotate.
 * If it hits the camera it will do dammage
 * On destroy it will scale up and fade out.
*/
public class Cube : MonoBehaviour {
	
	public float initialSpeed = 10f;
	public float heightFactor = 10f;
	public float rotationX,rotationY,rotationZ;
	
	private Vector3 startPosition;
	
	private float timeSinceStart; 	// variables needed to calculate 
	private float timeToTarget;		// the new position of the pyramid in update.
	
	private Transform t;	// cache built-in transform variable for performance
	
	float _speed;
	//this allows the speed to be set after the cube is initialized
	//in other words allows for acceleration
	private float speed{
		get{return _speed;}
		set{
			_speed = value;
			//update the timeToTarget based on new speed and current position
			float dist = Vector3.Distance(t.position, GameData.convergencePoint);
			timeToTarget = dist/_speed;
			//reset the timeSinceStart and startPosition so LERP works correctly in the update method
			timeSinceStart = 0f;
			startPosition = t.position;
		}
	}
	
	// Use this for initialization
	void Start () {
		t = transform;
		speed = initialSpeed;
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
	
	//make the cube spin
	private void spin(){
		t.Rotate(Vector3.right * rotationX * Time.deltaTime);
		t.Rotate(Vector3.down * rotationY * Time.deltaTime);
		t.Rotate(Vector3.forward * rotationZ * Time.deltaTime);
		
	}
	
	// new position of the pyramid
	private Vector3 getNewPosition(){
		float lerp = timeSinceStart / timeToTarget;
		float deltaX = Mathf.Lerp(startPosition.x, GameData.convergencePoint.x, lerp);
		float deltaY = Mathf.Lerp(startPosition.y, GameData.convergencePoint.y, lerp);
		float deltaZ = Mathf.Lerp(startPosition.z, GameData.convergencePoint.z, lerp);
		
		return new Vector3(deltaX, deltaY, deltaZ);
	}
}
