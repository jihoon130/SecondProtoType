using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIMOVE : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform Target;
    Animator ani;
    PlayerManager RoundStart;
   public Transform me;
int hp = 100;
    // Start is called before the first frame update
    void Start()
    {
        me = GetComponent<Transform>();
        RoundStart = GameObject.Find("GameManager").GetComponent<PlayerManager>();
        ani = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RoundStart.StartRound)
        {
            if (hp <= 0)
            {
                agent.Stop();
                Destroy(gameObject.GetComponentInChildren<CapsuleCollider>());
                ani.SetInteger("State", 3);
                StartCoroutine(Dead());
            }
            if (!Target)
            {
                if (GameObject.Find("EndPoint"))
                    Target = GameObject.Find("EndPoint").GetComponent<Transform>();
            }
            if (hp > 0)
            {
                if (Target.CompareTag("EndPoint") && agent.remainingDistance <= 0.5f)
                {
                    ani.SetInteger("State", 0);
                }
                else if (Target.CompareTag("PlayerUnit") && agent.remainingDistance <= 1.5f)
                {
                    transform.LookAt(Target);
                    agent.isStopped = true;
                    ani.SetInteger("State", 2);
                }
                else
                {
                    agent.isStopped = false;
                    ani.SetInteger("State", 1);
                }
                agent.SetDestination(Target.position);
            }
        }
    }

    public void Attack()
    {
        hp -= 50;
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(2.0f);
        RoundStart.Count2++;
        Destroy(this.gameObject);
    }
}
