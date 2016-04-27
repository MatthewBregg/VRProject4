using UnityEngine;
using System.Collections;

public class SwapCarsOnCollision : MonoBehaviour {
	public GameObject before;
	public GameObject after;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		if ( other.gameObject.CompareTag("TreeToCrashInto") ) {
			before.SetActive(false);
			after.SetActive(true);
		}
	}
}
