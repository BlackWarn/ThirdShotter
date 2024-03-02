using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public LightningCast _lightningCast;
    public GameObject TargetPoint;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        _lightningCast = GetComponent<LightningCast>();
    }
    private void Update()
    {
        lineRenderer.SetPositions(new Vector3[] { TargetPoint.transform.position, _lightningCast.hit.point });
    }

}
