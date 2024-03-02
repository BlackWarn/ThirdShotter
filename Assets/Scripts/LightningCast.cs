using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCast : MonoBehaviour
{
    public float Damage = 1f;
    public float Range = 100f;
    public RaycastHit hit;
    public Camera Mcamera;

    private LineRenderer _lightning;
    
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Casting();
        }
    }
    public void Casting()
    {
        RaycastHit hit;
        if(Physics.Raycast(Mcamera.transform.position, Mcamera.transform.forward, out hit, Range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
