using UnityEngine;
using System.Collections;

public class HealthLoss : MonoBehaviour {
	
	public GUIStyle style;
	public Rect rect;
	public float fadeOutTime = 1f;
	// Use this for initialization
	private float timeSinceStart;
	void Start () {
		timeSinceStart = 0f;
	}
	
	void OnGUI() {
		timeSinceStart += Time.deltaTime;
		GUI.Box(rect,"",style);
		if(fadeOutTime<timeSinceStart)
			Destroy(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
