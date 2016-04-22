using UnityEngine;
using System.Collections;

public class TrafficTweenStartScriptA : MonoBehaviour {
	public float delay = 0f;
	public string pathName;
	// Use this for initialization
	void Start () {

			 iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath (pathName), "time", 15, "orienttopath", true, "looptype", "loop", "easetype","linear","delay",delay));
			

	}
	
	// Update is called once per frame
	void Update () {

	}
}
