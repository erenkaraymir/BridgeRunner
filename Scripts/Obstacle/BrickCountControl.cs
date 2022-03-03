using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCountControl : MonoBehaviour
{
    public Spawnobstacle spawnobstacle;
    [SerializeField] private GameObject blockPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        spawnobstacle = gameObject.GetComponentInChildren<Spawnobstacle>();
        //Brick sayýsýný arttýr.
         /* 
         * Control
         * 1 -
         * 2 /
         * 3 *
         * 4 +
         */
        switch (spawnobstacle.control)
        {
            case 1:
                BlockPicker.picker.ReduceObj(spawnobstacle.random2);
                break;
            case 2:
                BlockPicker.picker.DivideObj(spawnobstacle.random2);
                break;
            case 3:
                BlockPicker.picker.ImpactObj(spawnobstacle.random2);
                break;
            case 4:
                BlockPicker.picker.PlusObj(spawnobstacle.random2);
                break;
            default:
                break;
        }
        //Görünürlüðünü kapatýyoruz
        gameObject.SetActive(false);
    }

}
