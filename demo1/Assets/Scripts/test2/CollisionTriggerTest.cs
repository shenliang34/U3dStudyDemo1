using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTriggerTest : MonoBehaviour {

	// Use this for initialization
	private Move csharp;
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
		if (collider.gameObject.tag == "food")
		{
			Destroy (collider.gameObject);
			csharp = GameObject.Find ("Main Camera").GetComponent<Move>();
			csharp.DestroyObject ();
		}
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
