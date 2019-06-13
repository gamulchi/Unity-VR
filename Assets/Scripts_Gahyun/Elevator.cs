using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject Elevator_Door1;   //왼쪽문
    public GameObject Elevator_Door2;   //오른쪽 문
    public float speed = .01f;   //속도
    public enum DoorState { Closed = 0, Opening = 1, Closing = 2 };
    public DoorState CurrentDoor = DoorState.Closed;
    public float ElevatorTime = 1.5f;
    private bool touch = false;
    public bool CSTART = false;
    public Vector3 Door1StartPos;
    public Vector3 Door2StartPos;

    // Start is called before the first frame update
    IEnumerator ChangeState()
    {
        
        while (CurrentDoor == DoorState.Opening)
        {
            CSTART = true;
            yield return new WaitForSeconds(ElevatorTime);
            CurrentDoor = DoorState.Closing;
        }
    }

    void Start()
    {
        Elevator_Door1 = transform.parent.transform.Find("Elevator_Door").gameObject;
        Elevator_Door2 = transform.parent.transform.Find("Elevator_Door_Right").gameObject;
        Door1StartPos = Elevator_Door1.transform.localPosition;
        Door2StartPos = Elevator_Door2.transform.localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentDoor == DoorState.Closed)
        {
            CSTART = false;
        }
        //Input.GetKeyDown(KeyCode.E) && 
        if (CurrentDoor == DoorState.Opening)
        {
            
            Elevator_Door1.transform.Translate(Vector3.left * speed * Time.deltaTime);
            Elevator_Door2.transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (CSTART == false)
            {
                StartCoroutine(ChangeState());
            }
        }
        if (CurrentDoor == DoorState.Closing)
        {
            Elevator_Door1.transform.Translate(Vector3.right * speed * Time.deltaTime);
            Elevator_Door2.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if ((Elevator_Door1.transform.localPosition.x < Door1StartPos.x - .6f)||
            (Elevator_Door2.transform.localPosition.x > Door1StartPos.x + .6f))
        {
         //   CurrentDoor = DoorState.Closing;
        }
    }
    //손 태그와 충돌하면 문이동(리지드바디 추가와 Is Trigger 체크해야 동작)
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")  //왼쪽문 이동
        {
            if (CurrentDoor != DoorState.Opening)
            {
                //문이 열리고 있는 상태가 아니라면
                CurrentDoor = DoorState.Opening;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        touch = false;
    }
}