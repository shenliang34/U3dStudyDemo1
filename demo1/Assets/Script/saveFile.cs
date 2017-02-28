using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class saveFile : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		//存
		string fileName = "newFile.txt";
		string path = Application.dataPath;
		//CreateFile (path,fileName,"shenliangliang");

		//取
		ArrayList info = LoadFile(path,fileName);
		if (info != null)
		{
			//打印
			foreach (string line in info)
			{
				Debug.Log (line);
			}

			Debug.Log (info.Count);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnGUI()
	{
		if (GUI.Button (new Rect (100, 100, 100, 100), "截取屏幕"))
		{
			Application.CaptureScreenshot ("cap.png");
		}
	}
		//加载文件
	ArrayList LoadFile(string path,string fileName)
	{
		//
		StreamReader sr;
		try{
			sr = File.OpenText(path + "//" + fileName);
		}
		catch(Exception e){
			Debug.Log (e.Message);
			return null;
		}

		string line;
		ArrayList arrlist = new ArrayList ();
		while ((line = sr.ReadLine ()) != null)
		{
			//加入列表中
			arrlist.Add(line);
		}
		//关闭
		sr.Close();
		sr.Dispose ();
		return arrlist;

	}

	//
	void CreateFile(string path,string fileName,string content)
	{
		//文件流信息
		StreamWriter sw;
		//
		FileInfo fi = new FileInfo(path + "//" + fileName);
		if (!fi.Exists)
		{
			//不存在创建
			sw = fi.CreateText ();
		} else
		{
			//打开文件
			sw = fi.AppendText ();
		}

		sw.Write ("fa");
		sw.Close ();
		sw.Dispose ();
	}
}

