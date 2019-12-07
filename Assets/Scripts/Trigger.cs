using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject wall;
    public GameObject wall1;
    public GameObject need;
    public GameObject trig;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == null)
            return;
        if (other.transform.parent.tag == "Player")
        {
            Debug.Log(other);
            Player player = other.GetComponentInParent<Player>();
            bool check = false;
            for (int i = 0; i < player.inventory.resources.Count; i++)
            {
                if ( player.inventory.resources[i].type == ResourcesType.Wood && player.inventory.resources[i].count >= 5)
                {
                    if(Collecting.CheckTool == true)
                        {
                        check = true;
                        wall.SetActive(true);
                        wall1.SetActive(false);
                        trig.SetActive(false);
                        wall.GetComponent<Animation>().Play();
                        player.inventory.resources[i].count -= 5;
                        if (player.inventory.resources[i].type == ResourcesType.Wood && player.inventory.resources[i].count == 5)
                        { player.inventory.resources[i].icon = null; }
                    }
                }

            }
            if (!check)
            {
                need.SetActive(true);

            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.tag == "Player")
        {
            need.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    { }
}

