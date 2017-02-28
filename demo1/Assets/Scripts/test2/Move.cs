using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	// Use this for initialization
	private GameObject player;

	//垂直
	private const string VERTICAL = "Vertical";
	//
	private const string HORIZONTAL = "Horizontal";

	//
	private float moveSpeed = 50;
	//
	private float rotateSpeed = 100;
	//
	private Vector3 offsetVector = new Vector3(80,0,0);
	void Start () {
		player = GameObject.Find ("player");

		//transform.LookAt (player.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
		//�û���
		//方向键
		float horizontal = Input.GetAxis (HORIZONTAL);
		float vertical = Input.GetAxis (VERTICAL);

		if (horizontal == 1)
		{
			Debug.Log ("水平 右边");
			//player.transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
			//围绕自身旋转
			player.transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);
		} 
		else if (horizontal == -1)
		{
			Debug.Log ("水平 左边");
			//player.transform.Translate (Vector3.left * Time.deltaTime * moveSpeed);
			//围绕自身旋转
			player.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
		}

		if (vertical == 1)
		{
			Debug.Log ("垂直 上边");

			player.transform.Translate (Vector3.forward * Time.deltaTime * moveSpeed);
		} 
		else if (vertical == -1)
		{
			Debug.Log ("垂直 下边");
			player.transform.Translate (Vector3.back * Time.deltaTime * moveSpeed);
		}

		//摄像机跟随人物
		transform.position = player.transform.position + offsetVector;

		//摄像机对准
		transform.LookAt (player.transform.position);
	}
}
