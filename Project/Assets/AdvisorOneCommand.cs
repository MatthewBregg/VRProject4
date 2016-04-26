using UnityEngine;
using System.Collections;

public class AdvisorOneCommand : MonoBehaviour, Command {
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
			animations.state = audioAnimationController.States.DidChooseRegulation;
		}
		Debug.Log ("Advisor one ran command!");
	}
}
