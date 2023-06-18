using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alive : MonoBehaviour
{
    protected float HP;
    protected float PhysicsDamage;
    protected float ManaDamage;
    protected float AttackSpeed;

    public virtual void Hit(float Damage)
    {
        HP -= Damage;
    }

}
