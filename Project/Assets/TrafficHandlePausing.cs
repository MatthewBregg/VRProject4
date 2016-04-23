using UnityEngine;
using System.Collections;

public class TrafficHandlePausing : MonoBehaviour {
	public bool intersectionPause = false;
	public bool sameLanePause = false;
	private bool currentPauseStatus = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (sameLanePause || intersectionPause != currentPauseStatus) {
			currentPauseStatus = sameLanePause || intersectionPause;
			if (currentPauseStatus) {
				iTween.Pause (gameObject);
			} else {
				iTween.Resume (gameObject);
			}
		}
	}
}
