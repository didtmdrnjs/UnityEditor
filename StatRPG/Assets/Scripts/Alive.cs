using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alive : MonoBehaviour
{
    protected float MaxHP;
    protected float HP;
    public float PhysicsDamage;
    public float ManaDamage;
    protected float AttackSpeed;

    public virtual void Hit(float Damage) { }

}
