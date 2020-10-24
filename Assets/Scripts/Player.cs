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
    public GameObject hammer;
    public GameObject molotok;
    public static bool checking;
    public Player player;
    public static float save;
    public static bool torch;
    public static bool sprint;
    public GameObject inv;
    public GameObject stat;
    public GameObject sp;
    public static bool movi;
    public AudioSource background;
    public AudioSource step;
    public Animation anim;
    void Start()
    {
        
        inventory = new Inventory();
        rig = GetComponent<Rigidbody>();
        Time.timeScale = 1;
        checking = true;
        Collecting.checkTool = false;
        torch = false;
        sprint = false;
        movi = false;
        StartCoroutine(Timer(0, () => { background.Play(); }));
        StartCoroutine(Timer(25, () => { background.Stop(); }));
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
        if(!background.isPlaying)
        {
        StartCoroutine(Timer(0, () => { background.Play(); }));
        StartCoroutine(Timer(25, () => { background.Stop(); }));
        }
        int addSpeed = 150;
        moving = transform.position;
        if (Input.GetKeyDown(KeyCode.Tab))
            if (!windowMain.gameObject.activeInHierarchy)
            {
                windowMain.gameObject.SetActive(true);
                windowMain.Show();
                save = PlayerPrefs.GetFloat("sensivity");
                PlayerPrefs.SetFloat("sensivity", 0);
                if (inv.gameObject.activeInHierarchy)
                {
                    stat.SetActive(true);
                    if (Crafting.solar == true)
                        sp.SetActive(true);
                    else
                        sp.SetActive(false);
                }
            }
            else
            {
                windowMain.gameObject.SetActive(false);
                PlayerPrefs.SetFloat("sensivity", save);
            }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.Play("Ctrl");
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (molotok.activeInHierarchy)
            {
                molotok.SetActive(false);
                Collecting.checkTool = false;
                GameObject obj = Instantiate(Resources.Load<GameObject>("Molot"));
                obj.transform.position = player.transform.position + new Vector3(0, +2, 0);
            }
            if (hammer.activeInHierarchy)
            {
                hammer.SetActive(false);
                Collecting.checkTool = false;
                GameObject obj = Instantiate(Resources.Load<GameObject>("huh"));
                obj.transform.position = player.transform.position + new Vector3(0, +2, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            lighter.SetActive(!lighter.activeInHierarchy);
            torch = !torch;
        }
        if (Input.GetKey(KeyCode.F5))
            UnityEngine.SceneManagement.SceneManager.LoadScene("Models");
        if (Input.GetKey(KeyCode.W))
            moving += transform.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            moving -= transform.right * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            moving -= transform.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            moving += transform.right * speed * Time.deltaTime;
        if (moving == transform.position)
            movi = false;
        else
            movi = true;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = addSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) speed -= 15;
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 6, 1 << LayerMask.NameToLayer("Default")))
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
        if (speed == addSpeed)
            sprint = true;
        else
            sprint = false;
        rig.MovePosition(moving);

        if (movi == true)
        {
            if (!step.isPlaying)
            {
                step.Play();
                anim.Play("Walk");
            }
            if (sprint == true)
            {
                anim["Walk"].speed = 2.5f;
            }
            else
            {
                anim["Walk"].speed = 1.5f;
            }
        }
        else
        {

            step.Stop();
            anim.Stop("Walk");
        }
    }
    IEnumerator Timer(float time, System.Action action)
    {
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
        action();
    }
}


