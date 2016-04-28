using UnityEngine;
using System.Collections;

public class Get4CarPackFromFactory : MonoBehaviour {
	public Vector3 position;
	public CarFactory factory;


	// Use this for initialization
	void Start () {
		GameObject carPack = factory.getFourPackOfCars ();
		factory.setParent (carPack, gameObject.transform, position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
