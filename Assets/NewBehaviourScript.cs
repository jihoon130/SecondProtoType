using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class NewBehaviourScript : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public GameObject a;
    public Transform b;
    public void OnBeginDrag(PointerEventData eventData)
    {
    //    Instantiate(a, eventData.position, a.transform.rotation);
    }

    public void OnDrag(PointerEventData eventData)
    {
       transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //if(Input.GetMouseButtonDown(0))
       // {
       //     Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
       //     Debug.Log(r.direction);
       // }
    }
}
