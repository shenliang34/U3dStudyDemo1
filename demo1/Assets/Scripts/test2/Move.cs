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

	//移动速度
	private float moveSpeed = 50;
	//旋转速度
	private float rotateSpeed = 100;
	//偏移
	private Vector3 offsetVector = new Vector3(0,-10,80);
	//角度
	public Quaternion rotation;
	//角度x
	public float angleX;
	//角度y
	public float angleY;
	//角度z
	public float angleZ;
	//
	public float currentAngleX ;
	//
	public float currentAngleY ;

	//
	private static readonly float lerpAngleOffset = 0.5f;

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
			player.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
		} 
		else if (horizontal == -1)
		{
			Debug.Log ("水平 左边");
			//player.transform.Translate (Vector3.left * Time.deltaTime * moveSpeed);
			//围绕自身旋转
			player.transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);
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
	}

	void LateUpdate()
	{
		//摄像机跟随人物
		//transform.position = player.transform.position + offsetVector;
		angleX = player.transform.eulerAngles.x;
		angleY = player.transform.eulerAngles.y;
		angleZ = player.transform.eulerAngles.z;

		//使用平滑
		currentAngleX = Mathf.LerpAngle(currentAngleX, angleX, lerpAngleOffset);
		currentAngleY = Mathf.LerpAngle (currentAngleY, angleY, lerpAngleOffset);
		rotation = Quaternion.Euler (currentAngleX, currentAngleY, 0);

		//设置相机位置
		transform.position = player.transform.position - (rotation * offsetVector);
		//transform.RotateAround (player.transform.position + offsetVector, new Vector3 (20, 0, 0), player.transform.rotation);

		//摄像机对准
		transform.LookAt (player.transform);

		//st = string.Empty;
	}
}
