using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    private float enemyHealth = 100f;
    public LightningCast lightningCast;
    public EnemyAI enemyAI;
    [SerializeField] private Animator animator;

    private void Update()
    {
        if(enemyHealth <= 0)
        {
            enemyAI.enemyDead = false;
            animator.SetBool("enemyyDeath", true);
        }
    }
    public void playerDamage() 
    {
        enemyHealth -= lightningCast.damage;
    }
}
