using System.Collections.Generic;
using UnityEngine;


public class GameResourceManager
{
	//字典
	private Dictionary<string,GameObject> gameObjDic;
	public GameResourceManager ()
	{
		gameObjDic = new Dictionary<string, GameObject> ();
	}

	//避免重复加载资源
	public GameObject LoadResource(string path)
	{
		if (!gameObjDic.ContainsKey (path))
		{
			gameObjDic [path] = Resources.Load<GameObject> (path);
		}

		if (gameObjDic [path] == null)
		{
			return null;
		}
		return GameObject.Instantiate (gameObjDic[path]);
	}

	//移出资源
	public bool removeResource()
	{
//		Resources.UnloadAsset
		return false;
	}
}


