using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(AdvisorAnimationController))]
public class CustomInspector : Editor {
	public override void OnInspectorGUI () 
	{
		base.OnInspectorGUI();

		// Take out this if statement to set the value using setter when ever you change it in the inspector.
		// But then it gets called a couple of times when ever inspector updates
		// By having a button, you can control when the value goes through the setter and getter, your self.

		if(target.GetType() == typeof(AdvisorAnimationController))
		{
			AdvisorAnimationController getterSetter = (AdvisorAnimationController)target;
			getterSetter.currentlyPlaying = getterSetter._currentlyPlaying;
			getterSetter.pauseAnimation = getterSetter._pauseAnimation;
		}

	}
}



public enum AdvisorAnimationEnum { isShakingHands, isTalking, isYelling, isArguing, isDisappointed, isTalking2, isArguing2, Idle};

public class AdvisorAnimationController : MonoBehaviour {



	private Animator animator;

	public AdvisorAnimationEnum currentlyPlaying {
		get {
			return _currentlyPlaying;
		}
		set {
			//Debug.Log ("Test : " + _currentlyPlaying + " " + value);
			if (!value.Equals (_previouslyPlaying)) {
				bool animatorState = animator.enabled;
				animator.enabled = true;
				Debug.Log ("Setter is running!" + value.ToString ());
				if (_previouslyPlaying != AdvisorAnimationEnum.Idle) {
					animator.SetBool (_previouslyPlaying.ToString (), false);
				}
				_currentlyPlaying = value;
				_previouslyPlaying = value;
				if (value != AdvisorAnimationEnum.Idle) {
					animator.SetBool (_currentlyPlaying.ToString (), true);
				}
				animator.enabled = animatorState;
			}
		}
	}
	
	public AdvisorAnimationEnum _currentlyPlaying = AdvisorAnimationEnum.Idle; //DON'T set this from a script!!
	//Probably some way to make this private and still have the getter/setter work with the inspector, but not worth it.
	private AdvisorAnimationEnum _previouslyPlaying = AdvisorAnimationEnum.Idle;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator> ();
	}

	public bool _pauseAnimation = false;

	public bool pauseAnimation {
		get {
			return _pauseAnimation;
		}
		set {
			_pauseAnimation = value;
			Debug.Log ("Set paused " + value);
			if (animator) {
				animator.enabled = !_pauseAnimation;
			}
		}
	}
		


	// Update is called once per frame
	void Update () {
		
	}
}
