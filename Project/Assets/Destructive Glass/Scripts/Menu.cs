using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Menu : MonoBehaviour {
	private float ballweight=20;
	public Transform ball;
	private bool addweight;
	private bool reset;
	private bool fixglass;
	private Vector3 startpos;
	
	public List<Transform> windows;
	
	// Use this for initialization
	void Start () {
		

		ballweight=10;
	ball.transform.GetComponent<Rigidbody>().mass=ballweight;
		startpos=ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	if(addweight){
			ballweight=ballweight+5;
			if(ballweight>100)ballweight=1;
			ball.transform.GetComponent<Rigidbody>().mass=ballweight;
			addweight=false;
		}
		
		if(reset){
			ballweight=5;
			ball.transform.GetComponent<Rigidbody>().mass=ballweight;
			reset=false;
		}
		
		
	}
	void OnGUI(){
	if(GUI.Button(new Rect(0, 30, 300, 26), "Click here to add ball weight ("+ballweight+")")){	
	addweight=true;
		}
		
		if(GUI.Button(new Rect(0, 60, 300, 26), "Reset ball weight to 5")){	
	reset=true;
		}
		
		if(GUI.Button(new Rect(0, 140, 300, 26), "Drop Ball!")){	
	ball.position=startpos;
		}
		
		if(GUI.Button(new Rect(0, 170, 300, 26), "Fix Glass")){	
	int listsize=windows.Count;
				
			for (int i = 0; i < listsize; i++){
					Glassdestroy wins=(Glassdestroy)windows[i].GetComponent("Glassdestroy");
				wins.reset=true;
			}
		}
		
	
	}
}
