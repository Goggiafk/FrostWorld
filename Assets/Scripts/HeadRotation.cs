using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRotation : MonoBehaviour
{
    Vector3 oldMousePosition;
    bool headRot;
    public Transform head;
    public float rotate;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        headRot = true;

        if (headRot)
        {
            //rotate = PlayerPrefs.GetFloat("sensivity");
            Vector3 delta = Input.mousePosition - oldMousePosition;
            delta.y = Mathf.Clamp(delta.y, -45, 45);
            transform.eulerAngles += new Vector3(-delta.y, 0, 0) * PlayerPrefs.GetFloat("sensivity");
            oldMousePosition = Input.mousePosition;
            if (transform.eulerAngles.x < 325 && transform.eulerAngles.x > 180)
                transform.localEulerAngles = new Vector3(325, transform.localEulerAngles.y, transform.localEulerAngles.z);
            if (transform.eulerAngles.x > 35 && transform.eulerAngles.x < 180)
                transform.localEulerAngles = new Vector3(35, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
    }
}
