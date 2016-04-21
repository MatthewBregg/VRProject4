using UnityEngine;
using System.Collections;

public class Cameralook : MonoBehaviour {
	public Transform target;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), 8 * Time.deltaTime);
	
	}
	
}
