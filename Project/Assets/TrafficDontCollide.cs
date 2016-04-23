using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrafficDontCollide : MonoBehaviour
{
	public bool reverse;



	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	//Pause another carset when it enters us, and reenable it once we have left it in the dust.
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag.StartsWith("TrafficB")) {
			
			if ((!reverse && gameObject.transform.position.z > other.gameObject.transform.position.z) || (reverse && gameObject.transform.position.z < other.gameObject.transform.position.z)) {
				//The goal is only to pause myself if I encounter an object that is farther along the path than I..
				//Since I can't find a good way to do this in iTween, I am going with this very path specefici hack. 
				other.gameObject.GetComponent<TrafficHandlePausing> ().sameLanePause = true;
				//iTween.Pause (other.gameObject);

			}

		}
	}
	IEnumerator ResumeCar(GameObject g) {
		yield return new WaitForSeconds(1);
		g.GetComponent<TrafficHandlePausing> ().sameLanePause = false;
		//iTween.Resume (g);
	}
	void OnTriggerExit (Collider other) {
		if (other.gameObject.tag.StartsWith("TrafficB")) {
			StartCoroutine (ResumeCar (other.gameObject));
		}
	}

}
