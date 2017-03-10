using UnityEngine;
using System.Collections.Generic;

public class FollowTarget : MonoBehaviour
{

	// Use this for initialization
	public GameObject target;

    private const float DISTANCE = 1f;

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
    private Vector3 currentMovePos;
    //移动的角度信息
    private Quaternion currentRotation;
    //是否获取到下一个移动位置
    private bool isGetNextMovePos;
    //
    private Vector3 offsetVector = new Vector3(0, 0, 5.5f);

    void Start ()
	{
		if (target)
		{
			transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, target.transform.position.z - transform.transform.localScale.z);
		}

        //Debug.Log(currentMovePos.Equals(Vector3.zero));
	}
	
	// Update is called once per frame
	void Update ()
	{
        //transform.position.tran
        if (target)
        {
            //大于距离的话需要记录
            if (Vector3.Distance(sourcePos, target.transform.position) > DISTANCE)
            {
                Record();
            }
        }
	}

    //private 

	//update后
	void FixedUpdate()
	{
		if(target)
		{
            //方法一；
            transform.forward = target.transform.position - transform.position;
            transform.position = target.transform.position - transform.forward * 5.8f;//localSclae + 1;
            //transform.LookAt(target.transform);

            //方法二
            //angleY = target.transform.eulerAngles.y;
            //currentAngleY = Mathf.LerpAngle(currentAngleY, angleY, 0.1f);
            //Quaternion rotation = Quaternion.Euler(0, currentAngleY, 0);
            //transform.position = target.transform.position - (rotation * offsetVector);
            //transform.rotation = rotation;

            //方法三
            //float distance = 0;
            //if (isGetNextMovePos)
            //{
            //    angleY = currentRotation.eulerAngles.y;
            //    currentAngleY = Mathf.LerpAngle(currentAngleY, angleY, 0.1f);
            //    Quaternion rotation = Quaternion.Euler(0, currentAngleY, 0);
            //transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, currentMovePos.x, 1f), transform.position.y, Mathf.MoveTowards(transform.position.z, currentMovePos.z, 1f));
            //transform.rotation = currentRotation;
            //distance = Vector3.Distance(transform.position, currentMovePos);
            //if (distance < 1f)
            //{
            //    isGetNextMovePos = false;

            //    Debug.Log("Move stop");
            //}

            //    Debug.Log("move target" + currentMovePos);
            //}
            //else
            //{
            //    //大于0
            //    if (posList.Count > 0)
            //    {
            //        distance = Vector3.Distance(transform.position, posList[0]);
            //        //if (distance > DISTANCE)
            //        //{
            //        currentMovePos = posList[0];
            //        currentRotation = angleList[0];
            //        isGetNextMovePos = true;
            //        posList.RemoveAt(0);
            //        angleList.RemoveAt(0);

            //        Debug.Log("get pos" + currentMovePos);
            //        //}
            //    }
            //}
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

        Debug.Log("record" + pos);
	}
}

