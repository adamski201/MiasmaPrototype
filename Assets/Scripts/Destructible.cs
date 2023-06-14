using UnityEngine;

public class Destructible : MonoBehaviour
{
    public void Die()
    {
        Destroy(gameObject);
    }
}
