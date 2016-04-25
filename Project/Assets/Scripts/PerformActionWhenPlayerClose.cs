using UnityEngine;
using System.Collections;

public interface Command {
	void executeCommand ();
}

public class PerformActionWhenPlayerClose : MonoBehaviour {
	public GameObject commandToRun;
	// Use this for initialization
	void Start () {
		
	}
    public void OnCollisionEnter(Collision collision)
    {

        detection(collision.gameObject);

    }

    public void OnTriggerEnter(Collider collider)
    {
        detection(collider.gameObject);
    }

    private void detection(GameObject collided)
    {
        Transform t = collided.transform;
        while (t != null)
        {
            if (t.gameObject.CompareTag("Player")) //replace with list if desired
            {
                Debug.Log("Running command!");
                commandToRun.GetComponent<Command>().executeCommand();
            }
            t = t.parent;
        }
    }
}
