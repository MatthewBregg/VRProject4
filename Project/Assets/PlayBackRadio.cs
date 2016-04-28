using UnityEngine;
using System.Collections;

public class PlayBackRadio : MonoBehaviour {
	private AudioClip clip;
	public AudioClip NoRegTookUber;
	public AudioClip RegTookUber;
	public AudioClip NoRegTookTaxi;
	public AudioClip RegTookTaxi;
	// Use this for initialization
	void Start () {
		if (StaticDecisionsMade.chooseToRegulateUber) {
			if (StaticDecisionsMade.chooseToTakeTaxi) {
				clip = RegTookTaxi;
			} else {
				clip = RegTookUber;
			}
		} else {
			if (StaticDecisionsMade.chooseToTakeTaxi) {
				clip = NoRegTookTaxi;
			} else {
				clip = NoRegTookUber;
			}
		}
		AudioSource audioSource = this.GetComponent<AudioSource> ();
		audioSource.Stop ();
		audioSource.clip = clip;
		audioSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
