using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firewater : MonoBehaviour
{
    public GameObject wat;

    // Start is called before the first frame update
    void Start()
    {
        wat = GameObject.Find("Water&Pot").transform.Find("TestWater").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "pot")
        {
            if (wat.activeInHierarchy == true)
            {
                wat.SetActive(false);
                Destroy(gameObject, 2.0f);
            }
        }
    }
}
