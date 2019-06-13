using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Door : MonoBehaviour
{
    public GameObject otherDoor;
    public GameObject Button;

    // Start is called before the first frame update
    void Start()
    {

        if(this.gameObject.transform.parent.gameObject.tag == "Untagged")
        {
            Destroy(this.gameObject.GetComponent<Elevator_Door>());
        }
            if (this.gameObject.name == "Elevator_Door")
        {
            if (!otherDoor)
            {
                otherDoor=transform.parent.transform.Find("Elevator_Door_Right").gameObject;
            }
            if (!Button)
            {
                Button=transform.parent.transform.Find("ElevatorButton").gameObject;
            }
        }
        else
        {
            if (!otherDoor)
            {
                otherDoor = transform.parent.transform.Find("Elevator_Door").gameObject;
            }
            if (!Button)
            {
                Button = transform.parent.transform.Find("ElevatorButton").gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject == otherDoor)
        {
            
                if (Button.GetComponent<Elevator>().CurrentDoor == Elevator.DoorState.Closing)
                {
                    print("엘베_문닫힘");
                    Button.GetComponent<Elevator>().CurrentDoor = Elevator.DoorState.Closed;
            }
            
        }
    }
}
