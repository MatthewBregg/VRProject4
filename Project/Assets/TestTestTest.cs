using UnityEngine;
using System.Collections;

public class TestTestTest : MonoBehaviour {
	public AdvisorAnimationEnum ani;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<AdvisorAnimationController>()._currentlyPlaying = ani;
	}
}
