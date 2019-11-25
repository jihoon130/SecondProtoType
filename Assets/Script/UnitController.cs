using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class UnitController : MonoBehaviour
{
    public bool AttackMe = false;
    private NavMeshAgent navAgent;
    private Animator ani;
  public  Transform Target;
    float Dins;
    private void Awake()
    {
        ani = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        if(gameObject.layer == 12)
        {
            Dins = 1.5f;
        }
        else
        {
            Dins = 30.0f;
        }
    }

    private void Update()
    {

        if (navAgent.remainingDistance <= 0.0f)
            ani.SetInteger("State", 0);
        if (Target)
        {
            if (!Target.CompareTag("Enemy") && navAgent.remainingDistance <= 0.5f)
            {
                ani.SetInteger("State", 0);
            }
            else if (Target.CompareTag("Enemy") && navAgent.remainingDistance <= 100.0f)
            {
               // StartCoroutine("Attack");
                transform.LookAt(Target);
                navAgent.isStopped = true;
                ani.SetInteger("State", 2);
            }
            else
            {
                navAgent.isStopped = false;
                ani.SetInteger("State", 1);
            }
            navAgent.SetDestination(Target.position);
        }
        else if(!Target && navAgent.isStopped == true)
        {
            ani.SetInteger("State", 0);
        }
    }
    public void MoveUnit(Vector3 dest)
    {
        navAgent.SetDestination(dest);
        ani.SetInteger("State", 1);

    }

    public void SetSelected(bool isSelected)
    {
        transform.Find("Point").gameObject.SetActive(isSelected);
    }

    public void PauseUnit()
    {
        navAgent.SetDestination(transform.position);
    }
    public void DestoryUnit()
    {
        Destroy(this.gameObject);
    }

    IEnumerator Attack()
    {
        if (Target)
        {
            yield return new WaitForSeconds(3.0f);
            Target.GetComponent<AIMOVE>().Attack();
        }
    }
}
