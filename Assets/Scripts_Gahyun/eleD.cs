using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eleD : MonoBehaviour
{
    public static bool Ele_in;

    // Start is called before the first frame update
    void Start()
    {
        Ele_in = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("PlayerIN");
            Ele_in = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        print("PlayerOUT");
        Ele_in = false;
    }
}
