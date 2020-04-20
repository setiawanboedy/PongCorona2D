using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanMenu : MonoBehaviour
{
    public bool isEscapeToExit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(isEscapeToExit)
            {
                Application.Quit();
            }
            else
            {
                KembaliKeMenu();
            }
        }
    }
    public void KembaliKeMenu()
    {
        SceneManager.LoadScene("Mulai");
    }
    public void MulaiEasy()
    {
        SceneManager.LoadScene("Easy");
    }
    public void MulaidenganLevel()
    {
        SceneManager.LoadScene("Level");
    }
    public void MulaiHard()
    {
        SceneManager.LoadScene("Hard");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void About()
    {
        SceneManager.LoadScene("About");
    }
    public void Keluar()
    {
        Application.Quit();
        Destroy(gameObject);
        return;
    }
}
