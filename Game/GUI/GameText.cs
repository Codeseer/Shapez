using UnityEngine;
using System.Collections;

/**
 * Attach this script to a GameObject
 * Draws a Label to the screen that can fade out/in
 * And move.
 */
public class GameText : MonoBehaviour {

	public Rect rect;
	public string text;
	public GUIStyle style;
	
	public Vector2 fadeVelocity;
	public float fadeDuration;
	
	public AnimationCurve fadeAlphaAcceleration;
	public AnimationCurve fadeXAcceleration;
	public AnimationCurve fadeYAcceleration;
	
	private Color c;
	private float timeSinceStart;
	// Use this for initialization
	void Start () {
		c = GUI.color;
		timeSinceStart = 0f;
		fadeVelocity *= 10;
		StartCoroutine(fadeOut());
	}
	
	void OnGUI() {
		GUI.color = c;
		GUI.Label(rect,text,style);
	}
	
	IEnumerator fadeOut(){
		while(timeSinceStart<fadeDuration) {
			c.a = fadeAlphaAcceleration.Evaluate(timeSinceStart/fadeDuration);			
			
			rect.x += fadeVelocity.x * fadeXAcceleration.Evaluate(timeSinceStart/fadeDuration) * Time.deltaTime;
			rect.y += fadeVelocity.y * fadeYAcceleration.Evaluate(timeSinceStart/fadeDuration) * Time.deltaTime;
			
			yield return null;
		}
		Destroy(this);
	}
	// Update is called once per frame
	void Update () {
		timeSinceStart += Time.deltaTime;
	}
}
