using UnityEngine;
using System.Collections;

public class GuiCode : MonoBehaviour {
	//var aTexture : Texture;
	public Texture aTexture;
	public int left = 10;
	public int top = 10;
	public int width = 100;
	public int height = 100;

	// Use this for initialization
	void Start () {
	
	}
	
// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		//GUI.Box(new Rect(10,10,100,90),"Cara de poroto");
		if (!aTexture) {
			Debug.LogError("Assign a Texture in the inspector.");
			return;
		}
		GUI.DrawTexture(new Rect(left, top, width, height), aTexture, ScaleMode.StretchToFill, true, 10.0F);
		
	}

}
