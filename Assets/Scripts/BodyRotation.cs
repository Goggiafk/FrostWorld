using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotation : MonoBehaviour
{
    Vector3 oldMousePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate = PlayerPrefs.GetFloat("sensivity");
        Vector3 delta = Input.mousePosition - oldMousePosition;
        transform.eulerAngles += new Vector3(0, delta.x * PlayerPrefs.GetFloat("sensivity"), 0);
        oldMousePosition = Input.mousePosition;
    }
}
