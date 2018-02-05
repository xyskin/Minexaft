using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
	public Texture2D crosshair;
	
	void Start () {
	
	}
	
	void Update () {
	
	}
	
	void OnGUI() {
        GUI.DrawTexture(new Rect((Screen.width / 2) - 16, (Screen.height / 2) - 16, 32, 32), crosshair, ScaleMode.ScaleToFit, true, 0.0F);
    }
}
