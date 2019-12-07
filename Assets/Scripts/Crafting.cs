using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public Player player;
    public GameObject obj;
    GameObject hammer;
    public GameObject molotok;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void DropObject()
    {
        int wood = -1;
        int metal = -1;
        for (int i = 0; i < player.inventory.resources.Count; i++)
        {
            if (player.inventory.resources[i].type == ResourcesType.Wood && player.inventory.resources[i].count >= 1)
            {
                wood = i;
            }
            if (player.inventory.resources[i].type == ResourcesType.Metal && player.inventory.resources[i].count >= 1)
            {
                metal = i;
            }
        }


        if ((wood != -1) && (metal != -1))
        {

                if (Collecting.CheckTool == true)
                {
                GameObject obj = Instantiate(Resources.Load<GameObject>("huh"));
                obj.transform.position = player.transform.position + new Vector3(0, +2, 0);
            }
                else
                {
                    molotok.SetActive(true);
                    Collecting.CheckTool = true;
                }
            
            player.inventory.resources[wood].count -= 1;

            player.inventory.resources[metal].count -= 1;


        }
    }

    
        // Update is called once per frame
        void Update()
        {

        }
    }


