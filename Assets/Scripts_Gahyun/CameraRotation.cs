using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Quaternion zlock;
    public float CamHeight;
    public float CamSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos;
        zlock = transform.rotation;
        zlock.x = transform.parent.gameObject.transform.rotation.x;
        pos = transform.parent.gameObject.transform.position;
        pos.y = transform.parent.gameObject.transform.position.y + CamHeight;
        transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * CamSpeed);
        zlock.z = 0;
        transform.position = pos;
       transform.localRotation = zlock;

    }
}
