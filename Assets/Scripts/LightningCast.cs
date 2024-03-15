using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCast : MonoBehaviour
{
    public float Damage = 1f;
    public float Range = 100f;
    private static float timeStart = 5f;
    private float timeFix = 5f;

    public Camera Mcamera;
    public GameObject LigtningVisible;

    private LineRenderer _lightning;
    
    private void Update()
    {
        Timer();
        LightningShoot();
        Debug.Log(timeStart);
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
                Invoke("LigtningYesVisible", 1.5f);
                Casting();
                timeStart = timeFix;
            }
        }
    }
    private void LigtningYesVisible()
    {
        LigtningVisible.SetActive(true);
        Invoke("LigtningNotVisible", 1f);
    }
    private void LigtningNotVisible()
    {
        LigtningVisible.SetActive(false);
    }
}
