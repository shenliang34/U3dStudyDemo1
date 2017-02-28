using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("start");
	}
	
	// Update is called once per frame
	void Update () {
		
		//�û���
	}

	void Awake(){
		Debug.Log ("Awake");
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("ff");
	}

	void OnCollisionStay(Collision collision)
	{
		Debug.Log ("stay");
	}

	void OnCollisionExit(Collision collision)
	{
		Debug.Log ("exit");
	}
}
