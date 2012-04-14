using UnityEngine;
using System.Collections;

public class Diamond : MonoBehaviour {
	
	/****CLASS IS UNFINISHED*****/
	
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
	
	}
}
