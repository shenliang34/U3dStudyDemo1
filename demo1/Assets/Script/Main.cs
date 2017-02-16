using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{

	// Use this for initialization
	public int vars = 1;

	public InputField username;
	public InputField password;

	private Text tips;
	void Start ()
	{
		int a, b, c;
		a = 1;
		b = 2;
		c = a + b;
		//Debug.Log (c);

		//Debug.Log(Mathf.Sin(30));

		//GameObject.Find ("");
		//gameObject
		//tips = this.gameObject.GetComponent("tips");
		//用户名
		username = GameObject.Find ("Canvas/username").GetComponent<InputField> ();
		//密码
		password = GameObject.Find ("Canvas/password").GetComponent<InputField> ();
		tips = GameObject.Find("Canvas/tips").GetComponent<Text>();
		//
		tips.text = "";
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Debug.Log (Time.deltaTime);
		//Debug.Log (Time.fixedDeltaTime);
	}

	void OnGUI ()
	{
		
				
	}

	public void onclickbutton()
	{
		Debug.Log ("点击了按钮");
	}

	public void login()
	{
		//gameObject.get
		//
		if (username.text == "123" && password.text == "123")
		{
			Debug.Log ("success");
			tips.text = "success";
			Application.LoadLevel ("unity/level2");
		} 
		else
		{
			Debug.Log ("faild");
			tips.text = "faild";
		}
	}
}
