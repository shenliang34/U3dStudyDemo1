using UnityEngine;
using System.Collections.Generic;

public class FollowTarget : MonoBehaviour
{

	// Use this for initialization
	public GameObject target;
    public List<Vector3> posList = new List<Vector3>();
    public List<float> angleList = new List<float>();
	void Start ()
	{
		if (target)
		{
            //transform.rotation = target.transform.rotation;
            //float tx = target.transform.position.x;
            //float tz = target.transform.position.z;
            //float sz = target.transform.localScale.z;
            //Quaternion tq = target.transform.rotation;
            //float vx = tx + tx * Mathf.Tan(tq.eulerAngles.y * Mathf.Deg2Rad);
            //float vz = tz + tz * Mathf.Sin(tq.eulerAngles.y * Mathf.Deg2Rad);
            //Debug.Log(vx + "vz" + vz);
            //transform.position = new Vector3 (vx, target.transform.position.y, vz);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
        float tx = target.transform.position.x;
        float sz = target.transform.localScale.z;
        float tz = target.transform.position.z + sz;
        transform.position = new Vector3(tx, target.transform.position.y, tz);
    }

	//
	void FixedUpdate()
	{
        if (target)
        {
             
        }
	}
}

