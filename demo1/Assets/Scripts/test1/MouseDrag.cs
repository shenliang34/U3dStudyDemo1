using UnityEngine;
using System.Collections;

public class MouseDrag : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnMouseDrag()
	{
		Debug.Log ("鼠标拖动该模型区域时");
	}

	void OnMouseDown()
	{
		Debug.Log ("鼠标按下");
	}

	void OnMouseUp()
	{
		Debug .Log("鼠标抬起");
	}

	void OnMouseEnter()
	{
		Debug.Log ("鼠标进入该区域");
	}

	void OnMouseExit()
	{
		Debug.Log ("鼠标移出");
	}

	void OnMouseOver()
	{
		Debug.Log ("鼠标留在该区域Over");
	}

}

