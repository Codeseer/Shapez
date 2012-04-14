using UnityEngine;
using System.Collections;

/**
 * This script should be placed on the main camera.
 * It generates all the shapes in the level
 */
public class ShapeGenerator : MonoBehaviour {
	
	//all of the shapes(prefabs) to generate
	public Cube cubePrefab;
	public Pyramid pyramidPrefab;
	//public diamond diamondPrefab;
	
	private Camera camera;
	
	// Use this for initialization
	void Start () {
		camera = Camera.mainCamera;	
	}
	
	// Update is called once per frame
	void Update () {
		float rnd = Random.value;
		if (rnd < .2f)
		{
			Instantiate(cubePrefab, getRandomFarPlanePosition(), transform.rotation);
		}
		else if (rnd < .4f)
		{
			Instantiate(pyramidPrefab, getRandomFarPlanePosition(), transform.rotation);
		}
		else {
			
		}
	}
	
	//keeps track of when shapes should be created
	private bool flagedForCreation(string shapeType) {
		bool returnValue = false;
		switch (shapeType) {
			case "cone":
			break;
			case "cube":
			break;
			case "cylinder":
			break;
			case "diamond":
			break;
			case "pyramid":
			break;
			case "sphere":
			break;
			case "torus":
			break;		
		}
		return returnValue;
	}
	
	/**
	 * Random World position based on the screen size.
	 * Z is always far cliping pane.
	 */
	private Vector3 getRandomFarPlanePosition()
	{
		
		float screenX = Random.Range(camera.pixelWidth/10,camera.pixelWidth-(camera.pixelWidth/10));
		float screenY = Random.Range(camera.pixelWidth/10,camera.pixelHeight-(camera.pixelHeight/10));
		
		return camera.ScreenToWorldPoint(new Vector3(screenX,screenY,camera.farClipPlane));
	}
	
	private Vector3 getRandomSidePlanePosition()
	{
		float rnd1 = Mathf.Sign(Random.Range(-1, 1));
		rnd1 = rnd1 == 0 ? 1 : rnd1;
		float rnd2 = Mathf.Sign(Random.Range(-1, 1));
		rnd2 = rnd2 == 0 ? 1 : rnd2;
		
		float dist = Random.Range(camera.farClipPlane / 5, camera.farClipPlane * 4 / 5);
		float xPos = Mathf.Sin(camera.aspect / 2) * dist * rnd1;
		float yPos = Mathf.Cos(camera.aspect / 2) * dist * rnd2;
		
		return new Vector3(xPos, yPos, dist);
	}
}
