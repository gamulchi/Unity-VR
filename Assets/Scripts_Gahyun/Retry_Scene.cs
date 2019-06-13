using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//죽은 뒤에 씬 다시 로드 하는 스크립트
public class Retry_Scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void elec_re_try()
    {
        SceneManager.LoadScene("elecfire");
    }
}
