using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaringGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadScene(string nameScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
        Time.timeScale = 1;
    }

    public void TimeReturn()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
