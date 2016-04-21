using UnityEngine;
using System.Collections;

public class ShatterPotteryOnImpact : MonoBehaviour {
    public GameObject shatteredForm;
    public AudioClip shatterSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Table") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Pottery")) {
            return;
        }
//        print(collision.gameObject.name);
//        Debug.Log(collision.gameObject.tag);
       //Should add a shatter sound to it also!!
        this.shatter();
    }

    public void shatter() {
		
        Transform t = GetComponent<Transform>();
        shatteredForm.transform.position = t.position;
        shatteredForm.transform.rotation = t.rotation;
        shatteredForm.transform.localPosition = t.localPosition;
        shatteredForm.transform.localRotation = t.localRotation;
        Vector3 v = GetComponent<Rigidbody>().velocity;
        foreach (Transform child in transform) {
            //child is your child transform
            child.gameObject.GetComponent<Rigidbody>().velocity = v;
        }
        
        shatteredForm.SetActive(true);

		shatteredForm.GetComponent<AudioSource> ().PlayOneShot (shatterSound);
		//Avoid shatter sounds at beginning of game from poorly placed pottery.
        gameObject.SetActive(false);

    }

}
