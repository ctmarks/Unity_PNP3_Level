using UnityEngine;
using System.Collections;

public class MultiMessageVolume : MonoBehaviour {

    private MessageSystem msg; //local variable to store the message system

    public string msgFrom; //who is sending the message?
    public string[] msgBody; //what does the message say?
    public float msgTime; //how long does this message show?
    private bool startSequence = false; //start sending out messages
    private float sequenceTime = 0;
    private int msgNumber = 0;

    // Use this for initialization
    void Start()
    {
        //store the message system
        msg = GameObject.FindObjectOfType<MessageSystem>();

        sequenceTime = msgTime;
    }

    void Update()
    {
        if (GameObject.FindObjectsOfType<MultiMessageVolume>().Length > 1)
            Destroy(gameObject);

        if (startSequence == true)
        {
            if (msgNumber < msgBody.Length)
            {
                if (sequenceTime >= msgTime)
                {
                    msg.NewMessage(msgFrom, msgBody[msgNumber], msgTime);
                    sequenceTime = 0;
                    msgNumber++;
                }
                else
                {
                    sequenceTime += Time.deltaTime;
                }
            }
            else
            {
                startSequence = false;
            }
        }
        
    }

    //When a collider enters in our trigger volume
    void OnTriggerEnter(Collider other)
    {
        //is it the player?
        if (other.tag == "Player")
        {
            //send messages
            startSequence = true;
        }
    }
}
