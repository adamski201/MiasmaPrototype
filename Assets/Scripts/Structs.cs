using UnityEngine;

[System.Serializable]
public struct Hit
{
    public int damage;
    public DamageTypes damageType;
    public float knockbackForce;
    [HideInInspector] public Vector3 knockbackSource;
}

[System.Serializable]
public struct Cost
{
    public ItemData item;
    public int amount;
}