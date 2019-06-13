using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//연기 스크립트
public class SmokeScript : MonoBehaviour
{
    //부엌불, 전기불일 떄만 크게 하도록!!
    //시간간제한으로 인해 죽었을대 이미지를 띄워주는 역할
    public float SmokeTime;
    public float RealTime = 0;
    public GameObject GManager;
    //게임이 끝났는지 아닌지 알려주는 isgameEnd변수값을 알기 위해 Gmanager
    public GameObject CurrentFire;
    //현재 씬의 불을 참조 ->전기 화재인가, 거실 화재인가, 부엌화재인가

    IEnumerator SmokeBigger()
    {

        while (GManager.GetComponent<GamePlayManager>().IsGameEnd == false)
        {
            yield return new WaitForSeconds(SmokeTime * 0.25f);
            gameObject.GetComponent<Transform>().localScale = new Vector3(1.25f, 1.25f, 1);
            yield return new WaitForSeconds(SmokeTime * 0.25f);
            gameObject.GetComponent<Transform>().localScale = new Vector3(2f, 2f, 1);
            yield return new WaitForSeconds(SmokeTime * 0.25f);
            gameObject.GetComponent<Transform>().localScale = new Vector3(2.5f, 2.5f, 2.5f);
            yield return new WaitForSeconds(SmokeTime * 0.25f);
            gameObject.GetComponent<Transform>().localScale = new Vector3(3f, 3f, 3f);

            GManager.GetComponent<GamePlayManager>().IsGameEnd = true;
            GManager.GetComponent<GamePlayManager>().escape = false;
            GManager.GetComponent<GamePlayManager>().SmokeDeath = true;

        }
    }
    public IEnumerator SmokeSmaller()
    {
        while (GManager.GetComponent<GamePlayManager>().IsGameEnd == false)
        {
            print("SMOKE OFF");
            yield return new WaitForSeconds(SmokeTime * 0.25f);
            gameObject.GetComponent<Transform>().localScale = new Vector3(0.75f, 0.75f, 0.75f);
            yield return new WaitForSeconds(SmokeTime * 0.25f);
            gameObject.GetComponent<Transform>().localScale = new Vector3(.5f, .5f, .5f);
            yield return new WaitForSeconds(SmokeTime * 0.25f);
            gameObject.GetComponent<Transform>().localScale = new Vector3(.25f, .25f, .25f);
            yield return new WaitForSeconds(SmokeTime * 0.25f);
            gameObject.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);

            GManager.GetComponent<GamePlayManager>().IsGameEnd = true;
            GManager.GetComponent<GamePlayManager>().fireoff = true;
        }
    }

    void Start()
    {

        //StartCoroutine(SmokeBigger());
       
        if (!GManager)
        {
            GManager = GameObject.FindGameObjectWithTag("GameManager").gameObject;
            //GManager = GameObject.Find("GameStartManager").gameObject;
        }
        
        if (CurrentFire == null)
        {

            switch (SceneManager.GetActiveScene().name)
            {
                case "k_fire":
                    CurrentFire = GameObject.FindGameObjectWithTag("KitchenFire").gameObject;
                    StartCoroutine(SmokeBigger());
                    break;
                case "elecfire":
                    CurrentFire = GameObject.Find("efire").gameObject;
                    StartCoroutine(SmokeBigger());

                    break;
                case "fire":
                    break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (GManager.GetComponent<GamePlayManager>().IsGameEnd == false)
        {

            if (RealTime < SmokeTime)
            {
                RealTime += Time.deltaTime;

            }

            if (RealTime >= SmokeTime)
            {
                GManager.GetComponent<GamePlayManager>().IsGameEnd = true;
            }
        }
        if (!CurrentFire)
        {
            CurrentFire = GameObject.FindGameObjectWithTag("Fire");
        }
        if (!CurrentFire)
        {
            if (SceneManager.GetActiveScene().name == "elecfire")
            {
                if (CurrentFire.gameObject.name != "efire")
                {
                    CurrentFire = GameObject.Find("efire");
                }
            }
            if (SceneManager.GetActiveScene().name == "fire")
            {
                if (CurrentFire.gameObject.name != "fire")
                {
                    CurrentFire = GameObject.Find("fire");
                }
            }
            if (SceneManager.GetActiveScene().name == "k_fire")
            {
                if (CurrentFire.gameObject.name != "FlamesParticleEffect")
                {
                    CurrentFire = GameObject.Find("FlamesParticleEffect");
                }
            }

        }
    }
    

}
