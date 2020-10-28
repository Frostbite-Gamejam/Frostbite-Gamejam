using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] public Button playButton;
    [SerializeField] public Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
        Button play = playButton.GetComponent<playButton>();
        play.onClick.AddListener(PlayGame);
        Button quit = quitButton.GetComponent<quitButton>();
        play.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
    
    }    public void PlayGame() {
        SceneManagement.LoadScene("Main Level", LoadSceneMode.Additive);
    }

    public void QuitGame() {
        Debug.Log("Quit!");
        Application.Quit();
    }

}
