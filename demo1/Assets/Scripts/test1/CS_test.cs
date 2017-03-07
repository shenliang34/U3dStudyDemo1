using UnityEngine;
using System.Collections;

public class CS_test : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnGUI()
	{
		if (GUI.Button (new Rect (100, 200, 200, 100), "C#调用JS"))
		{
			
			//js.CallMe ("我来自C#");
			//Mathf.Abs(-1);
			//Debug.Log(Mathf.Round (10));
		}
	}

	void CallMe(string str)
	{
		Debug.Log (str);
	}
}

