using UnityEngine;

public class ObjectiveVolumeCreate : MonoBehaviour {

    [Header("Objective to create")]
    public string objectiveIdentifier = "";
    public string objectiveName = "";

    [Header("Who can activate this?")]
    public string neededTag = "Player";

    [Header("Activate ObjectiveVolumeComplete after creation?")]
    public GameObject objectiveVolume;

    private ObjectiveList obj;
    private MessageSystem msg;

    private string msgFrom = "New Objective";
    private string msgBody;
    private float msgTime = 3.0f;

    void Start () {

        obj = FindObjectOfType<ObjectiveList>();

        if(objectiveVolume != null)
            objectiveVolume.SetActive(false); //hide our objective

        msg = FindObjectOfType<MessageSystem>();
    }
	
	void OnTriggerEnter(Collider other)
    {
        if(other.tag == neededTag)  //now checking for our needed Tag
        {
            obj.CreateObjective(objectiveIdentifier, objectiveName);  //create our objective
            msg.NewMessage(msgFrom, "<b><color=yellow> " + objectiveName + "</color></b>", msgTime);

            if(objectiveVolume != null)
                objectiveVolume.SetActive(true);  //unhide our objective

            Destroy(gameObject);  //remove volume
        }
    }
}
