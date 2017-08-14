using UnityEngine;

public class MessageVolume : MonoBehaviour {

    private MessageSystem msg; //local variable to store the message system

    [Header("Who/What said it?")]
    public string msgFrom; //who is sending the message?
    [Header("What is being said?")]
    public string msgBody; //what does the message say?
    [Header("How long is it being displayed? (in seconds)")]
    [Range(1, 10)]
    public int msgTime; //how long does this message show?
    [Header("Does it vanish forever after being displayed?")]
    public bool onlyOnce = false; //do we only want this message to show one time?

    // Use this for initialization
    void Start()
    {
        //store the message system
        msg = GameObject.FindObjectOfType<MessageSystem>();
    }

    //When a collider enters our trigger volume
    void OnTriggerEnter(Collider other)
    {
        //is it the player?
        if (other.tag == "Player")
        {
            //send a new message
            msg.NewMessage(msgFrom,msgBody,msgTime);
        }
    }

    //When a collider exits our trigger volume
    void OnTriggerExit(Collider other)
    {
        //was it the player?
        if (other.tag == "Player")
        {
            //are we only showing this once?
            if (onlyOnce)
                Destroy(this.gameObject); //destroy this message volume
        }
    }
}
