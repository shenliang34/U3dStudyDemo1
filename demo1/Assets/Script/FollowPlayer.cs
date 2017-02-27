using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{

	// Use this for initialization

	private GameObject obj;

	private Vector3 offset;
	void Start ()
	{
		//obj = GameObject.Find ("");
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Vector3 pos = offset + obj.transform.position;
		//transform.position = pos;
	}

	//
//	void Awake()
//	{
		//摄像机指向物体
		//transform.LookAt (obj.transform.position);
		//
		//offset = transform.position - obj.transform.position;
//	}
}

