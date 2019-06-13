using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escap : MonoBehaviour
{
    public bool isPlayerEnter;
    public GameObject GManager;
    // Start is called before the first frame update
    void Start()
    {
        isPlayerEnter = false;
        GManager = GameObject.FindGameObjectWithTag("GameManager").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerEnter == true)
        {
  
            GManager.GetComponent<GamePlayManager>().IsGameEnd = true;
            GManager.GetComponent<GamePlayManager>().escape = true;
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
