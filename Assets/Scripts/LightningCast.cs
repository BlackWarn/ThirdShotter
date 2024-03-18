using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCast : MonoBehaviour
{
    public float Damage = 50f;
    public float Range = 100f;
    private float timeStart = 5f;
    private float timeFix = 5f;

    public Camera Mcamera;
    public GameObject LigtningVisible;

    private void Start()
    {
        
    }
    private void Update()
    {
        Timer();
        LightningShoot();
        //Debug.Log(timeStart);
    }
    private void Casting()
    {
        RaycastHit hit;
        if(Physics.Raycast(Mcamera.transform.position, Mcamera.transform.forward, out hit, Range))
        {
            if (hit.collider.gameObject.GetComponent<EnemyHealth>())
            {
                hit.collider.gameObject.GetComponent<EnemyHealth>().playerDamage();
            }
        }
    }
    private void Timer()
    {
        if (timeStart >= 0)
        {
            timeStart -= Time.deltaTime;
        }
    }
    private void LightningShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (timeStart <= 0)
            {
                Invoke("LigtningYesVisible", 1.5f);
                timeStart = timeFix;
            }
        }
    }
    private void LigtningYesVisible()
    {
        LigtningVisible.SetActive(true);
        Casting();
        Invoke("LigtningNotVisible", 1f);
    }
    private void LigtningNotVisible()
    {
        LigtningVisible.SetActive(false);
    }
}
