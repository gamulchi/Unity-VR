﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grip_EX : MonoBehaviour
{
    public bool isPlayerEnter;
    public bool isgripOn;
    public GameObject Playerhand; // Player 안에있는 lefthand -> grip 을 붙여넣어야함
    public GameObject hos; // 소화기 호스 없애기 위해 
    public GameObject water;
    // Start is called before the first frame update
    void Start()
    {
        isPlayerEnter = false;
        isgripOn = false;
        water = GameObject.FindGameObjectWithTag("Player").transform.Find("MainCamera").transform.Find("LeftHand").transform.Find("WaterfallSmallEffect").gameObject;
        water.SetActive(false);

    }
        
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerEnter == true && isgripOn == false)
        {
            transform.SetParent(Playerhand.transform);
            transform.localPosition = new Vector3(0, -3, -1.5F);
            isgripOn = true;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            hos.SetActive(false);
        }

        else if (Input.GetKeyDown(KeyCode.E) && isgripOn == true)
        {
            Playerhand.transform.DetachChildren();

            isgripOn = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
            hos.SetActive(true);
            water.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.F) && water.activeInHierarchy == false && isgripOn == true)
        {
            water.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.F) && water.activeInHierarchy == true && isgripOn == true)
        {
            water.SetActive(false);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerEnter = true;
            
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerEnter = false;
            
        }
    }

}
