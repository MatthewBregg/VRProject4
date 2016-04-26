using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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

	public enum States { Beginning, Advisor1FirstClip, Advisor2FirstClip, Advisor1SecondClip, Advisor2SecondClip, Advisor1ThirdClip, AwaitingPlayerResponse, DidNotChooseRegulation, DidChooseRegulation, Done }; 

	private AdvisorAnimationController advisor1Animator;
	private AdvisorAnimationController advisor2Animator;

	public States state=States.Beginning;
	// Use this for initialization
	void Start () {
		source1 = advisor1.GetComponent<AudioSource> ();
		source2 = advisor2.GetComponent<AudioSource> ();
		advisor1Animator = advisor1.GetComponent<AdvisorAnimationController> ();
		advisor2Animator = advisor2.GetComponent<AdvisorAnimationController> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (state == States.Beginning) {
			state = States.Advisor1FirstClip;
			advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.Idle;

			advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.isTalking;
			source1.Stop ();
			source1.clip = a1;
			source1.Play();
		}
		if (state == States.Advisor1FirstClip && !source1.isPlaying) {
			state = States.Advisor2FirstClip;

			advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.isTalking2;

			advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.Idle;
			source2.Stop ();
			source2.clip = b1;
			source2.Play();

		}

		if (state == States.Advisor2FirstClip && !source2.isPlaying) {
			state = States.Advisor1SecondClip;

			advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.Idle;

			advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.isTalking;
			source1.Stop ();
			source1.clip = a2;
			source1.Play();
		}


		if (state == States.Advisor1SecondClip && !source1.isPlaying) {
			state = States.Advisor2SecondClip;

			advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.isTalking2;

			advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.Idle;
			source2.Stop ();
			source2.clip = b2;
			source2.Play();

		}

		if (state == States.Advisor2SecondClip && !source2.isPlaying) {
			state = States.Advisor1ThirdClip;

			advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.Idle;

			advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.isTalking;
			source1.Stop ();
			source1.clip = a3;
			source1.Play();
		}

		if (state == States.Advisor1ThirdClip && !source1.isPlaying) {
			state = States.AwaitingPlayerResponse;
			advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.isShakingHands;
			advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.isShakingHands;

		}

		if (state == States.DidChooseRegulation) {
			state = States.Done;
			StaticDecisionsMade.chooseToRegulateUber = true;
			advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.isDisappointed;

			advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.isShakingHandsEnd;
			source1.Stop ();
			source1.clip = athanks;
			source1.Play();

		}

		if (state == States.DidNotChooseRegulation) {
			state = States.Done;
			StaticDecisionsMade.chooseToRegulateUber = false;
			advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.isShakingHandsEnd;

			advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.isDisappointed;
			source2.Stop ();
			source2.clip = bthanks;
			source2.Play();



		}

		if ( state == States.Done && !source1.isPlaying && !source2.isPlaying ) {
            //Transition scene!
            //Might want to delay this a bit more.
            SceneManager.LoadScene("First Accelorated Future");
        }


	}
}
