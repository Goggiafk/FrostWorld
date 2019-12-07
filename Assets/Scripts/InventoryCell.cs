using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    Resource resource;
    public Image icon;
    public Text count;


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
