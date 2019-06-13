using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public float interval = 10.0f;
    private float time;
    public float x, y, z;
    private int num = 0;
    private int add = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
         
        if(time > interval && add < 2)
        {
            time = 0;
            add++;
            GameObject fire = Instantiate(this.gameObject) as GameObject;
            if (num == 0)
            {
                num = 1;
                transform.Translate(new Vector3(Random.Range(-2.0f, 3), 0, Random.Range(-2.0f, 3)));
                
            }
        }
    }

}
