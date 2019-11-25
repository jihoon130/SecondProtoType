using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HP_BAR : MonoBehaviour
{
    Image hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        hp.fillAmount = 100 / 100f;
    }
}
