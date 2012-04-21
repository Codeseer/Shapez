using UnityEngine;
using System.Collections;

/**
 * Attach this to a game object in menu scene for GUI to appear
 */
public class MenuGUI : MonoBehaviour {
	
	public GUISkin skin;
	
	private Vector3 scale;
	private Vector2 location;
	private int direction;
	private bool done;
	public int speed = 50;
	// Base all positioning on a 2000-2000 screen it will scale depending on their actual screen.
	void Start () {
		location = new Vector2(1000,1000);
		scale = new Vector3((float)Screen.width / 2000.0f,(float)Screen.height / 2000.0f, 1.0f);
		direction = Random.Range(0,4);
		done = false;
	}
	
	private Vector2 buttonSize;
	void OnGUI () {
		GUI.skin = skin;
		GUI.matrix = Matrix4x4.Scale(scale);
		
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
			switch(direction){
				case 0:
					//up
					location.y-=speed;
					if(location.y<-1*buttonSize.y)
					{
						done = true;
					}
				break;
				case 1:
					//down
					location.y+=speed;
					if(location.y>2000)
					{
						done = true;
					}
				break;
				case 2:
					//right
					location.x+=speed;
					if(location.x>2000)
					{
						done = true;
					}
				break;
				case 3:
					//left
					location.x-=speed;
					if(location.x<-1*buttonSize.x)
					{
						done = true;
					}
				break;
			}
			yield return null;
		}
		Application.LoadLevel("game");
	}
}
