using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour {
	
	public GUIStyle style;
	
	private Rect rect;
	
	void Start()
	{
		style.fontSize = Screen.height/15;
		Vector2 contentSize = style.CalcSize(new GUIContent(GameData.score.ToString()));
		contentSize *= 1.2f;
		rect = new Rect(contentSize.x,0,Screen.width,contentSize.y);
		StartCoroutine(flyIn());
	}
	
	void OnGUI()
	{
		GUI.Label(rect,GameData.score.ToString(),style);
	}
	
	IEnumerator flyIn()
	{
		while(rect.x>0)
		{
			rect.x--;
			yield return null;
		}
	}
}