#pragma strict

function Start () {
	
}

function Update () {
	
}

function OnGUI(){
	if(GUI.Button(Rect(100,50,200,100),"JS调用C#"))
	{
		//var cs = this.//GetCompolor
		//cs.CallMe("我来自JS");
	}
}

function CallMe(test:String)
{
	Debug.Log(test);
}
