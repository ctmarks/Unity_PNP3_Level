using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    private MessageSystem msg;

    void Start()
    {
        msg = GameObject.FindObjectOfType<MessageSystem>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (other.GetComponent<Health>().respawnMarker != transform)
            {
                msg.NewMessage("", "<b>Checkpoint</b> has been reached!", 3.0f);
                other.GetComponent<Health>().respawnMarker = transform;
            }
        }
    }
}
