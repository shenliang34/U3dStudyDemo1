using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureTs : MonoBehaviour {

    // Use this for initialization
    public Vector3 toward;
    //移动的时间
    private float delays;
	void Start () {

        delays = Random.Range(2.0f,4.0f);
		//开始函数
	}
	
	// Update is called once per frame
	void Update () {

        //更新函数

        transform.position = Vector3.MoveTowards(transform.position,toward,delays);
	}
}
