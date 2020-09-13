using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainOverlayController : MonoBehaviour
{
    public void adjustOpacity(float painMeter)
    {
        float painPercentage = painMeter / 100;

        SpriteRenderer overlayRenderer = GetComponent<SpriteRenderer>();
        Color newColor = new Color(overlayRenderer.color.r, overlayRenderer.color.g, overlayRenderer.color.r, painPercentage);
        overlayRenderer.color = newColor;
    }
}
