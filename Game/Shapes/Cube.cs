using UnityEngine;
using System.Collections;

/**
 * This script should be attached to the cube prefab
 * A cube will fly at the camera and rotate.
 * If it hits the camera it will do dammage
 * On destroy it will scale up and fade out.
*/
public class Cube : MonoBehaviour {
	
	public AnimationCurve acceleration;
	
	public float velocity = 10f;
	
	float _speed;
	//this allows the speed to be set after the cube is initialized
	//in other words allows for acceleration
	private float speed{
		get{return _speed;}
		set{
			_speed = value;
			//update the timeToTarget based on new speed and current position
			float dist = Vector3.Distance(transform.position,Camera.main.transform.position);
			timeToTarget = dist/_speed;
			//reset the timeSinceStart and startPosition so LERP works correctly in the update method
			timeSinceStart = 0f;
			startPosition = transform.position;
		}
	}
	public float rotationX,rotationY,rotationZ;
	
	private Vector3 startPosition;
	
	//variables needed to calculate the new position of the cube in update.
	private float timeSinceStart;
	private float timeToTarget;
	
	//the position of the main camera... easier to just assign it to a variable
	private Vector3 endPosition;
	// Use this for initialization
	void Start () {
		speed = velocity;
		endPosition = Camera.main.transform.position;
	}
	
	
	// Update is called once per frame
	void Update () {
		timeSinceStart += Time.deltaTime;
		timeSinceStart += Time.deltaTime;
		transform.position = getNewPosition();
		spin();
	}
	//make the cube spin
	private void spin(){
		transform.Rotate(Vector3.right * rotationX * Time.deltaTime);
		transform.Rotate(Vector3.down * rotationY * Time.deltaTime);
		transform.Rotate(Vector3.forward * rotationZ * Time.deltaTime);
	}
	
	//new position of the cube
	private Vector3 getNewPosition(){
		float lerp = timeSinceStart/timeToTarget;
		float deltaX = Mathf.Lerp(startPosition.x,endPosition.x,lerp);
		float deltaY = Mathf.Lerp(startPosition.y,endPosition.y,lerp);
		float deltaZ = Mathf.Lerp(startPosition.z,endPosition.z,lerp);
		
		return new Vector3(deltaX,deltaY,deltaZ);
	}
}
