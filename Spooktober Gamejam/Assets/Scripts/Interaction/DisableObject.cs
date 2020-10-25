﻿using UnityEngine;

public class DisableObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToDisable;

    public void Disable() => objectToDisable.SetActive(false); // LAMBDA 1 LINER

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<MainPlayer>().playerIsInteracting)
        {
            other.GetComponent<MainPlayer>().playerIsInteracting = false;
            Disable();
        }
    }
}
