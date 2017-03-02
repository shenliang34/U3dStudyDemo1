using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTriggerTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("start");
	}
	
	// Update is called once per frame
	void Update () {
		
		//
	}

	void Awake(){
		Debug.Log ("Awake");
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log (collision.gameObject.tag);
	}

	void OnCollisionStay(Collision collision)
	{
		//Debug.Log ("stay");
	}

	//碰撞
	void OnCollisionExit(Collision collision)
	{
		Debug.Log ("exit");
	}

	//触发器进入
	void OnTriggerEnter(Collider collider)
	{
		Debug.Log ("Trigger Enter");
		Destroy (collider.gameObject);
	}

	//触发器停留
	void OnTriggerStay(Collider collider)
	{
		Debug.Log ("Trigger Stay");
	}

	//触发器退出
	void OnTriggerExit(Collider collider)
	{
		Debug.Log ("Trigger Exit");
	}
}
