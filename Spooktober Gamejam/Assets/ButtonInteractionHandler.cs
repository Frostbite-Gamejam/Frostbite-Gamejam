using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractionHandler : MonoBehaviour
{
    [SerializeField] private GameObject objectToDestroy;

    public void Interact()
    {
        try
        {
            objectToDestroy.SetActive(false);
        }
        catch (Exception e) { throw e; }
    }
}
