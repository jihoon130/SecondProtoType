using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject BshopM;
    public GameObject MCenter;
    public int layerMask;
    // Start is called before the first frame update
    private void Awake()
    {

        layerMask = (1 << 8) | (1 << 9) | (1 << 11);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit, 1000, layerMask))
            {
                if (hit.transform.gameObject.layer == 8)
                {
                    if (!BshopM.activeInHierarchy)
                    {
                        MCenter.SetActive(false);
                        BshopM.SetActive(true);
                    }
                    else
                    {
                        BshopM.SetActive(false);
                    }
                }
                if(hit.transform.gameObject.layer == 9)
                {
                    if (!MCenter.activeInHierarchy)
                    {
                        BshopM.SetActive(false);
                        MCenter.SetActive(true);
                    }
                    else
                    {
                        MCenter.SetActive(false);
                    }
                }
            }
        }
    }
}
