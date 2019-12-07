using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject collecting;
    public GameObject head;
    public Inventory inventory;
    public float speed;
    public float speedRotate;
    public float jumpStrenght;
    Rigidbody rig;
    Vector3 moving;
    bool standing;
    public static int energyWaste = 10;
    public WindowMain windowMain;
    public GameObject menu;
    public GameObject lighter;
    public RectTransform energyBar;
    public GameObject deathScreen;
    public GameObject snow1;
    public GameObject snow2;
    public static bool checking;
    float save;

    void Start()
    {
        inventory = new Inventory();
        rig = GetComponent<Rigidbody>();
        Time.timeScale = 1;
        checking = true;
    }

    // Update is called once per frame

    void OnCollisionStay(Collision collision)
    {
        standing = false;
        for (int i = 0; i < collision.contactCount; i++)
        {
            if (collision.contacts[i].point.y < transform.position.y)
                standing = true;
        }
    }

    void Update()
    {
        int addSpeed = 30;
        moving = transform.position;
        if (Input.GetKeyDown(KeyCode.Tab))
            if (!windowMain.gameObject.activeInHierarchy)
            {
                windowMain.gameObject.SetActive(true);
                windowMain.Show();
            }
            else
            {
                windowMain.gameObject.SetActive(false);
            }
        if (PlayerPrefs.HasKey("particles"))
        {
            if (checking == true)
            {
                if (PlayerPrefs.GetInt("particles") == 1)
                {
                    snow1.SetActive(true);
                    snow2.SetActive(true);
                }
                else
                {
                    snow1.SetActive(false);
                    snow2.SetActive(false);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(true);
            Time.timeScale = 0;
         
        }
        if (Input.GetKeyDown(KeyCode.F))
            lighter.SetActive(!lighter.activeInHierarchy);
        if (Input.GetKey(KeyCode.W))
            moving += transform.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            moving -= transform.right * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            moving -= transform.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            moving += transform.right * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift))
            speed = addSpeed;
        else if (Input.GetKeyUp(KeyCode.LeftShift)) speed -= 15;
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3, 1 << LayerMask.NameToLayer("Default")))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (hit.transform.tag == "Ground")
                    rig.AddForce(new Vector3(0, jumpStrenght, 0), ForceMode.Impulse);
            }
            if (hit.transform.tag == "Ice")
            {
                deathScreen.SetActive(true);
                Time.timeScale = 0;

            }
        }
        rig.MovePosition(moving);
    }
}


