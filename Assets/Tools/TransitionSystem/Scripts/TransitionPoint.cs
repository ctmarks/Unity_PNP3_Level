using UnityEngine;

public class TransitionPoint : MonoBehaviour {

    private TransitionSystem tranSys;
    public TransitionPoint exitPoint;
    private MessageSystem msg;

    public bool interactRequired = false;

    public bool isHere = false;
    public bool isExit = false;

    public Vector3 oldPos;

    void Start()
    {
        msg = GameObject.FindObjectOfType<MessageSystem>();
        tranSys = GameObject.FindObjectOfType<TransitionSystem>();
        transform.parent = tranSys.transform;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            oldPos = other.transform.position;
            if(interactRequired == false)
            {
                StartTransition(other);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(interactRequired == true)
            {
                msg.NewMessage(gameObject.name, "Press <b>E</b> to <b>INTERACT</b>", 0.5f);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    StartTransition(other);
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isExit = false;
            isHere = false;
        }
    }

    void StartTransition(Collider other)
    {
        if (tranSys.playerPos == null)
        {
            tranSys.playerPos = other.transform;
        }

        if (isExit == false)
        {
            isHere = true;
            oldPos = tranSys.playerPos.position;
            tranSys.fadeOut = true;
        }
    }

    public void TeleportMe()
    {
        tranSys.playerPos.position = exitPoint.transform.position;
    }
}