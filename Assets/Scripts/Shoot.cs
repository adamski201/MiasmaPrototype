using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Shoot : MonoBehaviour
{
    [SerializeField] private UnityEvent shotFired;
    [SerializeField] private PlayerInput playerInput;
    private Recoil recoil;
    private IShootable[] shootables;

    private void Awake()
    {
        recoil = GetComponent<Recoil>();
    }

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
        if (!recoil.InRecoil)
        {
            shotFired.Invoke();

            foreach (IShootable shootable in shootables)
            {
                shootable.Launch();
            }
        }
    }
}