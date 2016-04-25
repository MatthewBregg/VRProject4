using UnityEngine;
using System.Collections;

public class AdvisorOneAnimationScript : MonoBehaviour {

	public Animator animatorControllerVar;
	public bool isShakingHands = false;

	int soundFileNumber = 0;
	float[] soundFileTimes = new float[2] {1, 2};


	void Start() {
		animatorControllerVar = GetComponent<Animator> ();
	}

	void Update () {
		if (isShakingHands == true) { 
			playShakeHandsAnimation ();
		}
	}


	void playShakeHandsAnimation() {
		animatorControllerVar.SetTrigger("isShakingHands");
	}

}
		