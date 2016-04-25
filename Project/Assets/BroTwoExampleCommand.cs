using UnityEngine;
using System.Collections;

public class BroTwoExampleCommand : MonoBehaviour, Command {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void executeCommand() {
		Debug.Log ("Bro two command run!!");
	}
}
