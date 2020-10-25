using UnityEngine;

public class Create : MonoBehaviour
{
    [SerializeField] private GameObject objectToCreate;

    public void CreateObject()
    {
        Instantiate(objectToCreate, new Vector3(0, 10, 0), Quaternion.identity);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<MainPlayer>().playerIsInteracting)
        {
            CreateObject();
            other.GetComponent<MainPlayer>().playerIsInteracting = false;
        }
    }
}
