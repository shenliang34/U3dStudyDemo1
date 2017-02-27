using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GUILayoutTest : MonoBehaviour {

	// Use this for initialization
	private GameObject obj;
	void Start () {
		obj = GameObject.Find ("object");
		GameObject o = GameObject.CreatePrimitive (PrimitiveType.Cube);
		//o.AddComponent (Rigidbody);
		o.name = "cucucu";
		o.AddComponent<Main> ();
		//Destroy (this);
	}
	
	// Update is called once per frame
	void Update () {
		
		//�û���
	}

	void OnGUI()
	{
		//GUILayout.BeginArea(new Rect(0,0,Screen.width,Screen.height));
		//Debug.Log(Screen.width + " height "+ Screen.height + "");
		GUILayout.BeginArea (new Rect(10,10,200,100));

		GUILayout.EndArea ();
	}
}
