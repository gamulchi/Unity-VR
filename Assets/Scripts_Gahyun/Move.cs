using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public GameObject Camera;
    private Rigidbody rigid;
    public float JumpPower = 0.01f;
    public GameObject GManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        GManager = GameObject.FindGameObjectWithTag("GameManager");

    }

    void PlayerMove()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * TestPlayerMoving.CamSpeed);
        //Camera.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * TestPlayerMoving.CamSpeed);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * JumpPower);

        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "LoopTopDoor")
        {
            // 옥상도착
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("LoopTopDoor").Length; i++)
            {
                print("DoorOPEN");
                GameObject.FindGameObjectsWithTag("LoopTopDoor")[i].GetComponent<Animator>().SetBool("DoorOpen", true);
            }
            Invoke("ChangeCondition", 3f);

        }


    }
    public void ChangeCondition()
    {
        print("DD");
        if (GManager.GetComponent<GamePlayManager>().IsGameEnd == false)
        {
            print("asdf");
            GManager.GetComponent<GamePlayManager>().IsGameEnd = true;
            GManager.GetComponent<GamePlayManager>().escape = true;
        }
    }

}
