using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elec : MonoBehaviour
{
    public GameObject wa;
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
        if(other.gameObject.tag == "pot")
        {
            if (wa.activeInHierarchy == true)
            {
                Debug.Log("바보");
            }
        }
    }
}
