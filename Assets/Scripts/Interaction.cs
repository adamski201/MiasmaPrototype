using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    [SerializeField] private float range;
    private Transform firePoint;

    private void Awake()
    {
        firePoint = GetComponentInChildren<Transform>();
    }

    public void Interact()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right, range);

        if (hit)
        {
            TryInteractWithObject(hit.transform.gameObject);
        }

    }

    private void TryInteractWithObject(GameObject objectToInteractWith)
    {
        if (objectToInteractWith.TryGetComponent(out Interactable interactableObject))
        {
            interactableObject.TriggerInteraction();
        }
    }
}
