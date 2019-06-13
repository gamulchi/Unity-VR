using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sudo: MonoBehaviour
{
    public GameObject wa;
    // Start is called before the first frame update
    void Start()
    {
        if (wa.activeInHierarchy == true)
        {
            wa.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "pot")
        {
            wa.SetActive(true);
        }
    }
}
