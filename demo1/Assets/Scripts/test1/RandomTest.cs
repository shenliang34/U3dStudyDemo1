using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTest : MonoBehaviour {

	// Use this for initialization
	private ArrayList arr = new ArrayList();
	void Start () {
		while (arr.Count < 30)
		{
			int ran = Random.Range (1, 34);
			if (arr.IndexOf (ran) < 0)
			{
				arr.Add (ran);
			}
		}
		arr.Sort ();
		foreach (int s in arr)
		{
			Debug.Log (s);	
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		//�û���
	}
}
