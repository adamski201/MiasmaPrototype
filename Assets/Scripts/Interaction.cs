using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    public UnityAction onInteractEvent;
    private Transform aim;
    [SerializeField] private float range;

    private void Awake()
    {
        aim = GetComponentInChildren<Transform>();
    }
    public void Interact()
    {
        // Shoot raycast and return hit object (or null)
        RaycastHit2D hit = Physics2D.Raycast(aim.position, aim.right, range);
        if (hit)
        {
            GameObject hitObject = hit.transform.gameObject;
            TryInteractWithObject(hitObject);
        }
        onInteractEvent?.Invoke();
    }

    private void TryInteractWithObject(GameObject objectToInteractWith)
    {
        if (objectToInteractWith.TryGetComponent(out Interactable interactableObject))
        {
            interactableObject.TriggerInteraction();
        }
    }
}
