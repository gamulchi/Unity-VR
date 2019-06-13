using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{       //이거는 탈출 or 불을껏을때 사용하는 거 ..탈출용도 따로 만들어야겟당
    //엔딩1.전기화재2.탈출-비상벨안울리고3.탈출-비상벨울리고4.질식사5.엘베6.화상
    public static bool fireoff = false;
    public float ElevatorDeathTime = 10f;
    public GameObject GManager;

    #region 엔딩
    public GameObject KillFireEnding;   //불끔엔딩
    public GameObject winImage; //옥상탈출=계단탈출
    public GameObject NoAlarmImg;   //알람 안울리고 탈출
    public GameObject KitchenEnding;    //부엌엔딩
    public GameObject ElecEnding;   //전기화재
    public GameObject SmokeEnding;  //연기엔딩
    public GameObject BurnEnding;   //화상엔딩->hit스크립트에 구현
    public GameObject DeadzoneImage;    //엘베엔딩

    #endregion
    public GameObject ElevatorButton;
    public AudioSource AlarmAudio;
    //알람이 울렸는지 아닌지 알아보기 위해 알람을 찾아 할당하는 변수
    // Start is called before the first frame update
    void Start()
    {
        NoAlarmImg = this.gameObject.transform.Find("NoAlarm").gameObject;

        AlarmAudio = GameObject.FindGameObjectWithTag("FireAlarm").transform.Find("inbutton").gameObject.GetComponent<AudioSource>();
        GManager = GameObject.FindGameObjectWithTag("GameManager");
        if (!ElevatorButton)
        {
            ElevatorButton = GameObject.FindGameObjectWithTag("Elevator").transform.Find("ElevatorButton").gameObject;
        }
        winImage = this.gameObject.transform.Find("winImage").gameObject;
        fireoff = false;
        KillFireEnding = this.gameObject.transform.Find("fireoff").gameObject;
        BurnEnding = this.gameObject.transform.Find("BurnEnding").gameObject;
        ElecEnding = this.gameObject.transform.Find("ElectricEnding").gameObject;
        winImage.SetActive(false);
        KitchenEnding = gameObject.transform.Find("KitchenDeath").gameObject;
        DeadzoneImage = this.gameObject.transform.Find("eledeath").gameObject;
        DeadzoneImage.SetActive(false);
        SmokeEnding = gameObject.transform.Find("Smoke").gameObject;
        if (!AlarmAudio)
        {
            print("비상벨을 못찾겠음");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (GManager.GetComponent<GamePlayManager>().IsGameEnd == true)
        {
            //게임이 끝났는가?
            #region 불끄기 엔딩
            if (fireoff == true)
            {
                Debug.Log("확인");

                Invoke("KillFireEndingFunc", 2.0f);
            }
            #endregion
            else
            {
                #region 연기 엔딩
                if (GManager.GetComponent<GamePlayManager>().SmokeDeath == true)
                {
                    if (SmokeEnding.activeInHierarchy == false)
                    {
                        SmokeEnding.SetActive(true);
                    }
                }
                #endregion
                if (GManager.GetComponent<GamePlayManager>().escape == true)
                {
                    #region 비상벨 안누르고 탈출 엔딩
                    if (AlarmAudio.isPlaying == false && alarmsound.isalram == false)
                    {
                        if (NoAlarmImg.activeInHierarchy == false)
                        {
                            NoAlarmImg.SetActive(true);
                        }
                    }
                    #endregion
                    #region 비상벨 키고 탈출 엔딩
                    else
                    {
                        AlarmAudio.Stop();
                        if (winImage.activeInHierarchy == false)
                        {
                            winImage.SetActive(true);
                        }
                    }
                    #endregion
                }
            }
            #region 화상엔딩
            if (GManager.GetComponent<GamePlayManager>().BodyBurn == true)
            {
                if (BurnEnding.activeInHierarchy == false)
                {
                    BurnEnding.SetActive(true);
                }
            }
            #endregion
            #region 부엌엔딩
            if (GManager.GetComponent<GamePlayManager>().KitchenFireDeath == true)
            {
                if (KitchenEnding.activeInHierarchy == false)
                {
                    KitchenEnding.SetActive(true);
                }
            }
            #endregion
            #region 전기화재엔딩
            if (GManager.GetComponent<GamePlayManager>().ElecDeath == true)
            {
                if (ElecEnding.activeInHierarchy == false)
                {
                    ElecEnding.SetActive(true);
                }
            }
            #endregion

        }

        #region 엘베엔딩
        if (ElevatorButton.GetComponent<Elevator>().CurrentDoor == Elevator.DoorState.Closed)
        {
            if (eleD.Ele_in == true)
            {
                Invoke("DeadzoneImageOn", ElevatorDeathTime);
            }
        }
        #endregion

    }
    public void DeadzoneImageOn()
    {

        DeadzoneImage.SetActive(true);
        if (GManager.GetComponent<GamePlayManager>().IsGameEnd != true)
        {
            GManager.GetComponent<GamePlayManager>().IsGameEnd = true;
            GManager.GetComponent<GamePlayManager>().escape = false;
        }
        if (AlarmAudio.isPlaying == true)
        {
            AlarmAudio.Stop();
        }
    }
    #region 불끄기 엔딩 함수
    public void KillFireEndingFunc()
    {
        if (KillFireEnding.activeInHierarchy == false)
        {
            KillFireEnding.SetActive(true);
        }

    }
    #endregion




}
