using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.vr;
using UnityEngine.SceneManagement;
//https://you-rang.tistory.com/261

public class MyController : MonoBehaviour
{
    public SteamVR_Input_Sources TouchPadPad;
    //터치패드에 <터치>하는거
    public SteamVR_Action_Boolean TouchYes;
    //터치패드 눌렀는지 아닌지 단순하게 받아들이는거
    float axisName;

    //위 변수들과 상관없음
    public SteamVR_Input_Sources any = SteamVR_Input_Sources.Any;
    // Start is called before the first frame update


    //public GameObject testPlane;
    // Update is called once per frame
    void Update()
    {
        Scene NowScene = SceneManager.GetActiveScene();
        if (NowScene != "First_Screen")
        {
            //처음 시작 화면이 아니라면

        }
        if (NowScene == "First_Screen")
        {
            //처음 시작화면이라면


        }
        if (TouchYes.GetState(TouchPadPad) == true)
        {
            //터치패드 클릭하면 빨강색
            Vector2 padPosition = SteamVR_Actions.default_TouchPosition.GetAxis(SteamVR_Input_Sources.Any);
            if (padPosition.y > 0.7f)
            {
                Debug.Log("UP");
            }
            if (padPosition.y < -0.7f)
            {
                Debug.Log("down");
            }
            if (padPosition.x > 0.7f)
            {
                Debug.Log("right");
            }
            if (padPosition.x < -0.7f)
            {
                Debug.Log("left");
            }
            // testPlane.GetComponent<MeshRenderer>().material.color = Color.red;

        }
       
    
        else
        {
            //터치패드 클릭안하면 흰색
            // testPlane.GetComponent<MeshRenderer>().material.color = Color.white;
        }



    }
}
