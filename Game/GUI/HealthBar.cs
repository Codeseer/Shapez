using UnityEngine;
using System.Collections;

/**
 * Manages the size and position of the health bar
 */
public class HealthBar : MonoBehaviour {
	
	public GUIStyle foreground;
	public GUIStyle background;
	public HealthLoss healthLossPrefab;
	public int height = (int)(Screen.height/20);
	
	private float screenToHealthRatio;
	private float lastKnownHelath;
	private Rect rect;
	// Use this for initialization
	void Start () {
		lastKnownHelath = GameData.health;
		screenToHealthRatio = (float)Screen.width/(float)GameData.maxHealth;
		rect = new Rect(0,Screen.height,GameData.health * screenToHealthRatio,height);
		StartCoroutine(flyIn());
	}
	
	void OnGUI() {
		if(GameData.health<lastKnownHelath)
		{
			healthLossPrefab.rect = new Rect(GameData.health * screenToHealthRatio,Screen.height-height,(lastKnownHelath-GameData.health) * screenToHealthRatio,16);
			Instantiate(healthLossPrefab);
			lastKnownHelath = GameData.health;
		}
		//GUI.Box(new Rect(0,Screen.height-16,Screen.width,16),"",background);
		rect.width = GameData.health * screenToHealthRatio;
		GUI.Box(rect,"",foreground);
	}
	// Update is called once per frame
	void Update () {
	}
	
	IEnumerator flyIn()
	{
		while(rect.y>=Screen.height-height)
		{
			rect.y -=1;
			yield return true;
		}
	}
}
