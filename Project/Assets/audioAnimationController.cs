using UnityEngine;
using System.Collections;

public class audioAnimationController : MonoBehaviour {
	public AudioClip a1;
	public AudioClip a2;
	public AudioClip a3;
	public AudioClip athanks;

	public AudioClip b1;
	public AudioClip b2;
	public AudioClip bthanks;


	public GameObject advisor1;
	public GameObject advisor2;
	private AudioSource source1;
	private AudioSource source2;

	private AdvisorAnimationController advisor1Animator;
	private AdvisorAnimationController advisor2Animator;

	public int state=0;
	// Use this for initialization
	void Start () {
		source1 = advisor1.GetComponent<AudioSource> ();
		source2 = advisor2.GetComponent<AudioSource> ();
		advisor1Animator = advisor1.GetComponent<AdvisorAnimationController> ();
		advisor2Animator = advisor2.GetComponent<AdvisorAnimationController> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (state == 0) {
			state = 1;
			advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.Idle;

			advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.isTalking;
			source1.Stop ();
			source1.clip = a1;
			source1.Play();
		}
		if (state == 1 && !source1.isPlaying) {
			state = 2;

			advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.isTalking2;

			advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.Idle;
			source2.Stop ();
			source2.clip = b1;
			source2.Play();

		}

		if (state == 2 && !source2.isPlaying) {
			state = 3;

			advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.Idle;

			advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.isTalking;
			source1.Stop ();
			source1.clip = a2;
			source1.Play();
		}


		if (state == 3 && !source1.isPlaying) {
			state = 4;

			advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.isTalking2;

			advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.Idle;
			source2.Stop ();
			source2.clip = b2;
			source2.Play();

		}

		if (state == 4 && !source2.isPlaying) {
			state = 5;

			advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.Idle;

			advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.isTalking;
			source1.Stop ();
			source1.clip = a3;
			source1.Play();
		}

		if (state == 5 && !source1.isPlaying) {

			advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.isShakingHands;
			advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.isShakingHands;

		}

		if (state == 8) {
			state = 100;
			StaticDecisionsMade.chooseToRegulateUber = false;
			advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.Idle;

			advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.isTalking;
			source1.Stop ();
			source1.clip = athanks;
			source1.Play();

		}

		if (state == 9) {
			state = 100;
			StaticDecisionsMade.chooseToRegulateUber = true;
			advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.isTalking2;

			advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.Idle;
			source2.Stop ();
			source2.clip = bthanks;
			source2.Play();



		}

		if ( state == 100 && !source1.isPlaying && !source2.isPlaying ) {
			//Transition scene!
		}


	}
}
