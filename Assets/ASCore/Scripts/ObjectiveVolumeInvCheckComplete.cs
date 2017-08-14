using UnityEngine;

public class ObjectiveVolumeInvCheckComplete : MonoBehaviour {

    [Header("Objective to complete")]
    public string objectiveIdentifier = "";
    public string objectiveName = "";

    private Scraps_HUD_Inventory inv;
    public string itemType = "";
    public int itemNum = 0;

    private ObjectiveList obj;

    private MessageSystem msg;

    private string msgFrom = "Objective Complete";
    private float msgTime = 3.0f;

    void Start () {

        obj = FindObjectOfType<ObjectiveList>();
        msg = FindObjectOfType<MessageSystem>();
        inv = FindObjectOfType<Scraps_HUD_Inventory>();
	}

    void Update()
    {
        if(inv.GetPickupAmount(itemType) >= itemNum)
        {
            obj.CompleteObjective(objectiveIdentifier);
            msg.NewMessage(msgFrom, "You've completed <b><color=green> " + objectiveName + "</color></b>", msgTime);

            Destroy(gameObject);
        }
    }
}
