using UnityEngine;
using System.Collections;

public class CarFactory : MonoBehaviour {
	public GameObject sixPackCarPackLowTaxiTypeA;
	public GameObject fourPackCarPackLowTaxiTypeA;
	public GameObject fourPackCarPackLowTaxiTypeB;

	public GameObject sixPackCarPackHighTaxiTypeA;
	public GameObject fourPackCarPackHighTaxiTypeA;
	public GameObject fourPackCarPackHighTaxiTypeB;

	public bool serveTaxisQuestionMark;

	private static System.Random rnd = new System.Random();

	public GameObject getSixPackOfCars() {
		if (serveTaxisQuestionMark) {
			return (GameObject)Object.Instantiate (sixPackCarPackHighTaxiTypeA);
		} else {
			return (GameObject)Object.Instantiate (sixPackCarPackLowTaxiTypeA);
		}

	}
	private GameObject pickOneOfTwo(GameObject A, GameObject B) {
		if (CarFactory.rnd.Next (0, 2) == 1) { 
			return A;
		} else { 
			return B;
			//Yeah yeah, but we don't need the factory to scale....
		}
	}
	public GameObject getFourPackOfCars() {
		if (serveTaxisQuestionMark) {
			return (GameObject)Object.Instantiate (pickOneOfTwo (fourPackCarPackHighTaxiTypeA, fourPackCarPackHighTaxiTypeB));
		} else {
			return (GameObject)Object.Instantiate (pickOneOfTwo (fourPackCarPackLowTaxiTypeA, fourPackCarPackLowTaxiTypeB));
		}
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
        serveTaxisQuestionMark =  StaticDecisionsMade.chooseToRegulateUber;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
