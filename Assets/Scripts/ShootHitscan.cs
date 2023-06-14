using UnityEngine;
using UnityEngine.Events;

public class ShootHitscan : MonoBehaviour
{
    [SerializeField] private UnityEvent shotFired;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float range = 10f;
    [SerializeField] private int damage = 20;
    [SerializeField] private int knockbackPower = 2;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private DamageTypes damageType;
    private Recoil recoil;

    private void Awake()
    {
        recoil = GetComponent<Recoil>();
    }

    private void OnEnable()
    {
        playerInput.onClickEvent += Shoot;
    }

    private void OnDisable()
    {
        playerInput.onClickEvent -= Shoot;
    }

    public void Shoot()
    {
        // Check if recoil period is over
        if (!recoil.InRecoil)
        {
            // Shoot raycast and return hit object (or null)
            RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right, range);

            // If the ray hit an object, check if the object is Hittable
            if (hit)
            {
                GameObject hitObject = hit.transform.gameObject;
                TryHitObject(hitObject);
            }

            // Enable recoil period
            recoil.InRecoil = true;

            shotFired.Invoke();
        }
    }

    void TryHitObject(GameObject objectToHit)
    {
        if (objectToHit.TryGetComponent(out Hittable hittableObject))
        {
            hittableObject.TakeHit(damage, damageType, knockbackPower, gameObject.transform.position);
        }
    }
}
