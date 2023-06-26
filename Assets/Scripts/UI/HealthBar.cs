using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    public void SetHealth(int health)
    {
        healthBar.fillAmount = health * 1.0f / 100;
    }
}
