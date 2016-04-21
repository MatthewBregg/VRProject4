using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Glassdestroy : MonoBehaviour {
	//FOR THE BROKEN PIECES
	public GameObject shards;
	private GameObject broken;
	//THE TOTAL FORCES ADDED UP TO DETERMINE DESTRUCTION
	public float withstandingforce=30;
	//WHEN THE GLASS SHATTERS
	public bool shatter;
	//RESETS THE WINDOW
	public bool reset;
	//CONFIRMS ITS DESTROYED
	private bool glassdestroyed;
	
	public float shardcollisiontime=3;
	public float sharddestroytime=10;
	
	//SOUNDS
	public List<AudioClip> smashsounds;
	public List<AudioClip> bingsounds;
	
	//RANDOM NUMBER GENERATORS
    private int randomgen;
	private int randomgen2;
	
	// Use this for initialization
	void Start () {
	
		//SET TIMES


				;
				
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//GENERATE RANDOM NUMBERS
		randomgen=randomgen+1;	
if(randomgen>=smashsounds.Count)randomgen=0;
		randomgen2=randomgen2+1;
if(randomgen2>=bingsounds.Count)randomgen2=0;
		
		
	//LETS DESTROY	
	if(glassdestroyed){}
			else{
		if(shatter){
		GetComponent<AudioSource>().clip=smashsounds[randomgen];
			GetComponent<AudioSource>().Play();		
				
		broken=(GameObject)Instantiate (shards.gameObject, transform.position, transform.rotation);	
		//TELL THE PARENT TO TELL THE CHILDEREN THEIR STATS  :)
		Parent par=(Parent)broken.GetComponent("Parent");
		par.shardcollisiontime=shardcollisiontime;
		par.sharddestroytime=sharddestroytime;
		broken.transform.localScale=transform.localScale;
			gameObject.GetComponent<Renderer>().enabled=false;
			GetComponent<Collider>().enabled=false;
			glassdestroyed=true;
			}
			shatter=false;
		
		}
		
		//RESET THE WINDOW TO NORMAL
		if(reset){
			gameObject.GetComponent<Renderer>().enabled=true;
			GetComponent<Collider>().enabled=true;
			glassdestroyed=false;
			reset=false;
		}

	}
	void OnCollisionStay(Collision other) {
		
		
	

		
		//DESTROY IF THE FORCE AND MASS ADD UP
		if(other.rigidbody){
		if(other.impactForceSum.y*other.rigidbody.mass>withstandingforce	
			|other.impactForceSum.x*other.rigidbody.mass>withstandingforce
			|other.impactForceSum.z*other.rigidbody.mass>withstandingforce
				
			|other.impactForceSum.y*other.rigidbody.mass<-withstandingforce	
			|other.impactForceSum.x*other.rigidbody.mass<-withstandingforce
			|other.impactForceSum.z*other.rigidbody.mass<-withstandingforce
				){
				shatter=true;	
				
			}
			else{
			if(other.impactForceSum.y*other.rigidbody.mass>withstandingforce*0.2f	
			|other.impactForceSum.x*other.rigidbody.mass>withstandingforce*0.2f
			|other.impactForceSum.z*other.rigidbody.mass>withstandingforce*0.2f
				
			|other.impactForceSum.y*other.rigidbody.mass<-withstandingforce*0.2f	
			|other.impactForceSum.x*other.rigidbody.mass<-withstandingforce*0.2f
			|other.impactForceSum.z*other.rigidbody.mass<-withstandingforce*0.2f
						){
				GetComponent<AudioSource>().clip=bingsounds[randomgen2];
			GetComponent<AudioSource>().Play();
			}
			}
		
		}	
		else{
			//DESTROY IF HITS GROUND or non rigid body WITH FORCE
		if(other.impactForceSum.y>withstandingforce*0.2f	
			|other.impactForceSum.x>withstandingforce*0.2f
			|other.impactForceSum.z>withstandingforce*0.2f
				
			|other.impactForceSum.y<-withstandingforce*0.2f	
			|other.impactForceSum.x<-withstandingforce*0.2f
			|other.impactForceSum.z<-withstandingforce*0.2f	
			
			){
	shatter=true;
    GetComponent<Collider>().enabled=false;
				

			}
		}
	}
	
}
