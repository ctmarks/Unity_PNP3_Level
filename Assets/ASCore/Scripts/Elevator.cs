using UnityEngine;

public class Elevator : MonoBehaviour {

    //variable to assign the message system to
    private MessageSystem msg;

    //int for which floor we need to go to
    public int goToRmNum = 1;
    //int for what floor we are currently on
    private int curRmNum = 1;

    //two public transforms that can be used for room positions
    public Transform rmPos1;
    public Transform rmPos2;

    //two public strings for the names of our floors
    public string floor1name = "";
    public string floor2name = "";

    //how fast the elevator moves
    public float speed = 1.0f;

    //how close we need to be to a floor before we stop the elevator
    public float snapDist = 0.1f;

    void Start()
    {
        msg = GameObject.FindObjectOfType<MessageSystem>();
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(curRmNum == 1)
                msg.NewMessage("Elevator", "Welcome to the <b>" + floor1name + "</b> floor./n/nPress <b>E</b> to INTERACT with the elevator.", 3.0f);
            else if(curRmNum == 2)
                msg.NewMessage("Elevator", "Welcome to the <b>" + floor2name + "</b> floor./n/nPress <b>E</b> to INTERACT with the elevator.", 3.0f);

            if (Input.GetKeyDown(KeyCode.E) && curRmNum == 2)
            {
                goToRmNum = 1;
            }
            else if(Input.GetKeyDown(KeyCode.E) && curRmNum == 1)
            {
                goToRmNum = 2;
            }
        }
    }

    //once every frame
    void Update()
    {
        //if the go to room is greater than our current room
        if(goToRmNum > curRmNum)
        {
            //move UP
            MoveUp();
        }
        //if the go to room is less than our current room
        else if(goToRmNum < curRmNum)
        {
            //move DOWN
            MoveDown();
        }
        else //neither less than or greater than?
        {
            //don't move
        }

        //if our room is 1
        if(goToRmNum == 1)
        {
            //get the distance between where we are and where the first room position is
            float dist = Vector3.Distance(rmPos1.position, transform.position);

            //if our distance is less than or equal to our snap distance
            if(dist <= snapDist)
            {
                //set our current room
                curRmNum = 1;
                //set our transform position to room 1 position
                transform.position = rmPos1.position;
            }
        }
        //if our room is 2
        else if (goToRmNum == 2)
        {
            //get the distance between where we are and where the second room position is
            float dist = Vector3.Distance(rmPos2.position, transform.position);

            //if our distance is less than or equal to our snap distance
            if (dist <= snapDist)
            {
                //set our current room
                curRmNum = 2;
                //set our transform position to room 1 position
                transform.position = rmPos2.position;
            }
        }
    }

    //custom function to move up
    void MoveUp()
    {
        //move the elevator up the Y axis
        Vector3 newPos = transform.position;
        newPos.y += speed * Time.deltaTime;

        //set our position equal to the new Position
        transform.position = newPos;
    }

    //custom function to move down
    void MoveDown()
    {
        //move the elevator down the Y axis
        Vector3 newPos = transform.position;
        newPos.y -= speed * Time.deltaTime;

        //set our position equal to the new Position
        transform.position = newPos;
    }
}
