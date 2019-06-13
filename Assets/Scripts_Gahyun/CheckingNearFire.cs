using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//주변에 불이 있는지 없는지 판단하는 스크립트
public class CheckingNearFire : MonoBehaviour
{
    public bool IsFireHere = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            //이미 그곳에 불이 있으면
            if (other.gameObject != transform.parent.gameObject)
            {
                //그 불이 자기 부모 불 오브젝트가 아니라면
                //불 없음 true
                IsFireHere = true;

            }
            if (gameObject.name == "SesarchingFireCenter")
            {
                transform.parent.gameObject.GetComponent<NormalFire>().FireCollapse = true;
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            IsFireHere = false;
        }
    }
}
