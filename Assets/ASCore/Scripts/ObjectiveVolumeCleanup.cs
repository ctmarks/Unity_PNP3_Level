using UnityEngine;

public class ObjectiveVolumeCleanup : MonoBehaviour {

    [Header("Objective IDs")]
    public string[] objectiveIdentifiers;

    [Header("Who can activate this?")]
    public string neededTag = "Player";

    private ObjectiveList obj;

    void Start () {

        obj = FindObjectOfType<ObjectiveList>();
	}

    void OnTriggerExit(Collider other)
    {
        if(other.tag == neededTag)  //added to check our needed tag
        {
            for(int i = 0; i < objectiveIdentifiers.Length; i++)
            {
                obj.RemoveObjective(objectiveIdentifiers[i]);
            }
            
            Destroy(gameObject);
        }
    }
}
