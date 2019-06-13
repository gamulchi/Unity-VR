using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alarmsound : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip firesound;
    private bool istouch;
    public GameObject GManager;
    public static bool isalram;

    // Start is called before the first frame update
    void Start()
    {
        GManager = GameObject.FindGameObjectWithTag("GameManager").gameObject;
        audio = GetComponent<AudioSource>();
        audio.clip = firesound;
        audio.loop = true;
        istouch = false;
        isalram = false;
    }

    void Update()
    {
        if (!firesound)
        {
            firesound = Resources.Load("Sounds/FireAlarmSound") as AudioClip;
        }
        if (Input.GetKeyDown(KeyCode.E) && istouch == true)
        {
            isalram = true;
            audio.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("P_Touch");
            istouch = true;
        }

    }
    void OnTriggerExit(Collider other)
    {
        istouch = false;
    }
}

