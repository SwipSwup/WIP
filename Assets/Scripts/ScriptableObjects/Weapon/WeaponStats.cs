using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new WeaponsStats", menuName = "weapons/Stats")]

public class WeaponStats : ScriptableObject
{
    public int fireRate;
    public float maxRange;
    public int damage;
}
