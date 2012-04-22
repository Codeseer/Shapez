using UnityEngine;
using System.Collections;

/**
 * Attach this to a game object in menu scene for GUI to appear
 */
public class MenuGUI : MonoBehaviour {
	
	public GUISkin skin;
	
	private Vector3 scale;
	private Vector2 location;
	private bool done;
	public int speed = 10;
	// Base all positioning on a 2000-2000 screen it will scale depending on their actual screen.
	void Start () {
		location = new Vector2(Screen.width/2,Screen.height/2);
		done = false;
		skin.button.fontSize = Screen.width/10;
	}
	
	private Vector2 buttonSize;
	void OnGUI () {
		GUI.skin = skin;
		
		GUIContent buttonContent = new GUIContent("Play");
		buttonSize = GUI.skin.button.CalcSize(buttonContent);
		Rect buttonRect = new Rect(location.x-(buttonSize.x/2),location.y-(buttonSize.y/2),buttonSize.x,buttonSize.y);
		
		if(GUI.Button(buttonRect,buttonContent))
		{
			StartCoroutine(playButton());
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator playButton()
	{
		while(!done)
		{
			location.y-=speed;
			if(location.y<-1*buttonSize.y)
			{
				done = true;
			}
			yield return null;
		}
		Application.LoadLevel("game");
	}
}
