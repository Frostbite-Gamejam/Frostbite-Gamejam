using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Notebooks
{ 
    Cave,
    UnderConstruction,
    InUse,
    NuclearWinter,
    AbandonedShelter,
    AlienMuseum
}

public class NotebookHandler : MonoBehaviour
{
    #region DEFINITIONS
    [SerializeField] private GameObject gameNotebook;
    public Notebooks notebook;
    public string notebookContents;
    #endregion
    #region METHODS
    public void AddToInventory(Collider other)
    {
        if (other.GetComponent<MainPlayer>().inventoryItem == null)
        {
            other.GetComponent<MainPlayer>().inventoryItem = gameNotebook;
            gameNotebook.SetActive(false);
        } 
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<MainPlayer>().playerIsInteracting)
        {
            other.GetComponent<MainPlayer>().playerIsInteracting = false;
            AddToInventory(other);
        }
    }
    #endregion
}
