using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//게임 시작 관리하는 매니저 스크립트
//부엌 불로 시작하는가 아니면 담배 불로 시작하는가

public class GamePlayManager : MonoBehaviour
{
    //비상벨 끄기 만들기 태그:FireAlarm

    //부엌불로 시작하는지 아니면 그냥 불로 시작하는지
    public enum GameState { JustFire = 0, KitchenFire = 1,ElectricFire=2}
    //조건들 나열
    public GameState FireStart = GameState.KitchenFire;
    //랜덤값 받을 발화 조건
    public float SmokeDeathTime = 3f;
    public bool IsGameEnd = false;
    //게임 끝났는지 아닌지 저장하는 변수
    public  bool SmokeDeath;  // *시간제한으로인해 죽었는가?
    public  bool fireoff; // *불이 꺼졌는가?
    public  bool escape; // *탈출했는가?
    public bool BodyBurn = false;   //화상입었을 때
    public bool ElecDeath = false;
    public bool KitchenFireDeath = false;
    public List<GameObject> CollapsingFire = new List<GameObject>();
    // Start is called before the first frame update
    IEnumerator TimeOut()
    {
        while (IsGameEnd == false)
        {
            yield return new WaitForSeconds(SmokeDeathTime);
            IsGameEnd =true;
        }
    }
    IEnumerator CheckingCollapsingFire()
    {
        while (IsGameEnd == false)
        {
            CollapsingFire.Clear();
            for(int i = 0; i < GameObject.FindGameObjectsWithTag("Fire").Length; i++)
            {
                if (GameObject.FindGameObjectsWithTag("Fire")[i].GetComponent<NormalFire>().FireCollapse == true)
                {
                    CollapsingFire.Add(GameObject.FindGameObjectsWithTag("Fire")[i].gameObject);
                }
            }
            for(int j = 0; j < CollapsingFire.Count-1; j++)
            {
                if (!CollapsingFire[j])
                {
                    continue;
                }
                else
                {

                    for (int k = j + 1; k < CollapsingFire.Count; k++)
                    {
                        if (CollapsingFire[k])
                        {
                            if (CollapsingFire[j].transform.position == CollapsingFire[k].transform.position)
                            {
                                int Rand = Random.Range(0, 2);
                                if (Rand == 0)
                                {
                                    Destroy(CollapsingFire[j]);
                                }
                                if (Rand == 1)
                                {
                                    Destroy(CollapsingFire[k]);
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            yield return new WaitForSeconds(.5f);
        }
    }
    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "k_fire":
                FireStart = GameState.KitchenFire;
                break;
            case "elecfire":
                FireStart = GameState.ElectricFire;

                break;
            case "fire":
                FireStart = GameState.JustFire;
                StartCoroutine(CheckingCollapsingFire());

                break;
        }
        GameObject pot;
        pot = GameObject.Find("pot");
        if (pot.GetComponent<Rigidbody>().constraints != RigidbodyConstraints.FreezeRotation)
        {
            pot.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
        StartCoroutine(TimeOut());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
