using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    float firstTime=0.0f;
    GameObject ct;
    // Start is called before the first frame update
    void Start()
    {
        ct = GameObject.Find("CTO");
    }

    // Update is called once per frame
    void Update()
    {
        if(ct.GetComponent<UI>().count <=200)
        firstTime += Time.deltaTime;
        if (firstTime >= 1.0f)
        {
            ct.GetComponent<UI>().count++;
            firstTime = 0.0f;
            Instantiate(Enemy, transform.position, Enemy.transform.rotation);
        }
   
    }
}
