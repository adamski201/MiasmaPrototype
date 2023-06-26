using UnityEngine;

[System.Serializable]
public struct Hit
{
    public int damage;
    public DamageEntityTypes entityToDamage;
    public float knockbackForce;
    public float stunTimer;
    [HideInInspector] public Vector3 knockbackSource;
}

[System.Serializable]
public struct Cost
{
    public ItemData item;
    public int amount;
}