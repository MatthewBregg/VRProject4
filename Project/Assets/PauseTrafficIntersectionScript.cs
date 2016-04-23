using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseTrafficIntersectionScript : MonoBehaviour
{
	private HashSet<GameObject> highPriorityCars = new HashSet<GameObject>();
	private HashSet<GameObject> lowPriorityCars = new HashSet<GameObject>();
	// Use this for initialization
		
	void Start () {
		
	}
		
	// Update is called once per frame
	void Update () {
		if (highPriorityCars.Count == 0) {
			//No high priority cars in the intersection, let all the low priority cars that have built up go.
			foreach (GameObject car in lowPriorityCars) {
				car.GetComponent<TrafficHandlePausing> ().intersectionPause = false;
				//iTween.Resume (car);
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("TrafficA")) {
			highPriorityCars.Add (other.gameObject);
			Debug.Log ("Added a car, count is " + highPriorityCars.Count);
		}

		if (other.gameObject.CompareTag ("TrafficB") && highPriorityCars.Count > 0) {
			//If there are high priority cars in the intersection, pause.
			lowPriorityCars.Add (other.gameObject);
			Debug.Log ("PAusing!");
			other.gameObject.GetComponent<TrafficHandlePausing> ().intersectionPause = true;
			//iTween.Pause (other.gameObject);
		}
			
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.CompareTag ("TrafficA")) {
			highPriorityCars.Remove (other.gameObject);
		}
	}

}
