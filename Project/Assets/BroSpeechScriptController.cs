using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class BroSpeechScriptController : MonoBehaviour
{

    public GameObject player;
    private FadeScript fader;
    public GameObject city;
    public GameObject colombianRestaurant; 

    public AudioClip advisor1Reg1;
    public AudioClip advisor1Reg2;
    public AudioClip advisor1Reg3;

    public AudioClip advisor1NoReg1;
    public AudioClip advisor1NoReg2;
    public AudioClip advisor1NoReg3;

    public AudioClip advisor2Reg1;
    public AudioClip advisor2Reg2;
    public AudioClip advisor2Reg3;

    public AudioClip advisor2NoReg1;
    public AudioClip advisor2NoReg2;
    public AudioClip advisor2NoReg3;
    public bool regulated;
    private bool _regulated;

    private AudioClip a1;
    private AudioClip a2;
    private AudioClip aGotChosen;

    private AudioClip b1;
    private AudioClip b2;
    private AudioClip bGotChosen;


    public GameObject advisor1;
    public GameObject advisor2;
    private AudioSource source1;
    private AudioSource source2;
	public GameObject radio;
	private AudioSource radioAudioSource;
	public AudioClip radioRegulatedUber;
	public AudioClip radioDeregulatedUber;
	private AudioClip radioClip;

    public enum States { Beginning, Advisor1FirstClip, Advisor2FirstClip, Advisor1SecondClip, Advisor2SecondClip, AwaitingPlayerResponse, ChooseUber, ChooseTaxi, TransitionTime, PlayingFinalRadioStuff, Done };

    private AdvisorAnimationController advisor1Animator;
    private AdvisorAnimationController advisor2Animator;

    public States state = States.Beginning;
    // Use this for initialization
    void Start()
    {
        regulated = StaticDecisionsMade.chooseToRegulateUber;
        _regulated = regulated;
        source1 = advisor1.GetComponent<AudioSource>();
        source2 = advisor2.GetComponent<AudioSource>();
        advisor1Animator = advisor1.GetComponent<AdvisorAnimationController>();
        advisor2Animator = advisor2.GetComponent<AdvisorAnimationController>();
        initializeAudioClips();
        fader = player.GetComponentInChildren<FadeScript>();
		radioAudioSource = radio.GetComponent<AudioSource> ();

    }
    void initializeAudioClips ()
    {
        if (_regulated)
        {
            a1 = advisor1Reg1;
            a2 = advisor1Reg2;
            aGotChosen = advisor1Reg3;

            b1 = advisor2Reg1;
            b2 = advisor2Reg2;
            bGotChosen = advisor2Reg3;
			radioClip = radioRegulatedUber;
        } else
        {
            a1 = advisor1NoReg1;
            a2 = advisor1NoReg2;
            aGotChosen = advisor1NoReg3;

            b1 = advisor2NoReg1;
            b2 = advisor2NoReg2;
            bGotChosen = advisor2NoReg3;
			radioClip = radioDeregulatedUber;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( regulated != _regulated )
        {
            _regulated = regulated;
            initializeAudioClips();
        }
        if (state == States.Beginning)
        {
            state = States.Advisor1FirstClip;
            advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.Idle;

            advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.isTalking;
            source1.Stop();
            source1.clip = a1;
            source1.Play();
        }
        if (state == States.Advisor1FirstClip && !source1.isPlaying)
        {
            state = States.Advisor2FirstClip;

            advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.isTalking2;

            advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.Idle;
            source2.Stop();
            source2.clip = b1;
            source2.Play();

        }

        if (state == States.Advisor2FirstClip && !source2.isPlaying)
        {
            state = States.Advisor1SecondClip;

            advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.Idle;

            advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.isTalking;
            source1.Stop();
            source1.clip = a2;
            source1.Play();
        }


        if (state == States.Advisor1SecondClip && !source1.isPlaying)
        {
            state = States.Advisor2SecondClip;

            advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.isTalking2;

            advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.Idle;
            source2.Stop();
            source2.clip = b2;
            source2.Play();

        }



        if (state == States.Advisor2SecondClip && !source2.isPlaying)
        {
            state = States.AwaitingPlayerResponse;
            advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.isShakingHands;
            advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.isShakingHands;

        }

        if (state == States.ChooseTaxi)
        {
            state = States.TransitionTime;
            StaticDecisionsMade.chooseToTakeTaxi = true;
            advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.isDisappointed;

            advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.isShakingHandsEnd;
            source1.Stop();
            source1.clip = aGotChosen;
            source1.Play();

        }

        if (state == States.ChooseUber)
        {
            state = States.TransitionTime;
            StaticDecisionsMade.chooseToTakeTaxi = false;
            advisor2Animator.currentlyPlaying = AdvisorAnimationEnum.isShakingHandsEnd;

            advisor1Animator.currentlyPlaying = AdvisorAnimationEnum.isDisappointed;
            source2.Stop();
            source2.clip = bGotChosen;
            source2.Play();



        }

        if (state == States.TransitionTime && !source1.isPlaying && !source2.isPlaying)
        {

            //Transition scene!
            //Might want to delay this a bit more.
            if ( !FadedOut )
            {
                FadedOut = true;
                fader.FadeOut();
                
            }
            else
            {
                if ( !fader.isTransitioning() && !FadedIn)
                {
                    FadedIn = true;
                    //Do all the movements, this is when screen is dark.
                    player.transform.position = new Vector3(.85f, -13.9f, 14.97f);
                    //change sounds
                    city.GetComponent<AudioSource>().enabled = true;
                    colombianRestaurant.GetComponent<AudioSource>().enabled = false;

                    //Enable one of the cars
                    if ( StaticDecisionsMade.chooseToTakeTaxi)
                    {
                        taxiCar.SetActive(true);
                    } 
                    else
                    {
                        uberCar.SetActive(true);
                    }

                    //Fade in 
                    fader.FadeIn();
                }
                else if ( !fader.isTransitioning() && !FadedInFadedOut) 
                {
                    FadedInFadedOut = true;
                    //Do anything AFTER fade in, screen is done, transition is done
                    Debug.Log("I happen after the player moves and can see again!");
					state = States.PlayingFinalRadioStuff;

                }
            }

            
        }
		if ( state == States.PlayingFinalRadioStuff ) {
			state = States.Done;
			radioAudioSource.Stop ();
			radioAudioSource.clip = radioClip;
			radioAudioSource.Play ();
			//Start playing the final radio stuff

		}
		if (state == States.Done && !radioAudioSource.isPlaying) {
			///Transition to scene 3
			SceneManager.LoadScene("Second Accelorated Future");
		}


    }
    public GameObject uberCar;
    public GameObject taxiCar;
    private bool FadedOut = false; 
    private bool FadedIn = false;
    private bool FadedInFadedOut = false;

    
}
