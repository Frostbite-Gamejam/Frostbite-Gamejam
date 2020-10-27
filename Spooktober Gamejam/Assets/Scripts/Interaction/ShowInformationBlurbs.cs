using UnityEngine;

public class ShowInformationBlurbs : MonoBehaviour
{
    private MainPlayer mainPlayer;
    [SerializeField] private ShowText showText;
    [SerializeField] private GameObject[] blurbsToReveal;
    private bool playerIsInTrigger;

    private void Awake()
    {
        mainPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<MainPlayer>();
    }

    private void Update()
    {
        if (mainPlayer.playerIsInteracting && playerIsInTrigger)
        {
            ShowInfo();
        }
    }

    private void ShowInfo()
    {
        for (var i = 0; i < blurbsToReveal.Length; i++)
        {
            blurbsToReveal[i].SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<MainPlayer>())
        {
            playerIsInTrigger = true;
        }
        else
        {
            playerIsInTrigger = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<MainPlayer>())
        {
            playerIsInTrigger = false;
        }
    }
}
