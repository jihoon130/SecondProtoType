using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    
   public int count;
    Text ct;
    private void Awake()
    {
        ct = GetComponent<Text>();
    }
    private void Update()
    {
        ct.text = count.ToString();
    }

    public void RoundS()
    {
    }
}
