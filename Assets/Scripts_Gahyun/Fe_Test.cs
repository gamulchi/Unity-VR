using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fe_Test : MonoBehaviour
{
    public GameObject LeftHandHose;
    public GameObject RightHandHose;
    public bool LHandLeverHold = false;
    public bool RHandLeverHold = false;
    public bool IsOtherHandEmpty = false;
    //레버를 당기지 않은 손의 반대쪽 손이 비어있는가?
    public bool PressFETrigger = false;
    //플레이어가 소화기 레버를 당겼는가?
    public GameObject FE_Lever;
    public bool SafePinOut = false;
    public GameObject SafePin;
    public bool IsWaterOn = false;
    public float PinOutSpeed = .05f;
    //핀이 빠지는 속도
    public float BeginningPinPosZ;
    //초기 핀 로컬 z좌표
    public float PinRotationSpeed = 1f;
    public GameObject Player;
    //소화기 레버 잡고있으면 무조건 손에 부착되도록!!
    //소화기를 <잡고있지않은>!!! Player의 컨트롤러 손에 
    //소화기 호스 끝부분이 부착되도록 활성화&& 호스 끝에서 물 나옴
    //소화기 호스 부분 비활성화
    //소화기 잡고&&손잡이 안누름->호스 그대로
    public GameObject HosePart;
    //소화액 나올때 비활성화 처리 되는 HosePart
    public float MakingTime = 0;
    public bool HandTouch = false;
    void Start()
    {
        if (this.gameObject.transform.parent.gameObject.tag=="Untagged")
        {
            print(this.gameObject.name + " Untagged" + "FE_TEST");
            Destroy(this.gameObject.GetComponent<Fe_Test>());
        }
        if (!FE_Lever)
        {
            FE_Lever = transform.Find("RealLever").gameObject;
        }
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
        if (!HosePart)
        {
            HosePart = transform.Find("HosePart").gameObject;
        }
        if (!SafePin)
        {
            SafePin = transform.Find("SafePin").gameObject;
        }
        if (!LeftHandHose)
        {
            LeftHandHose = GameObject.FindGameObjectWithTag("Player").transform.Find("MainCamera").transform.Find("LeftHand").transform.Find("Left_Extinguisher_Pipe").gameObject;
        }
        if (!RightHandHose)
        {
            RightHandHose = GameObject.FindGameObjectWithTag("Player").transform.Find("MainCamera").transform.Find("RightHand").transform.Find("Right_Extinguisher_Pipe").gameObject;
        }
        BeginningPinPosZ = SafePin.transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (SafePinOut == true)
        {            //트리거 누른 상태로 안전핀을 뽑았으면

            //안전핀이 아직 안뽑힌 상태라면
            if (SafePin.activeInHierarchy == true)
            {
                SafePin.transform.Translate(new Vector3(0,1, 0) * PinOutSpeed * Time.deltaTime);
                if (SafePin.transform.localPosition.z >=BeginningPinPosZ+0.01f)
                {
                    SafePin.SetActive(false);

                }
                //안전핀 움직이는 함수

            }
        }

        if (SafePin.activeInHierarchy==false)
        {
            if (LHandLeverHold==true&&RHandLeverHold==false)
            {
                print("LL");
                //하는 동안에만.-->while쓰면 오류날듯
                if (LeftHandHose.activeInHierarchy == true)
                {
                    LeftHandHose.SetActive(true);
                }
                if (RightHandHose.activeInHierarchy ==false)
                {
                    RightHandHose.SetActive(true);
                }
            }
            if (RHandLeverHold == true& LHandLeverHold == false)
            {
                print("RR");
                if (LeftHandHose.activeInHierarchy ==false)
                {
                    LeftHandHose.SetActive(true);
                }
                if (RightHandHose.activeInHierarchy ==true)
                {
                    RightHandHose.SetActive(false);
                }
            }
            if (LHandLeverHold == false&& RHandLeverHold == false)
            {
                if (LeftHandHose.activeInHierarchy == true)
                {
                    LeftHandHose.SetActive(false);
                }
                if (RightHandHose.activeInHierarchy == true)
                {
                    RightHandHose.SetActive(false);
                }
            }
        }
        else
        {

        }
    }
    private void OnTriggerEnter(Collider other)
    {

    }

}
