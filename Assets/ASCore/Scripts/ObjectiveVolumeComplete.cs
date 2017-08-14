using UnityEngine;

public class ObjectiveVolumeComplete : MonoBehaviour {

    [Header("Objective to complete")]
    public string objectiveIdentifier = "";
    public string objectiveName = "";

    [Header("Who can activate this?")]
    public string neededTag = "Player";

    private ObjectiveList obj;

    private MessageSystem msg;

    private string msgFrom = "Objective Complete";
    private string msgBody;
    private float msgTime = 3.0f;

    void Start () {

        obj = FindObjectOfType<ObjectiveList>();
        msg = FindObjectOfType<MessageSystem>();
	}
	
	void OnTriggerEnter(Collider other)
    {
        if(other.tag == neededTag)  //now checking for our needed Tag
        {
            obj.CompleteObjective(objectiveIdentifier);
            msg.NewMessage(msgFrom, "You've completed <b><color=green> "+objectiveName +"</color></b>", msgTime);

            Destroy(gameObject);
        }
    }
}
