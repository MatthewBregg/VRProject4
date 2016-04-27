using UnityEngine;
using System.Collections;

public class CarCrashTweenStart : MonoBehaviour {

	public float delay = 0f;
	public string pathName;
	public float time = 15f;
	public string type = "linear";
	// Use this for initialization
	void Start () {

		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath (pathName), "time", time, "orienttopath", true, "easetype",type,"delay",delay));


	}

	// Update is called once per frame
	void Update () {

	}
}
