using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public LightningCast lightningCast;

    public void playerDamage() 
    {
        Destroy(gameObject);
    }
}
