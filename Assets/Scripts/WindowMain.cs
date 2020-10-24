using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowMain : MonoBehaviour
{
    public InventoryCell[] cells;
    public CanvasGroup group;
    public Player player;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Show()
    {
        StartCoroutine(Showing(true));
        int sch = 0;
        foreach (Resource resource in player.inventory.resources)
        {
            cells[sch].Resource = resource;

            sch++;
        }
    }

    IEnumerator Showing(bool isShow)
    {
        float time = 0;
        while (time < .5f)
        {
            time += Time.deltaTime;
            if (isShow)
                group.alpha = time / .5f;
            else group.alpha = 1 - time / .5f;
            yield return null;
        }
    }
}
