using UnityEngine;
using System.Collections;

public class Breakparent : MonoBehaviour {
	//THE PARENT OF THE SHARD
	public GameObject parent;
	//CHECK THE PARENTS STATS
	private bool checkparent;
	//TIMERS
	private float dtimer;
	private float ctimer;
	//TIMES TO DESTROY COLLISION AND ITSELF
	public float destroycollisiontime=4;
	public float destroytime=12;
	public bool grounded;


	// Use this for initialization
	void Start () {
		//GET RID OF PARENT
		transform.parent = null;
	checkparent=true;
	}
	
	// Update is called once per frame
	void Update () {
		//CHECK PARENT AND GET COMPONENTS
		if(checkparent){
		if(parent){
			Parent par=(Parent)parent.GetComponent("Parent");
			destroycollisiontime=par.shardcollisiontime;
			destroytime=par.sharddestroytime;
				checkparent=false;
		}
		}
		
		
		//START DESTROY TIMER
	dtimer+=Time.deltaTime;
		
		//IF GROUNDED, START COLLISION DESTROY TIMER
		if(grounded)ctimer+=Time.deltaTime; 
	
		//DESTROY COLLISION
	if(ctimer>destroycollisiontime){
			Destroy(GetComponent<Rigidbody>());	
			Destroy(GetComponent<Collider>());
			grounded=false;
		}
		
		
	if(dtimer>destroytime) Destroy(gameObject);
		
	}
	void OnCollisionStay(Collision other) {
	if(grounded){}
		else{
			//CHECK TO SEE IF COLLIDER IS ANOTHER PIECE OF GLASS, THEN CHECK IF THE COLLIDING PIECE OF GLASS IS GROUNDED
		Breakparent check=(Breakparent)other.transform.GetComponent("Breakparent");
		
		
		if(check){
			if(check.grounded){
			
				grounded=true;
		}	
				
			}
else{
				grounded=true;
	

	
		}
		}
		
	}
}
