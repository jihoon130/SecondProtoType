using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 pos;
    public GameObject pc;
   public bool d=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(camRay, out hit, Mathf.Infinity))
            pos = hit.point;

        transform.position = new Vector3(pos.x,0.253f,pos.z);

        if(Input.GetMouseButtonDown(0)&&d==false)
        {
            Instantiate(pc, pos, Quaternion.identity);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("PlayerUnit") && !other.gameObject.CompareTag("Ground"))
        {
            d = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            d = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
    }
}
