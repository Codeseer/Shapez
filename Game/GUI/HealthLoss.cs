using UnityEngine;
using System.Collections;

public class HealthLoss : MonoBehaviour {
	
	public GUIStyle style;
	public Rect rect;
	public float fadeOutTime = 1f;
	
	private Color color;
	// Use this for initialization
	private float timeSinceStart;
	void Start () {
		timeSinceStart = 0f;
		color = Color.white;		
		StartCoroutine(fadeOut());		
	}
	
	void OnGUI() {
		GUI.color = color;
		GUI.Label(rect,"",style);
	}
	
	IEnumerator fadeOut() {
		while(timeSinceStart<fadeOutTime) {
			color.a = Mathf.Lerp(1,0,timeSinceStart/fadeOutTime);
			yield return null;
		}
		Destroy(this);
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceStart += Time.deltaTime;
	}
}
