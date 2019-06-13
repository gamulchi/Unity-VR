using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePinTouch : MonoBehaviour
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
        if ((other.gameObject.tag == "RightHand")||(other.gameObject.tag == "LeftHand"))
        {
            print("HAND");
            if (gameObject.transform.parent.gameObject.GetComponent<Fe_Test>().SafePinOut != false)
            {
                gameObject.transform.parent.gameObject.GetComponent<Fe_Test>().SafePinOut = true;
            }


        }
    }
    private void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.tag == "RightHand") || (other.gameObject.tag == "LeftHand"))
        {
            print("HAND");
            if (gameObject.transform.parent.gameObject.GetComponent<Fe_Test>().SafePinOut == false)
            {
                gameObject.transform.parent.gameObject.GetComponent<Fe_Test>().SafePinOut = true;
            }


        }
    }
}
