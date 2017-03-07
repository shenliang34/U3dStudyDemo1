using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		//数据保存
		//PlayerPrefs.SetString ("name", "shenliangliang");
		//string myName = PlayerPrefs.GetString ("name");
		//Debug.Log (myName);
		//PlayerPrefs.DeleteKey ("name");
	}
	
	// Update is called once per frame
	void Update () {
		//键盘控制
		float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");
		if (vertical == -1)
		{
			Debug.Log ("左边");
		} else if (vertical == 1)
		{
			Debug.Log ("右边");
		}
		if (horizontal == 1)
		{
			Debug.Log ("左边");
		} else if (horizontal == -1)
		{
			Debug.Log ("右边");
		}
		//Debug.Log (vertical + "Horizontal" +horizontal);
	}
}
