using UnityEngine;
using System.Collections;

public class Get4CarPackFromFactory : MonoBehaviour {
	public Vector3 position;
	public CarFactory factory;

	bool switchBool = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (factory.allowedToSwitch && !switchBool) {
			GameObject carPack = factory.getFourPackOfCars ();
			factory.setParent (carPack, gameObject.transform, position);
			switchBool = true;
		}
	}
}
