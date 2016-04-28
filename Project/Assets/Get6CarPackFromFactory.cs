using UnityEngine;
using System.Collections;

public class Get6CarPackFromFactory : MonoBehaviour {
	public Vector3 position = new Vector3(0,0,0);
	public CarFactory factory;
	bool switchBool = false; 

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (factory.allowedToSwitch && !switchBool) {
			GameObject carPack = factory.getSixPackOfCars ();
			factory.setParent (carPack, gameObject.transform, position);
			switchBool = true;
		}
	}
}
