using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public List<Recipe> recipes;
    public Player player;
    GameObject obj;
    public GameObject hammer;
    public GameObject molotok;
    public GameObject notenough;
    public GameObject solarpanel;
    public static bool solar;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void DropObject(int index)
    {
        bool craft = false;
        Recipe rec = recipes[index];
        for (int i = 0; i < rec.recepies.Count; i++)
        {
            craft = false;
            for (int j = 0; j < player.inventory.resources.Count; j++)
            {
                if (rec.recepies[i].tip == player.inventory.resources[j].type && player.inventory.resources[j].count >= rec.recepies[i].count)
                {
                    craft = true;
                    break;
                }
            }
            if (!craft)
            {
               
                    StartCoroutine(Timer(0, () => { notenough.SetActive(true); }));
                    StartCoroutine(Timer(1, () => { notenough.SetActive(false); }));
                return;
            }
        }
        if (craft == true)
        {
            switch (rec.rec)
            {
                case Recepies.Hammer:
                    if (Collecting.checkTool == true)
                    {
                        GameObject obj = Instantiate(Resources.Load<GameObject>("huh"));
                        obj.transform.position = player.transform.position + new Vector3(0, +2, 0);
                    }
                    else
                    {
                        molotok.SetActive(true);
                        Collecting.checkTool = true;
                    }
                    for (int i = 0; i < rec.recepies.Count; i++)
                    {
                        craft = false;
                        for (int j = 0; j < player.inventory.resources.Count; j++)
                        {
                            if (rec.recepies[i].tip == player.inventory.resources[j].type && player.inventory.resources[j].count >= rec.recepies[i].count)
                            {
                                player.inventory.resources[j].count -= rec.recepies[i].count;
                                break;
                            }
                        }
                    }
                    break;
                case Recepies.SolarPanel:
                    solar = true;
                    solarpanel.SetActive(true);
                    for (int i = 0; i < rec.recepies.Count; i++)
                    {
                        craft = false;
                        for (int j = 0; j < player.inventory.resources.Count; j++)
                        {
                            if (rec.recepies[i].tip == player.inventory.resources[j].type && player.inventory.resources[j].count >= rec.recepies[i].count)
                            {
                                player.inventory.resources[j].count -= rec.recepies[i].count;
                                break;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            
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
    // Update is called once per frame
    void Update()
        {

        }
    }


