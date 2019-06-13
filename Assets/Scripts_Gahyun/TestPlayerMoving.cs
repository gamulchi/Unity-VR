using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMoving : MonoBehaviour
{
    
    public static float CamSpeed = 100f;
    public GameObject MainCam;
    public float xrot;
    public float yrot;
    // Start is called before the first frame update
    void Start()
    {
        MainCam = GameObject.FindGameObjectWithTag("MainCamera");
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        
    }
    void PlayerMove()
    {
        //transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * CamSpeed);
        MainCam.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), /*Input.GetAxis("Mouse X")*/0, 0) * Time.deltaTime * CamSpeed);
        xrot = MainCam.transform.rotation.x;
        yrot = MainCam.transform.rotation.y;
        //if (MainCam.transform.rotation.z != 0)
        //{
        //    print("x" + xrot + "y" + yrot);
        //    MainCam.transform.localEulerAngles=new Vector3(xrot, yrot, 0);
        //}

        Quaternion zlock = MainCam.transform.localRotation;
        zlock.z = 0;
        MainCam.transform.localRotation = zlock;

    }
    private void LateUpdate()
    {
    }
}