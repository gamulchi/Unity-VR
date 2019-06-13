using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalFire : MonoBehaviour
{
    //기본 불(거실 불)에 달린 스크립트
    public float time = 3;
    public float x, y, z;
    public GameObject Smoke;
    public bool OnFire = false;
    public enum FireStart { StopFire = 0, NeedFire = 1, FireStarted = 2 };
    public FireStart FireState = FireStart.StopFire;
    public GameObject FireEffect;
    public GameObject Ground;
    public bool FireCollapse = false;
    public GameObject Player;
    public List<GameObject> CheckingFire = new List<GameObject>();
    public GameObject GManager;
    public GameObject FireOff;

    // 내 주변에는 불이 있는지 없는지 체크
    //만약 d
    // Start is called before the first frame update
    IEnumerator MakeFire()
    {
        //불이 다른 불을 만드는 함수
        while (FireState != 0)
        {
          
            print("makefire");
            yield return new WaitForSeconds(time);

            FireState = FireStart.FireStarted;
            if (GManager.GetComponent<GamePlayManager>().IsGameEnd == false)
            {
                for (int i = 0; i < CheckingFire.Count; i++)
                {
                    if (CheckingFire[i].GetComponent<CheckingNearFire>().IsFireHere == false)
                    {
                        Instantiate(FireEffect, new Vector3(
                            CheckingFire[i].transform.position.x, CheckingFire[i].transform.position.y, CheckingFire[i].transform.position.z), Quaternion.identity);
                    }
                }

            }
        }
    }
    void Start()
    {
        FireEffect = Resources.Load("fire") as GameObject;
        GManager = GameObject.FindGameObjectWithTag("GameManager");
        if(!Player){
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        if (!Smoke)
        {
            Smoke = GameObject.FindGameObjectWithTag("Smoke");
        }
        Ground = GameObject.FindGameObjectWithTag("Ground");

        //파이어이펙트는 Resources폴더 안에 있는 fire 파일이다
        FireEffect = (GameObject)Resources.Load("fire");
        if (gameObject.name != "KitchenFire")
        {
            if (CheckingFire.Count < 1)
            {
                CheckingFire.Add(transform.Find("SearchingFireFront").gameObject);
                CheckingFire[0].transform.localPosition = Vector3.forward;
                CheckingFire.Add(transform.Find("SearchingFireBack").gameObject);
                CheckingFire[1].transform.localPosition = Vector3.back;
                CheckingFire.Add(transform.Find("SearchingFireLeft").gameObject);
                CheckingFire[2].transform.localPosition = Vector3.left;
                CheckingFire.Add(transform.Find("SearchingFireRight").gameObject);
                CheckingFire[3].transform.localPosition = Vector3.right;
                CheckingFire.Add(transform.Find("SearchingFireCenter").gameObject);
                CheckingFire[4].transform.localPosition = new Vector3(0, 0, 0);
            }
            StartCoroutine(MakeFire());
        }
        if (!FireOff)
        {
            FireOff = GameObject.FindGameObjectWithTag("Canvas").transform.Find("fireoff").gameObject;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (GManager.GetComponent<GamePlayManager>().IsGameEnd == true)
        {
            StopAllCoroutines();
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {

            GManager.GetComponent<GamePlayManager>().IsGameEnd = true;
        }
        if (other.gameObject.tag == "Ex_Water")
        {
            //소화액이랑 닿으면
         GManager.GetComponent<GamePlayManager>().IsGameEnd = true;
            GManager.GetComponent<GamePlayManager>().escape = true;
            FireOff.SetActive(true);
            Winner.fireoff = true;

            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "water")
        {
            Winner.fireoff = true;
            Destroy(this.gameObject);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "water")
        {
            Winner.fireoff = true;
            Destroy(this.gameObject, 1f);
        }

        if (gameObject.name != "KitchenFire")
        {
            if (other.gameObject.tag == "Ground")
            {
                if (FireState == 0)
                {
                    FireState = FireStart.NeedFire;
                }
            }
            if (other.gameObject.tag == "Fire")
            {
                //다른 불과 부딪힐 경우-> 부딪힌 곳에서 생성 안함
            }
        }
        if (other.gameObject.tag == "Fire")
        {
            //다른 불과 부딪힐 경우
            FireCollapse = true;
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (gameObject.name != "KitchenFire")
        {

            if (other.gameObject.tag == "Ground")
            {
                print("FIRE IS OUT of GROUND ");
                if (FireState != 0)
                {
                    FireState = 0;
                }
            }
        }
        if (other.gameObject.tag == "Fire")
        {
            FireCollapse = false;
        }

    }

}
