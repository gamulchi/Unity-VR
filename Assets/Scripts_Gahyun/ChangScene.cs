
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangScene : MonoBehaviour
{  //버튼 관련 씬이동 통합 스크립트


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Startbuttun()
    {
        int num = Random.Range(1, 4);   //랜덤으로 값설정

        switch (num)
        {    //그 값으로 씬 로드

            case 1: SceneManager.LoadScene("fire"); break;
            case 2: SceneManager.LoadScene("elecfire"); break;
            case 3: SceneManager.LoadScene("k_fire"); break;

        }

    }

    public void e_retry()
    {
        SceneManager.LoadScene("elecfire");
    }

    public void s_retry()
    {
        SceneManager.LoadScene("fire");
    }

    public void k_retry()
    {
        SceneManager.LoadScene("k_fire");
    }

    public void StartScene_go()
    {
        SceneManager.LoadScene("StartScene");
    }
}
