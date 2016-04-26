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
    public static bool isPlayer(GameObject mightBePlayer)
    {
        Transform t = mightBePlayer.transform;
        while (t != null)
        {
            if (t.gameObject.CompareTag("Player")) //replace with list if desired
            {
                return true;
            }
            t = t.parent;
        }
        return false;

    }
    private void detection(GameObject collided)
    {
       if ( PerformActionWhenPlayerClose.isPlayer(collided))
        {
            commandToRun.GetComponent<Command>().executeCommand();
        }
    }
}
