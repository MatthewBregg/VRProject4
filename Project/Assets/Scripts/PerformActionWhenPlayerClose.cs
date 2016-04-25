using UnityEngine;
using System.Collections;

public interface Command {
	void executeCommand ();
}

public class PerformActionWhenPlayerClose : MonoBehaviour {
	private Transform target;
	private Transform myTransform;
	public float range;
	public GameObject commandToRun;
	private bool done = false;
	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag("Player").transform; //target the target
		myTransform = transform;
	}

	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (myTransform.position, target.position) < range) {
			//Perform some action
			if (!done) {
				done = true;
				Command c = commandToRun.GetComponent<Command> ();
				c.executeCommand ();
			}
		} else { 
			done = false;
			//Once the player moves away, reset done so the command will be done again when the player gets close again; 
		}
	}
}
