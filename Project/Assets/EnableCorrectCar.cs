using UnityEngine;
using System.Collections;

public class EnableCorrectCar : MonoBehaviour {
	public GameObject taxiCar;
	public GameObject uberCar;
	// Use this for initialization
	public bool tookTaxi;
	private bool _tookTaxi;
	void Start () {
		tookTaxi = StaticDecisionsMade.chooseToTakeTaxi;
		_tookTaxi = tookTaxi;
		uberCar.SetActive (!tookTaxi);
		taxiCar.SetActive (tookTaxi);
	}
	
	// Update is called once per frame
	void Update () {
		if (_tookTaxi != tookTaxi) {
			_tookTaxi = tookTaxi;
			uberCar.SetActive (!tookTaxi);
			taxiCar.SetActive (tookTaxi);
		}
	}
}
