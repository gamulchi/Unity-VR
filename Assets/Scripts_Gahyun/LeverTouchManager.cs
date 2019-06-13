using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//소화기 움직이는 레버에 달린 스크립트
public class LeverTouchManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RightHand")
        {
            this.gameObject.transform.parent.gameObject.GetComponent<Fe_Test>().RHandLeverHold = true;

        }
        else if (other.gameObject.tag == "LeftHand")
        {
            this.gameObject.transform.parent.gameObject.GetComponent<Fe_Test>().LHandLeverHold = true;


        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "RightHand")
        {

            this.gameObject.transform.parent.gameObject.GetComponent<Fe_Test>().RHandLeverHold = true;

        }
        else if (other.gameObject.tag == "LeftHand")
        {
            this.gameObject.transform.parent.gameObject.GetComponent<Fe_Test>().LHandLeverHold = true;


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RightHand")
        {
            this.gameObject.transform.parent.gameObject.GetComponent<Fe_Test>().RHandLeverHold = false;

        }
        else if (other.gameObject.tag == "LeftHand")
        {
            this.gameObject.transform.parent.gameObject.GetComponent<Fe_Test>().LHandLeverHold = false;


        }
    }
}

