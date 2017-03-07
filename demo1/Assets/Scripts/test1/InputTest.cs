using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//�û���

		if (Input.GetMouseButton (0))
		{
			Debug.Log ("down");
		}
	}
}
