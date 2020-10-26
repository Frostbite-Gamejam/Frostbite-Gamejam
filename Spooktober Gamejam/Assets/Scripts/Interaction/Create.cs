using UnityEngine;

public class Create : MonoBehaviour
{
    [SerializeField] private string interactionPrompt;
    [SerializeField] private GameObject objectToCreate;

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
        if (other.GetComponent<MainPlayer>().playerIsInteracting)
        {
            MainPlayer mainPlayer = other.GetComponent<MainPlayer>();
            mainPlayer.HideCurrentPrompt();
            mainPlayer.playerIsInteracting = false;
            CreateObject();
        }
    }
}
