using UnityEngine;
using System.Collections;

public class CarFactory : MonoBehaviour {
	public GameObject sixPackCarPackLowTaxiTypeA;
	public GameObject fourPackCarPackLowTaxiTypeA;
	public GameObject fourPackCarPackLowTaxiTypeB;

	public GameObject getSixPackOfCars() {
		return (GameObject) Object.Instantiate (sixPackCarPackLowTaxiTypeA);

	}

	public GameObject getFourPackOfCars() {
		return (GameObject) Object.Instantiate (fourPackCarPackLowTaxiTypeA);
	}

	public void setParent(GameObject carPack, Transform parent, Vector3 lPosition) {
		carPack.transform.parent = parent;
		carPack.transform.localPosition = lPosition;
		carPack.transform.localScale = new Vector3 (1, 1, 1);
		carPack.transform.rotation = new Quaternion ();
		carPack.SetActive (true);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
