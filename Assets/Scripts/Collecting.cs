﻿using System.Collections;
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
    public static bool CheckTool;
    // Start is called before the first frame update
    void Start()
    {
        mass = Resources.LoadAll<GameObject>("Prefabs");
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
                    Destroy(hit.transform.gameObject);
                    player.inventory.Add(resource);
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


                }
            } 
            else if (hit.transform.tag == "Tools")
            {
                collecting.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (CheckTool == true)
                    { }
                    else
                    {
                        Destroy(hit.transform.gameObject);
                        Hammer.SetActive(true);
                        CheckTool = true;
                    }
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



