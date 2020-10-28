using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main Level");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

}
