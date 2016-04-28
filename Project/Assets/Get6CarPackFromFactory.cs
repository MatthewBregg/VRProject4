using UnityEngine;
using System.Collections;

public class Get6CarPackFromFactory : MonoBehaviour {
	public Vector3 position = new Vector3(0,0,0);
	public CarFactory factory;


	// Use this for initialization
	void Start () {

		//while (!factory.allowedToSwitch) {}
			GameObject carPack = factory.getSixPackOfCars ();
			factory.setParent (carPack, gameObject.transform, position);

	}

	// Update is called once per frame
	void Update () {

	}
}
