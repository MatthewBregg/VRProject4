using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrafficDontCollide : MonoBehaviour
{
	public int number;
	// Use this for initialization

	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	//Pause another carset when it enters us, and reenable it once we have left it in the dust.
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag.StartsWith("Traffic")) {
			TrafficDontCollide trafficDontCollide = other.gameObject.GetComponent<TrafficDontCollide> ();

			if (trafficDontCollide && trafficDontCollide.number > number) {
				//If trafficDontCollide script is null, then we dont want to pause it, as this piece of traffic doesn't have traffic control.
				iTween.Pause (gameObject);
				//Don't pause an earlier number! So, things that are "ahead" on the path should have an earlier number!!
			}

		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.tag.StartsWith("Traffic")) {
			iTween.Resume (gameObject);
		}
	}

}
