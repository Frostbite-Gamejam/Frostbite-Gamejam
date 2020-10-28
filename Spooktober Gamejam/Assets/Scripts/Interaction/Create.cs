using UnityEngine;

public class Create : MonoBehaviour
{
    private MainPlayer mainPlayer;
    [SerializeField] private string interactionPrompt;
    [SerializeField] private GameObject objectToCreate;
    private bool playerIsInTrigger = false;

    private void Awake()
    {
        mainPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<MainPlayer>();
    }

    private void Update()
    {
        if (mainPlayer.playerIsInteracting && playerIsInTrigger)
        {
            mainPlayer.HideCurrentPrompt();
            CreateObject();
        }
    }

    public void CreateObject()
    {
        Instantiate(objectToCreate, new Vector3(0, 10, 0), Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MainPlayer>())
        {
            other.GetComponent<MainPlayer>().promptToDisplay = interactionPrompt;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<MainPlayer>())
        {
            playerIsInTrigger = true;
        } else
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
