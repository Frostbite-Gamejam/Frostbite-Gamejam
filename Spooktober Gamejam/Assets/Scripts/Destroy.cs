using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private GameObject objectToDestroy;


    public void DisableObject()
    {
        objectToDestroy.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<MainPlayer>().playerIsInteracting)
        {
            DisableObject();
            other.GetComponent<MainPlayer>().playerIsInteracting = false;
        }
    }
}
