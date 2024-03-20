using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public RectTransform rectTransform;
    public LightningCast lightningCast;

    private void Update()
    {
        rectTransform.anchorMax = new Vector3(1, lightningCast.timeStart/lightningCast.timeFix);
    }
}
