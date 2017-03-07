using UnityEngine;

using System.Collections;



public class CameraControl : MonoBehaviour
{



	public Camera MainCamera;

	public GameObject MainPerson;

	private int RotationSpeed;

	private int ScaleSpeed;

	private int MouseLeftKey = 0;

	private int MouseRightKey = 1;

	private float MinScaledistance = 30f;

	private float MaxScaledistance = 80f;



	// Use this for initialization

	void Start ()
	{

		RotationSpeed = 50;

		ScaleSpeed = 2;
	}



	// Update is called once per frame

	void Update ()
	{



	}

	void LateUpdate ()
	{

		MouseLeftFunction ();

		MouseRightFunction ();

		MouseCenterFunction ();  

		followFunction ();

		KeyboardFunction ();
	}

	//跟随
	void followFunction()
	{
		//MainCamera.transform.position = MainPerson.transform.position.;
		MainCamera.transform.position = MainPerson.transform.position + new Vector3(0,0,-10);
		MainCamera.transform.LookAt (MainPerson.transform.position);
	}

	void MouseLeftFunction ()
	{

		//鼠标左键

		if (Input.GetMouseButton (MouseLeftKey))
		{

			//MainPerson.transform.localScale(new Vector3(2,2,2));

			float distanceX = Input.GetAxis ("Mouse X") * RotationSpeed;
			float distanceY = Input.GetAxis ("Mouse Y") * RotationSpeed;

			MainCamera.transform.RotateAround (MainPerson.transform.position, Vector3.up, distanceX * Time.deltaTime);
			MainCamera.transform.RotateAround (MainPerson.transform.position, Vector3.right, distanceY * Time.deltaTime);
		}

	}

	void MouseRightFunction ()
	{

		//鼠标右键

		if (Input.GetMouseButton (MouseRightKey))
		{

			float distanceX = Input.GetAxis ("Mouse X") * RotationSpeed;

			MainCamera.transform.RotateAround (MainPerson.transform.position, Vector3.up, distanceX * Time.deltaTime);
		}

	}

	void MouseCenterFunction ()
	{

		//鼠标中间滚轮向前滚动
		if (Input.GetAxis ("Mouse ScrollWheel") < 0)
		{

			float CurrentDistance = MainCamera.fieldOfView;



			CurrentDistance += ScaleSpeed;

			if (CurrentDistance > MaxScaledistance)
				MainCamera.fieldOfView = MaxScaledistance;
			else
				MainCamera.fieldOfView = CurrentDistance;
		}

		//鼠标中间滚轮向后滚动

		if (Input.GetAxis ("Mouse ScrollWheel") > 0)
		{

			float CurrentDistance = MainCamera.fieldOfView;

			CurrentDistance -= ScaleSpeed;

			if (CurrentDistance < MinScaledistance)
				MainCamera.fieldOfView = MinScaledistance;
			else
				MainCamera.fieldOfView = CurrentDistance;
		}
	}

	void KeyboardFunction()
	{
		float h = Input.GetAxis ("Horizontal");
		if (h == 1)
		{
			Debug.Log ("水平1");
		} else if (h == -1)
		{
			Debug.Log ("水平-1");
		}

		float v = Input.GetAxis ("Vertical");
		if (v == 1)
		{
			Debug.Log ("垂直1");
		} else if (v == -1)
		{
			Debug.Log ("垂直-1");
		}
	}

}