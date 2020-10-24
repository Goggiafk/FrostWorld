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
    public GameObject sp;
    public GameObject inv;
    public GameObject craf;
    public GameObject cel;
    public GameObject stat;
    public GameObject refuse;
    public static bool solar;
    public RectTransform healthBar;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Myvoid()
    {
        stat.SetActive(true);
        if (solar == true)
            sp.SetActive(true);
        else
            sp.SetActive(false);

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
                                craf.SetActive(false);
                                cel.SetActive(true);
                                stat.SetActive(true);
                                inv.SetActive(false);
                                PlayerPrefs.SetFloat("sensivity", Player.save);
                                break;
                            }
                        }
                    }
                    break;
                case Recepies.SolarPanel:
                    if (solar == true)
                    {
                        StartCoroutine(Timer(0, () => { refuse.SetActive(true); }));
                        StartCoroutine(Timer(1, () => { refuse.SetActive(false); }));
                    }
                    else
                    {
                        solar = true;
                        solarpanel.SetActive(true);
                        sp.SetActive(true);

                        for (int i = 0; i < rec.recepies.Count; i++)
                        {
                            craft = false;
                            for (int j = 0; j < player.inventory.resources.Count; j++)
                            {
                                if (rec.recepies[i].tip == player.inventory.resources[j].type && player.inventory.resources[j].count >= rec.recepies[i].count)
                                {
                                    player.inventory.resources[j].count -= rec.recepies[i].count;
                                    craf.SetActive(false);
                                    cel.SetActive(true);
                                    stat.SetActive(true);
                                    inv.SetActive(false);
                                    PlayerPrefs.SetFloat("sensivity", Player.save);
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case Recepies.Accum:
                    //player.inventory.Add();
                    for (int i = 0; i < rec.recepies.Count; i++)
                    {
                        craft = false;
                        for (int j = 0; j < player.inventory.resources.Count; j++)
                        {
                            if (rec.recepies[i].tip == player.inventory.resources[j].type && player.inventory.resources[j].count >= rec.recepies[i].count)
                            {
                                player.inventory.resources[j].count -= rec.recepies[i].count;
                                craf.SetActive(false);
                                cel.SetActive(true);
                                stat.SetActive(true);
                                inv.SetActive(false);
                                PlayerPrefs.SetFloat("sensivity", Player.save);
                                player.inventory.Add(new Resource(ResourcesType.Accum) { count = 1, icon = Resources.Load<Sprite>("Sprites/Accum"), weight = 500 });
                                break;
                            }
                        }
                    }
                    break;
                case Recepies.Repair:
                    //player.inventory.Add();
                    for (int i = 0; i < rec.recepies.Count; i++)
                    {
                        craft = false;
                        for (int j = 0; j < player.inventory.resources.Count; j++)
                        {
                            if (rec.recepies[i].tip == player.inventory.resources[j].type && player.inventory.resources[j].count >= rec.recepies[i].count)
                            {
                                player.inventory.resources[j].count -= rec.recepies[i].count;
                                craf.SetActive(false);
                                cel.SetActive(true);
                                stat.SetActive(true);
                                inv.SetActive(false);
                                PlayerPrefs.SetFloat("sensivity", Player.save);
                                Health.healthi += 20;
                                Health.healthi = Mathf.Clamp(Health.healthi, 0, 100);
                                healthBar.sizeDelta = new Vector3(healthBar.parent.GetComponent<RectTransform>().sizeDelta.x * Health.healthi / 100, healthBar.sizeDelta.y, 0);
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


