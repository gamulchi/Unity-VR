using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenWater: MonoBehaviour
{
    //수도꼭지 물!!
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
