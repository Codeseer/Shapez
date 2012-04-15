using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour {
	
	public GUIStyle style;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnGUI() {
		GUI.Label(new Rect(0,0,Screen.width,64),GameData.score.ToString(),style);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
