using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoverer : MonoBehaviour
{
    private GameObject hovered = null;
    private GameObject lastHovered = null;

    void Start()
    {
        
    }

    void Update()
    {
        HitScan();

        Debug.Log("Hovering: " + hovered);

        if(lastHovered != hovered)
        {
            hovered.GetComponent<WeenieController>()?.SetHoverStatus(true);
            lastHovered.GetComponent<WeenieController>()?.SetHoverStatus(true);
        }

        if(Input.GetMouseButtonDown(0))
        {
            hovered.GetComponent<WeenieController>()?.SelectWeenie();
        }

        lastHovered = hovered;
    }

    private void HitScan()
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(r, out hit, Mathf.Infinity))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.CompareTag("weenie"))
            {
                hovered = hitObject;
            }
        }
        else
        {
            hovered = null;
        }

        Debug.DrawRay(r.origin, r.direction * 100, Color.yellow, 1f);
    }
}
