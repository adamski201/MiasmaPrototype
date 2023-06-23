using UnityEngine;
using UnityEngine.Events;

public class SemiAutoShoot : MonoBehaviour
{
    [SerializeField] private UnityEvent shotFired;
    [SerializeField] private FloatEvent shotFiredFloat;
    [SerializeField] private float recoilTimer;
    [SerializeField] private PlayerInput playerInput;
    private IShootable[] shootables;
    private float nextShoot;

    private void OnEnable()
    {
        playerInput.onClickEvent += Fire;
        shootables = GetComponents<IShootable>();
    }

    private void OnDisable()
    {
        playerInput.onClickEvent -= Fire;
    }

    public void Fire()
    {
        // Check if recoil period is over
        if (Time.time > nextShoot)
        {
            shotFired.Invoke();
            shotFiredFloat.Invoke(recoilTimer);

            foreach (IShootable shootable in shootables)
            {
                shootable.Launch();
            }

            nextShoot = Time.time + recoilTimer;
        }
    }
}