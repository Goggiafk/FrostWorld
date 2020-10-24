using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public RectTransform healthBar;
    public static float healthi;
    public GameObject deathScreen;
    float time;
    public Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        healthi = 100;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 1)
        {
            if (healthi <= 0)
            {
                deathScreen.SetActive(true);
                Time.timeScale = 0;
                anim.Play("Death");
            }
        }
    }
}
