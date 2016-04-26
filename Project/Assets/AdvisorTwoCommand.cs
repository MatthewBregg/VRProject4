using UnityEngine;
using System.Collections;

public class AdvisorTwoCommand : MonoBehaviour, Command {
	public GameObject VirtualHUmans;

	private audioAnimationController animations;
	// Use this for initialization
	void Start () {
		animations = VirtualHUmans.GetComponent<audioAnimationController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void executeCommand() {

		if ( animations.state == audioAnimationController.States.AwaitingPlayerResponse ) {
			animations.state = audioAnimationController.States.DidNotChooseRegulation;
		}
		Debug.Log ("Advisor two ran command!");
	}
}
