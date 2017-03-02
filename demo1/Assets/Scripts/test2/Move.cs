using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	// Use this for initialization
	private GameObject player;

	/**
	 *垂直
	 */
	private const string VERTICAL = "Vertical";

	/**
	 *水平
	 */
	private const string HORIZONTAL = "Horizontal";

	//移动速度
	private float moveSpeed = 50;
	//旋转速度
	private float rotateSpeed = 100;
	//偏移
	private Vector3 offsetVector = new Vector3(0,-8,60);
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
	//小地图制作
	//
	private static readonly float lerpAngleOffset = 0.5f;
	//
	public Texture2D map;
	//
	public Texture2D role;
	//
	public Texture2D target;
	//
	private GameObject plane;
	//
	public float scaleX;
	//
	public float scaleY;
	//
	private float mapRoleX;
	//
	private float mapRoleY;
	//2d地图偏移
	private float mapOffsetX;
	//2d地图偏移
	private float mapOffsetY;
	//宽
	private float wid;
	//高
	private float hei;
	//
	private GameObject OBJ;
	//


	//
	public List<Texture2D> list = new List<Texture2D>();



	void Start () {
		player = GameObject.Find ("player");

		//transform.LookAt (player.transform.position);
		plane = GameObject.Find("plane");

		wid = plane.transform.localScale.x;
		hei = plane.transform.localScale.z;

		scaleX = wid / map.width;
		scaleY = hei / map.height;

		mapOffsetX = Screen.width - map.width + map.width / 2 - (role.width / 2);
		mapOffsetY = map.height / 2 - (role.height / 2);

		//每隔一段时间生成一个物体
		//OBJ = GameObject(Resources.Load("player"));
		//可以直接公开指向
		OBJ = Resources.Load("player") as GameObject;
		InvokeRepeating("CreateFood",0,5);
	}
	
	// Update is called once per frame
	void Update () {
		
		//�û���
		//方向键
		float horizontal = Input.GetAxis (HORIZONTAL);
		float vertical = Input.GetAxis (VERTICAL);

		if (horizontal == 1)
		{
			//Debug.Log ("水平 右边");
			//player.transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
			//围绕自身旋转
			player.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
		} 
		else if (horizontal == -1)
		{
			//Debug.Log ("水平 左边");
			//player.transform.Translate (Vector3.left * Time.deltaTime * moveSpeed);
			//围绕自身旋转
			player.transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);
		}

		if (vertical == 1)
		{
			//Debug.Log ("垂直 上边");

			player.transform.Translate (Vector3.forward * Time.deltaTime * moveSpeed);
		} 
		else if (vertical == -1)
		{
			//Debug.Log ("垂直 下边");
			player.transform.Translate (Vector3.back * Time.deltaTime * moveSpeed);
		}
	}

	void LateUpdate()
	{
		//摄像机跟随人物
		//transform.position = player.transform.position + offsetVector;
		//angleX = player.transform.eulerAngles.x;
		angleY = player.transform.eulerAngles.y;
		//angleZ = player.transform.eulerAngles.z;

		//使用平滑
		//currentAngleX = Mathf.LerpAngle(currentAngleX, angleX, lerpAngleOffset);
		currentAngleY = Mathf.LerpAngle (currentAngleY, angleY, lerpAngleOffset);
		rotation = Quaternion.Euler (0, currentAngleY, 0);

		//设置相机位置
		transform.position = player.transform.position - (rotation * offsetVector);
		//transform.RotateAround (player.transform.position + offsetVector, new Vector3 (20, 0, 0), player.transform.rotation);

		//摄像机对准
		transform.LookAt (player.transform);

		//st = string.Empty;
		//定位位置
		mapRoleX = player.transform.position.x / scaleX + mapOffsetX;
		mapRoleY = player.transform.position.z / scaleY + mapOffsetY;
		//Debug.Log ("x:"+mapRoleX + "Y:" + mapOffsetY);
	}

	void FixedUpdate()
	{
		//float x = player.transform.position.x;
		//float z = player.transform.position.z;
//		if (x >= wid / 2)
//		{
//			x = wid / 2;
//		}
//		if(x <= -wid / 2)
//		{
//			x = -wid /2;
//		}
//		if (z >= hei / 2)
//		{
//			z = hei / 2;
//		}
//		if (z <= -hei / 2)
//		{
//			z = -hei / 2;
//		}

		//player.transform.Translate (new Vector3 (x, player.transform.position.y, z));
	}

	void OnGUI()
	{
		//GUI.sk

		GUI.DrawTexture (new Rect (Screen.width - map.width, 0, map.width, map.height), map);
		GUI.DrawTexture (new Rect (mapRoleX, mapRoleY, role.width, role.height), role);

		//
		GameObject [] objs = GameObject.FindGameObjectsWithTag("food");
		//Debug.Log (objs.Length);
		for (int i = 0; i < objs.Length; i++)
		{
			GameObject obj = objs [i];

			float vx = mapOffsetX + obj.transform.position.x / scaleX;
			float vy = mapOffsetY + obj.transform.position.z / scaleY;

			//Debug.Log ("vx:"+ vx + "vy:" + vy);
			GUI.DrawTexture (new Rect (vx, vy, target.width, target.height), target);
		}
	}

	void CreateFood()
	{
		//Debug.Log ("CreateFood");
		//随机生成不同位置的食物
		float randomX = Random.Range (-wid/2,wid/2);
		float randomZ = Random.Range (-hei/2,hei/2);
		Debug.Log ("随机生成的X:" + randomX + "随机生成的Z:" + randomZ);

		GameObject obj = Instantiate(OBJ);
		obj.transform.position = new Vector3 (randomX,3,randomZ);

	//	Texture2D t;

	}



}
