using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMove : MonoBehaviour
{
    NavMeshAgent agent;
   public Transform Target;
    Animator ani;
    float AttackTime=0.0f;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Target)
        {
            agent.SetDestination(Target.position);

            //if (Target.CompareTag("EndPoint") && agent.remainingDistance <= 0.5f)
            //{
            //    ani.SetInteger("State", 0);
            //}
            if (Target.CompareTag("Enemy") && agent.remainingDistance <= 1.2f)
            {
                AttackTime += Time.deltaTime;
                if (AttackTime >= 2.0f)
                {
                    AttackTime = 0.0f;
                    Target.gameObject.GetComponentInParent<AIMOVE>().Attack();
                }
                agent.isStopped = true;
                ani.SetInteger("State", 2);
            }
            else
            {
                agent.isStopped = false;
                ani.SetInteger("State", 1);
            }
        }
        else
        {
            ani.SetInteger("State", 0);
        }
    }


}
