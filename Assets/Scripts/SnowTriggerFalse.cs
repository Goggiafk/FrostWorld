using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowTriggerFalse : MonoBehaviour
{
    public GameObject Snow1;
    public GameObject Snow2;
    public GameObject solar;    
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (solar.activeInHierarchy)
            Crafting.solar = false;
        Snow1.SetActive(false);
        Snow2.SetActive(false);
        Player.checking = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
