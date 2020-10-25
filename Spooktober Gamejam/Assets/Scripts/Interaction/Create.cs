using UnityEngine;

public class Create : MonoBehaviour
{
    private Outline outline;
    [SerializeField] private GameObject objectToCreate;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    public void CreateObject()
    {
        Instantiate(objectToCreate, new Vector3(0, 10, 0), Quaternion.identity);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<MainPlayer>())
        {
            outline.enabled = true;
        }

        if (other.GetComponent<MainPlayer>().playerIsInteracting)
        {
            other.GetComponent<MainPlayer>().playerIsInteracting = false;
            CreateObject();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        outline.enabled = false;
    }
}
