using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		//开始函数
	}
	
	// Update is called once per frame
	void Update () {
		
		//更新函数
	}

	public void StartGameFunc()
	{
		//waitStartForSeconds ();

		//加载游戏
		SceneManager.LoadScene ("level3");
	}

	IEnumerator waitStartForSeconds()
	{
		yield return new WaitForSeconds (1.0f);

		//加载游戏
		SceneManager.LoadScene ("level3");
	}
}
