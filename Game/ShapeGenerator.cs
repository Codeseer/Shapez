using UnityEngine;
using System.Collections;

/**
 * This script should be placed on the main camera.
 * It generates all the shapes in the level
 */
public class ShapeGenerator : MonoBehaviour {
	
	//all of the shapes(prefabs) to generate
	public Cube cubePrefab;
	//public pyramid pyramidPrefab;
	//public diamond diamondPrefab;
	
	public Camera camera;
	private GameData gd;
	
	// Use this for initialization
	void Start () {
		camera = Camera.mainCamera;
		
		if (!gameObject.Equals(Camera.main))
			Debug.LogError("ShapeGenerator.cs is not attached to the main camera!");
		
		gd = GetComponent<GameData>();		
		if(gd!=null)
			Debug.LogError("GameData.cs is not attached to the main camera!");
	}
	
	// Update is called once per frame
	void Update () {
		Instantiate(cubePrefab,getRandomWorldPosition(),transform.rotation);
	}
	
	//keeps track of when shapes should be created
	private bool flagedForCreation(string shapeType) {
		bool returnValue = false;
		switch (shapeType) {
			case "cube":
			break;
		}
		return returnValue;
	}
	
	/**
	 * Random World position based on the screen size.
	 * Z is always far cliping pane.
	*/
	private Vector3 getRandomWorldPosition()
	{
		
		float screenX = Random.Range(camera.pixelWidth/10,camera.pixelWidth-(camera.pixelWidth/10));
		float screenY = Random.Range(camera.pixelWidth/10,camera.pixelHeight-(camera.pixelHeight/10));
		
		return camera.ScreenToWorldPoint(new Vector3(screenX,screenY,camera.farClipPlane));
	}
}
