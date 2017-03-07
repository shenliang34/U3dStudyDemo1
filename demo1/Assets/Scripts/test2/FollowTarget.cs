using UnityEngine;
using System.Collections.Generic;

public class FollowTarget : MonoBehaviour
{

	// Use this for initialization
	public GameObject target;

    private const float DISTANCE = 2.0f;

    private List<Vector3> posList = new List<Vector3> ();
    
    private List<Quaternion> angleList = new List<Quaternion>();
    //原来的地点
    private Vector3 sourcePos;
    //原来的角度值
    private Quaternion sourceQua;

    //
    private float angleY;
    //
    private float currentAngleY;

    //移动的位置
    private Vector3 movePos;
    //
    private Vector3 offsetVector = new Vector3(0, 0, 6);

    void Start ()
	{
		if (target)
		{
			transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, target.transform.position.z - transform.transform.localScale.z);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
        //transform.position.tran
        if (target)
        {
            //记录
            if (sourcePos == null && sourceQua == null)
            {
                Record();
            }
        }

        //原来的位置不等于null，需要判断是否需要记录该点
        if (sourcePos != null)
        {
            //大于距离的话需要记录
            if (Vector3.Distance(sourcePos, target.transform.position) > DISTANCE)
            {
                Record();
            }
        }
	}

	//update后
	void FixedUpdate()
	{
		if(target)
		{
            angleY = target.transform.eulerAngles.y;
            currentAngleY = Mathf.LerpAngle(currentAngleY, angleY, 0.1f);
            Quaternion rotation = Quaternion.Euler(0, currentAngleY, 0);
            transform.position = target.transform.position - (rotation * offsetVector);
            transform.rotation = rotation;

        }
	}

    //记录
    void Record()
    {
        sourcePos = target.transform.position;
        sourceQua = target.transform.rotation;

        //记录
        RecordPosAngle(sourcePos, sourceQua);
    }

	//记录点跟角度
	void RecordPosAngle(Vector3 pos,Quaternion rotation)
	{
        //记录当前点
        posList.Add (pos);
        angleList.Add(rotation);
	}
}

