using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collsio : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !GetComponentInParent<UnitController>().Target)
            GetComponentInParent<UnitController>().Target = other.transform;
    }
}
