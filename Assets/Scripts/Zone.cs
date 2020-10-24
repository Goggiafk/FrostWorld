using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zone : MonoBehaviour
{
    // Start is called before the first frame update\
    public RectTransform healthBar;
    void Start()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.transform.parent!=null)
        if (other.transform.parent.tag == "Player")
        {
            Health.healthi -= 0.1f;
            Debug.Log(Health.healthi);
            healthBar.sizeDelta = new Vector3(healthBar.parent.GetComponent<RectTransform>().sizeDelta.x * Health.healthi / 100, healthBar.sizeDelta.y, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
