using UnityEngine;
using System.Collections;

public class AdvisorOneCommand : MonoBehaviour, Command {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void executeCommand() {
		Debug.Log ("Advisor one ran command!");
	}
}
