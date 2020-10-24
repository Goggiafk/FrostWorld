using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    Resource resource;
    public Image icon;
    public Text count;
    public Player player;
    public GameObject windowMain;

    public void UseInv()
    {
        if (Resource == null)
            return;
        Resource res = player.inventory.resources.Find(x => x.type == Resource.type);
        if (res != null)
        {
            res.count--;
            Resource = res;
            windowMain.gameObject.SetActive(false);
            PlayerPrefs.SetFloat("sensivity", Player.save);
            Debug.Log(res.count);
        }
        else
            return;
    }
    public Resource Resource
    {
        get
        {
            return resource;
        }
        set
        {
            resource = value;
            icon.sprite = resource.icon;
            count.text = resource.count.ToString();
        }
    }
}
