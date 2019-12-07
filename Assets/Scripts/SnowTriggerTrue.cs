using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowTriggerTrue : MonoBehaviour
{
    public GameObject Snow1;
    public GameObject Snow2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Snow1.SetActive(true);
        Snow2.SetActive(true);
        Player.checking = true;

    }
        // Update is called once per frame
        void Update()
    {
        
    }
}

