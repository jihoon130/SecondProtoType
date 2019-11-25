using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ZobieMove : MonoBehaviour
{
    public NavMeshAgent nav;
    public Transform Castle;
    public float speed = 5f;
    float a;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        Castle = GameObject.Find("castle").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nav.remainingDistance <= 0.0f)
        {
            a = Random.Range(-10, 20);
            nav.SetDestination(new Vector3(Castle.position.x, Castle.position.y, Castle.position.z +a));
        }
    }


}
