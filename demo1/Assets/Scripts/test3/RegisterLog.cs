using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterLog : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		//开始函数
	}
	
	// Update is called once per frame
	void Update () {
		
		//更新函数
	}

    private void OnEnable()
    {
        //Application.logMessageReceived()
        // Application.RegisterLogCallback(MyRegisterLog);
        Debug.Log("OnEnable");
    }

    private void MyRegisterLog(string condition, string stackTrace, LogType type)
    {
        Debug.Log(condition);
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    public void click()
    {
        Debug.Log("click");
        print("fa");
    }

}
