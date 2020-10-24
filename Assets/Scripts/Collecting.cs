using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collecting : MonoBehaviour
{
    public GameObject head;
    public RectTransform energyBar;
    List<GameObject> objects = new List<GameObject>();
    float time;
    public GameObject collecting;
    public Player player;
    Rigidbody rig;
    int save;
    GameObject[] mass = new GameObject[3];
    public GameObject Hammer;
    public GameObject Molotok;
    public GameObject Request;
    public Animation door;
    public GameObject tree;
    public GameObject tree1;
    public GameObject pen;
    public AudioSource pick;
    public static bool checkTool;
    public GameObject wall;
    bool checkDoor;
    // Start is called before the first frame update
    void Start()
    {
        mass = Resources.LoadAll<GameObject>("Prefabs");
        checkDoor = false;
    }

     IEnumerator Timer(float time,System.Action action)
    {
        while (time>0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
        action();
    }
    // Update is called once per frame

    void Update()
    {
        for (int i = 0; i < objects.Count; i++)
            if (objects[i] == null)
            {
                objects.RemoveAt(i);
                CreateObject();
            }
        time += Time.deltaTime;
        if (objects.Count < 3)
        {
            if (time > 3)
            {
                CreateObject();
                time -= 3;
            }
        }
        Ray ray = new Ray(head.transform.position, head.transform.forward);
        RaycastHit hit;
        collecting.SetActive(false);
        if (Physics.Raycast(ray, out hit, 3, 1 << LayerMask.NameToLayer("Default")))
        {
            Resource resource = hit.transform.GetComponent<Resource>();
            if (hit.transform.tag == "loot")
            {
                collecting.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pick.Play();
                    if (resource.type != ResourcesType.Foto)
                    {
                        Destroy(hit.transform.gameObject);
                        player.inventory.Add(resource);

                    }
                    else
                    {
                        if (checkTool == true)
                        {
                            Destroy(hit.transform.gameObject);
                            player.inventory.Add(resource);

                        } else
                        {
                            StartCoroutine(Timer(0, () => { Request.SetActive(true); }));
                            StartCoroutine(Timer(1, () => { Request.SetActive(false); }));
                        }
                    }
                }
            }
            else if (hit.transform.tag == "Energy")
            {
                collecting.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(hit.transform.gameObject);
                    Energy.energi += 20;
                    Energy.energi = Mathf.Clamp(Energy.energi, 0, 100);
                    energyBar.sizeDelta = new Vector3(energyBar.sizeDelta.x * Energy.energi / 100, energyBar.sizeDelta.y, 0);
                    pick.Play();

                }
            }
            else if (hit.transform.tag == "Tools")
            {
                collecting.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {

                    if (checkTool == true)
                    { }
                    else
                    {
                        pick.Play();
                        Destroy(hit.transform.gameObject);
                        Hammer.SetActive(true);
                        checkTool = true;
                    }
                }
            }
            else if (hit.transform.tag == "CraftedTool")
            {
                collecting.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {

                    if (checkTool == true)
                    { }
                    else
                    {
                        pick.Play();
                        Destroy(hit.transform.gameObject);
                        Molotok.SetActive(true);
                        checkTool = true;
                    }
                }
            }
            else if (hit.transform.tag == "Pickaxe")
            {
                collecting.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pick.Play();
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Ending");
                }
            } 
        else if (hit.transform.tag == "Door")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (checkDoor == false)
                {

                    door.Play("DoorOpen");
                    checkDoor = true;
                }
                else
                {
                    door["Door"].speed = 1;
                    door.Play();
                    checkDoor = false;
                }
            }
        }
        else if (hit.transform.tag == "TreeFall")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (checkTool == true)
                {
                    tree1.SetActive(false);
                    pen.SetActive(true);
                    tree.SetActive(true);
                        wall.SetActive(false);
                        tree.GetComponent<Animation>().Play();
                }
                else
                { }

            }
        }
        }


    }
    void CreateObject()
    {
        GameObject obj = Instantiate(mass[Random.Range(0,mass.Length)]);
        objects.Add(obj);
        obj.transform.position = player.transform.position + new Vector3(Random.Range(-10, 10), -2, Random.Range(-10, 10));
    }
}



