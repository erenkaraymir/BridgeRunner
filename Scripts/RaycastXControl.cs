using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastXControl : MonoBehaviour
{

    public RaycastHit hit;
    public Ray ray;
    public float distance;
    public static RaycastXControl raycastXControl;

    private void Awake()
    {
        raycastXControl = this;
    }

    public void CollectRay()
    {
        if (Physics.Raycast(gameObject.transform.position, transform.TransformDirection(transform.forward), out hit,distance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (hit.transform.CompareTag("x"))
            {
                ScoreCalculater.scoreCalculater.nameCount = Convert.ToInt32(hit.transform.name);
                
            }
        }
        
    }
}
