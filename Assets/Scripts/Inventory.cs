using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<Resource> resources = new List<Resource>();
  

    public void Show()
    {

    }

    public void Add(Resource resource)
    {
        bool check=false;
        for (int i = 0; i < resources.Count; i++)
        {
            if (resources[i].type == resource.type)
            {
                resources[i].count += resource.count;
                resources[i].weight += resource.weight;
                check = true;
            } 
        } if (!check)
        {
            resources.Add(resource);
        }
    }
}
