using UnityEngine;
using System.Collections;

/**
 * Attach this script to a GameObject
 * Draws a Label to the screen that can fade out/in
 * And move. And Scale
 */
public class GameText : MonoBehaviour {
	
	public string text = "Game Text";
	public Vector2 location;
	public GUIStyle style;
	
	
		private Rect _rect;
	public Rect rect{
		get{ return _rect;}
	}
	
	public bool fade = false;
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
		Vector2 rectSize = style.CalcSize(new GUIContent(text));
		_rect = new Rect(location.x,location.y,rectSize.x,rectSize.y);		
		//fixes an ofset that occurs with text
		_rect.width*=1.2f;
		
		timeSinceStart = 0f;
		fadeVelocity *= 10;
		if(fade)
		{
			StartCoroutine(fadeOut());
		}
	}
	
	void OnGUI() {
		_rect.x = location.x;
		_rect.y = location.y;
		
		GUI.color = c;
		GUI.matrix = scaleMatrix;
		GUI.Label(_rect,text,style);
	}
	
	IEnumerator fadeOut(){
		while(timeSinceStart<fadeDuration) {
			c.a = fadeAlphaAcceleration.Evaluate(timeSinceStart/fadeDuration);			
			
			_rect.x += fadeVelocity.x * fadeXAcceleration.Evaluate(timeSinceStart/fadeDuration) * Time.deltaTime;
			_rect.y += fadeVelocity.y * fadeYAcceleration.Evaluate(timeSinceStart/fadeDuration) * Time.deltaTime;
			
			float scaleX = scaleXChange.Evaluate(timeSinceStart/fadeDuration)/2;
			float scaleY = scaleYChange.Evaluate(timeSinceStart/fadeDuration)/2;
			
			float sCX = ((1-scaleX)*_rect.width)/2;
			float sCY = ((1-scaleY)*_rect.height)/2;
			
			float sOX = (1-scaleX)*_rect.x;
			float sOY = (1-scaleY)*_rect.y;
			
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
