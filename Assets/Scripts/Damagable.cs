using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public delegate void Damaged(float damageAmount);
    public event Damaged OnDamaged;

    public void hitByPlayer(float damageAmount)
    {
        OnDamaged?.Invoke(damageAmount);
    }
}