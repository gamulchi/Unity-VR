using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewater : MonoBehaviour
{
    public GameObject wat;

    // Start is called before the first frame update
    void Start()
    {
        if (!wat)
        {
            wat = GameObject.FindGameObjectWithTag("pot").gameObject.transform.Find("Cylinder").gameObject;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "pot")
        {
            wat = other.transform.Find("Cylinder").gameObject;
            if (wat.activeInHierarchy==true)
            {
                wat.SetActive(false);
                Destroy(gameObject, 2.0f);
            }
        }
    }
}
