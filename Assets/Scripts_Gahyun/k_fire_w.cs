using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class k_fire_w : MonoBehaviour
{
    public GameObject water;
    //냄비의 물을 참조하는 변수
    public GameObject fire;
    //부엌 불을 참조하는변수
    public GameObject fexpand;
    public GameObject fire2;
    public GameObject image;
    public static int a;
    public GameObject GManager;
    public GameObject FireOff;

    // Start is called before the first frame update
    void Start()
    {
        if (!GManager)
        {
            GManager = GameObject.FindGameObjectWithTag("GameManager");
        }
        if (!water)
        {
            water = GameObject.FindGameObjectWithTag("pot").transform.Find("Cylinder").gameObject;
        }
        if (!fire)
        {
            fire = GameObject.FindGameObjectWithTag("KitchenFire");
        }
        if (!fexpand)
        {
            fexpand = GameObject.FindGameObjectWithTag("OilFlame").transform.Find("BigExplosionEffect").gameObject;
        }
        if (!fire2)
        {
            fire2 =GameObject.FindGameObjectWithTag("OilFlame").transform.Find("DrippingFlames").gameObject;

        }
        
        if (!FireOff)
        {
            FireOff = GameObject.FindGameObjectWithTag("Canvas").transform.Find("fireoff").gameObject;
        }
        fexpand.SetActive(false);
        fire2.SetActive(false);
        image.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "pot")
        {
            if (water.activeInHierarchy == true)
            {
                fire.SetActive(false);
                fexpand.SetActive(true);
                Invoke("Exoff", 1.0f);
                Invoke("Onfire", 1.0f);
                Invoke("ImageOn", 3.0f);
            }
        }
        if (other.gameObject.tag == "Ex_Water")
        {
            Winner.fireoff = true;
            GManager.GetComponent<GamePlayManager>().IsGameEnd = true;
            //GManager.GetComponent<GamePlayManager>().escape = true;
            //FireOff.SetActive(true);
            Destroy(this.gameObject);
        }
    }
    public void Exoff()
    {
        fexpand.SetActive(false);
    }
    public void Onfire()
    {
        fire2.SetActive(true);
    }
    public void ImageOn()
    {
        GManager.GetComponent<GamePlayManager>().IsGameEnd = true;
        GManager.GetComponent<GamePlayManager>().KitchenFireDeath = true;
    }
}
