using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArqueroController : MonoBehaviour
{
    public GameObject arrow;
    public List<GameObject> enemigos;
    public GameObject toAttack;
    public float attackCooldown;
    private float attackTime;
    public bool isAttacking;

    private void Update()
    {
        if (enemigos.Count > 0 && isAttacking == false)
        {
            isAttacking = true;
        }
        else if (enemigos.Count == 0 && isAttacking == true)
        {
            isAttacking = false;
        }

        if (toAttack != null)
        {
           if (attackTime <= Time.time)
           {
                Instantiate(arrow, transform);
                attackTime = Time.time + attackCooldown;
           }
        }
    }
}
