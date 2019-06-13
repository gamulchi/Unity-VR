using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHand : MonoBehaviour
{
    public bool IsLeftHand = false;
    public GameObject HandHose;
    public bool HandTrigger = false;
    public GameObject WaterEffect;
    //컨트롤러가 트리거 당겼는지 아닌지 알려주는 함수
    // Start is called before the first frame update
    void Start()
    {
        if (!WaterEffect)
        {
            WaterEffect = transform.Find("WaterfallSmallEffect").gameObject;
        }
        if (this.gameObject.name == "LeftHand")
        {
            IsLeftHand = true;
        }
        if (!HandHose)
        {
            if (IsLeftHand == true)
            {
                HandHose = transform.Find("Left_Extinguisher_Pipe").gameObject;
            }
            else
            {
                HandHose = transform.Find("Right_Extinguisher_Pipe").gameObject;
            }
        }
        CheckingObj();
    }

    // Update is called once per frame
    void Update()
    {
        MyHandManaging();
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Extinguisher")
        {

            if (other.gameObject.name == "SafePin")
            {
                other.gameObject.GetComponent<Fe_Test>().SafePinOut = true;
                print("Pin");
            }
            if (other.gameObject.name == "Lever ")
            {
                print("Lever");
            }
           
        }
    }
    void MyHandManaging()
    {
        if (HandHose.activeInHierarchy == true)
        {
            WaterEffect.SetActive(true);
        }
        if (HandHose.activeInHierarchy == false)
        {
            WaterEffect.SetActive(false);
        }
    }
    void CheckingObj()
    {
        if (!WaterEffect)
        {
            print("NO_HAND_WAter");
        }
        if (this.gameObject.name == "LeftHand")
        {
            IsLeftHand = true;
        }
        if (!HandHose)
        {
            if (IsLeftHand == true)
            {
                print("왼쪽_호스 없음");
            }
            else
            {
                print("오른쪽 호스 없음");
            }
        }

    }
}
