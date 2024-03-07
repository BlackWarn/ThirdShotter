using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCast : MonoBehaviour
{
    public float Damage = 1f;
    public float Range = 100f;
    public float timeStart = 5f;
    public float timeFix = 5f;
    public float delay = 0.6f;
    public Camera Mcamera;
    public GameObject LigtningVisible;

    private LineRenderer _lightning;
    
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
            Debug.Log(hit.transform.name);
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
                LigtningVisible.SetActive(true);
                Invoke("LigtningNotVisible", delay);
                timeStart = timeFix;
            }
        }
    }
    private void LigtningNotVisible()
    {
        LigtningVisible.SetActive(false);
    }
}
