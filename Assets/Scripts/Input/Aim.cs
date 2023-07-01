using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Transform aimTransform;
    private PlayerInput input;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        HandleAiming();
    }

    private void HandleAiming()
    {
        Vector3 mousePosition = input.GetMousePosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }
}
