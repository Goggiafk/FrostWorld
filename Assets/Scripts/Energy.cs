using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public GameObject collecting;
    public GameObject head;
    public GameObject deathScreen;
    float time;
    public RectTransform energyBar;
    public static float energi;
    public GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        Energy.energi = 100;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 5)
        {
            energi -= 1 * Time.deltaTime;
            if(Player.torch == true)
                energi -= 1 * Time.deltaTime;
            if (Player.sprint == true && Player.movi == true)
                energi -= 2 * Time.deltaTime;
            if (Crafting.solar == true)
            {
                energi += 1.5f * Time.deltaTime;
                Energy.energi = Mathf.Clamp(Energy.energi, 0, 100);
                if (Player.movi==true)
                energi -= 0.5f * Time.deltaTime;
                Energy.energi = Mathf.Clamp(Energy.energi, 0, 100);
            }
            energyBar.sizeDelta = new Vector3(energyBar.parent.GetComponent<RectTransform>().sizeDelta.x * energi / 100, energyBar.sizeDelta.y, 0);
            if (energi <= 20)
            {
                inventory.SetActive(false);
                deathScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}

//public class Character
//{
//    public GameObject obj;
//    public float speed;
//    public float size;
//}

//public class Hunter : Character
//{
//    public float damage;
//    public float range;
//}

//public class Rabbit : Character
//{
//    public float rangeFear;
//}

//public class Main
//{
//    public List<Character> characters;

//    public Main()
//    {
//        characters = new List<Character>();
//        characters.Add(new Rabbit());
//        Rabbit rabbit = characters[0] as Rabbit;
//        if (rabbit != null)
//        {

//        }
//    }
//}