using UnityEngine;
using System.Collections;

/**
 * Attach this script to a GameObject
 * Draws a Label to the screen that can fade out/in
 * And move. And Scale
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
	public AnimationCurve scaleXChange;
	public AnimationCurve scaleYChange;
	
	private Color c;
	private float timeSinceStart;
	private Matrix4x4 scaleMatrix;
	// Use this for initialization
	void Start () {
		c = GUI.color;
		scaleMatrix = GUI.matrix;
		
		timeSinceStart = 0f;
		fadeVelocity *= 10;
		
		StartCoroutine(fadeOut());
		Vector2 rectSize = style.CalcSize(new GUIContent(text));
		rect.width = rectSize.x;
		rect.height = rectSize.y;
	}
	
	void OnGUI() {
		GUI.color = c;
		GUI.matrix = scaleMatrix;
		GUI.Label(rect,text,style);
	}
	
	IEnumerator fadeOut(){
		while(timeSinceStart<fadeDuration) {
			c.a = fadeAlphaAcceleration.Evaluate(timeSinceStart/fadeDuration);			
			
			rect.x += fadeVelocity.x * fadeXAcceleration.Evaluate(timeSinceStart/fadeDuration) * Time.deltaTime;
			rect.y += fadeVelocity.y * fadeYAcceleration.Evaluate(timeSinceStart/fadeDuration) * Time.deltaTime;
			
			float scaleX = scaleXChange.Evaluate(timeSinceStart/fadeDuration)/2;
			float scaleY = scaleYChange.Evaluate(timeSinceStart/fadeDuration)/2;
			
			float sCX = ((1-scaleX)*rect.width)/2;
			float sCY = ((1-scaleY)*rect.height)/2;
			
			float sOX = (1-scaleX)*rect.x;
			float sOY = (1-scaleY)*rect.y;
			
			Vector3 tOffset = new Vector3(sOX+sCX,sOY+sCY,0f);
			
			scaleMatrix = Matrix4x4.TRS(tOffset,Quaternion.identity,new Vector3(scaleX,scaleY,1));
			yield return null;
		}
		Destroy(this);
	}
	// Update is called once per frame
	void Update () {
		timeSinceStart += Time.deltaTime;
	}
}
