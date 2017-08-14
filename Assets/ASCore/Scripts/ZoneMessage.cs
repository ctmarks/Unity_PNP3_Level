using UnityEngine;
using System.Collections;

public class ZoneMessage : MonoBehaviour {

    [Header("Name to display to the Minimap")]
    public string levelName;
    private ZoneSystem zs;

    void Start()
    {
        zs = GameObject.FindObjectOfType<ZoneSystem>();
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            zs.NewMessage(levelName);
        }
    }
}
