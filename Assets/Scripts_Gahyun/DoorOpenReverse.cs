using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenReverse : MonoBehaviour
{
    //문이 열렸는지 확인
    public bool isopen;
    //각도
    public float angle = 80;
    //돌릴 문 오브젝트 가져오기
    public GameObject parent;
    //손잡이를 잡았는지?
    public bool isgrip;

    private void Start()
    {
        if (!parent)
        {
            parent = transform.parent.gameObject;
        }
        isopen = false;
    }


    //충돌이 일어났다면 손잡이를 잡은상태
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isgrip = true;
        }
    }
    //충돌이 끝났다면 손잡이를 잡은상태아님
    private void OnTriggerExit(Collider other)
    {
        isgrip = false;
    }

    private void Update()
    {
        //손잡이를 잡은상태이며 문이 닫친상태라면 E키를 누르면 문이 열림.
        if (Input.GetKeyDown(KeyCode.E) && isopen == false && isgrip == true)
        {
            isopen = true;
            parent.transform.Rotate(0, 0, -angle);
        }

        //손잡이를 잡은상태이며 문이 열린상태라면 E키를 누르면 문이 닫힘.
        else if (Input.GetKeyDown(KeyCode.E) && isopen == true && isgrip == true)
        {
            isopen = false;
            parent.transform.Rotate(0, 0, angle);
        }
    }
}
