using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot_grip : MonoBehaviour
{
    public bool isPlayerEnter;
    public bool isgripOn;
    public GameObject Playerhand;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerEnter = false;
        isgripOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerEnter == true && isgripOn == false)
        {
            transform.SetParent(Playerhand.transform);

            isgripOn = true;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            
        }

        else if (Input.GetKeyDown(KeyCode.E) && isgripOn == true)
        {
            Playerhand.transform.DetachChildren();
        
            isgripOn = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerEnter = true;
            other.attachedRigidbody.useGravity = false;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isPlayerEnter = false;
            other.attachedRigidbody.useGravity = true;
        }
    }

}
