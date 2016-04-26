using UnityEngine;
using System.Collections;



public class BroOneExampleCommand : MonoBehaviour, Command {

    public GameObject VirtualHUmans;

    private BroSpeechScriptController animations;
    // Use this for initialization
    void Start()
    {
        animations = VirtualHUmans.GetComponent<BroSpeechScriptController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void executeCommand()
    {
        if (animations.state == BroSpeechScriptController.States.AwaitingPlayerResponse)
        {
            animations.state = BroSpeechScriptController.States.ChooseTaxi;
        }
        Debug.Log("Advisor one ran command!");
    }
}
