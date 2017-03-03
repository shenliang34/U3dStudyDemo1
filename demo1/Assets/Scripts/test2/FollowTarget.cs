using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowTarget : MonoBehaviour
{

	// Use this for initialization
	public GameObject target;
	private List<Vector3> pos = new List<Vector3> ();
	void Start ()
	{
		if (target)
		{
			//transform.position = new Vector3 (target.transform.position.x + transform.transform.localScale.x, target.transform.position.y, target.transform.position.z);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	//
	void FixedUpdate()
	{
		if(target)
		{
			if (pos.Count > 0)
			{

				if (Vector3.Distance (transform.position, pos [0]) < 5.0f)
				{
					//到了目的地
					pos.RemoveAt(0);
				} 
				else
				{
					if (Vector3.Distance (transform.position, pos [pos.Count - 1]) > 5.0f)
					{
						//距离大于了可以记录的值记录下来
						RecordPos ();
					}
					//移动
					transform.Translate(pos[0]);
				}
			} 
			else
			{
				if (Vector3.Distance (transform.position, target.transform.position) > 5.0f)
				{
					RecordPos ();
				}
			}
		}
	}

	void RecordPos()
	{
		//记录当前点
		pos.Add (target.transform.position);
	}
}

