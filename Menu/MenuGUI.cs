using UnityEngine;
using System.Collections;

/**
 * Attach this to a game object in menu scene for GUI to appear
 */
public class MenuGUI : MonoBehaviour {
	
	public GUISkin skin;
	public int speed = 10;
	
	private Vector3 scale;
	private Vector2 location;
	private Vector2 buttonSize;
	private bool done;
	
	void Start() 
	{
		location = new Vector2(Screen.width/2,Screen.height/2);
		done = false;
		skin.button.fontSize = Screen.width/10;
	}
	
	
	void OnGUI()
	{
		GUI.skin = skin;
		
		GUIContent buttonContent = new GUIContent("Play");
		buttonSize = GUI.skin.button.CalcSize(buttonContent);
		Rect buttonRect = new Rect(location.x-(buttonSize.x/2),location.y-(buttonSize.y/2),buttonSize.x,buttonSize.y);
		
		if(GUI.Button(buttonRect,buttonContent))
		{
			StartCoroutine(playButton());
		}
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
