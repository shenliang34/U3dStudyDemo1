using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureSub : MonoBehaviour {

    // Use this for initialization

    Texture2D td = null;
    Texture2D txtbg;
    int txtw, txth;
    string mySavePath;
    string showTxt;
    Color[] myColors;
    int _w, _h;
    int step = 0;
    public GameObject go;
    GameObject[] gos;
    int gosMax;
    int gosCur = 0;
    bool[,] isShow;
	void Start () {

        //开始函数
        txtw = 200;
        txth = 80;
        _w = txtw;
        _h = txth;
        _w -= 5;
        _h -= 5;
        txtbg = new Texture2D(txtw, txth);
        Color[] tdc = new Color[txtw * txth];
        for (int i = 0; i < txth * txtw; i++)
        {
            tdc[i] = Color.white;
        }

        showTxt = "哈哈哈";

        txtbg.SetPixels(0, 0, txtw, txth, tdc);
        isShow = new bool[_h, _w];
        gosMax = _w * _h / 3;
        gos = new GameObject[gosMax];
        for (int i = 0; i < gosMax; i++)
        {
            gos[i] = (GameObject)Instantiate(go, new Vector3(Random.value * _w, Random.value * _h, 10.0f), Quaternion.identity);
            gos[i].GetComponent<CaptureTs>().toward = gos[i].transform.position;
        }
        //
        mySavePath = Application.dataPath;
        Application.CaptureScreenshot(mySavePath + "/ts02.png");
	}
	
	// Update is called once per frame
	void Update () {

        //更新函数
        switch (step)
        {
            case 0:
                break;
            case 1:
                step = 0;
                mySavePath = Application.dataPath;
                Application.CaptureScreenshot(mySavePath + "ts02.png");
                Invoke("MywaitForSeconds",0.4f);
                Debug.Log(mySavePath);
                break;
            case 2:
                step = 0;
                mySavePath = Application.dataPath;
                StartCoroutine(WaitLoad(mySavePath + "/ts02.png"));
                break;
            case 3:
                step = 0;
                Cum();
                break;
            default:
                break;
        }
    }

    void MywaitForSeconds()
    {
        step = 2;
    }

    void Cum()
    {
        if (td != null)
        {
            float ft;
            ft = td.GetPixel(2, td.height - _h).r;
            myColors = td.GetPixels(2, td.height - _h, _w, _h);
            int l = myColors.Length;
            for (int i = 0; i < l; i++)
            {
                isShow[i / _w, i % _w] = myColors[i].r == ft ? false : true;
            }
            for (int i = 0; i < _h; i++)
            {
                for (int j = 0; j < _w; j++)
                {
                    if (isShow[i,j])
                    {
                        if (gosCur < gosMax)
                        {
                            gos[gosCur].GetComponent<CaptureTs>().toward = new Vector3(j, i, 0.0f);
                            gos[gosCur].SetActive(true);
                            gosCur++;
                        }
                        else
                        {
                            int temps = gosMax;
                            gosMax = (int)(gosMax * 1.5f);
                            GameObject[] tps = new GameObject[gosMax];
                            for (int k = 0; k < temps; k++)
                            {
                                tps[k] = gos[k];
                            }
                            for (int k = temps; k < gosMax; k++)
                            {
                                tps[k] = (GameObject)Instantiate(go,new Vector3(Random.value * _h,Random.value*_w,10.0f),Quaternion.identity);
                                tps[k].GetComponent<CaptureTs>().toward = tps[k].transform.position;
                            }
                            gos = new GameObject[gosMax];
                            gos = tps;
                            gos[gosCur].GetComponent<CaptureTs>().toward = new Vector3(j,i,0.0f);
                            gosCur++;
                        }
                    }
                }
            }

            for (int i = gosCur; i < gosMax; i++)
            {
                gos[i].SetActive(false);
            }
        }
    }

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, txtw, txth),txtbg);
        GUIStyle gs = new GUIStyle();
        gs.fontSize = 50;
        showTxt = GUI.TextField(new Rect(0,0,txtw, txth), showTxt, 15, gs);
        if (GUI.Button(new Rect(0, 100, 80, 45), "确定"))
        {
            GUI.FocusControl(null);
            gosCur = 0;
            step = 1;
        }

        //if()
    }

    IEnumerator WaitLoad(string fileName)
    {
        WWW wwwTexture = new WWW("file://" + fileName);
        yield return wwwTexture;
        td = wwwTexture.texture;
        step = 3;
    }


}
