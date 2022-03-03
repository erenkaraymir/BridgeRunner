using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Spawnobstacle : MonoBehaviour
{
    public int random1;
    public string isaret;
    public int random2;
    public bool visibility;
    public int control;

    public TextMeshPro text;

    public MeshRenderer meshRenderer;

    public Material cone;
    public Material cone1;
    public Material cone2;
    
    void Start()
    {
        //1 2 3-
        //4 5 6/
        //7 8 9 10*
        //11 12 13 14 15 16 17 18+
        //19 20 ?
        visibility = false;
        text = gameObject.GetComponent<TextMeshPro>();
        //Ýþareti belirlemek için randým sayý oluþturuyoruz
        random1 = Random.Range(1,21);
        int rand = Random.Range(1, 11);

        if (random1 == 1 || random1 == 2 || random1 == 3)
        {
            //-
            isaret = "-";
            random2 = Random.Range(1, 6);
            meshRenderer.material = cone;
            control = 1;
        }
        else if (random1 == 4 || random1 == 5 || random1 == 6)
        {
            ///
            isaret = "÷";
            random2 = Random.Range(1, 4);
            meshRenderer.material = cone;
            control = 2;
        }
        else if (random1 == 7 || random1 == 8 || random1 == 9 || random1 == 10 || random1 == 19)
        {
            //*
            isaret = "X";
            random2 = Random.Range(1, 4);
            meshRenderer.material = cone1;
            control = 3;
        }
        else
        {
            //+
            isaret = "+";
            random2 = Random.Range(1, 6);
            meshRenderer.material = cone1;
            control = 4;
        }

        if (rand == 1)
        {
            visibility = false;
        }
        else
        {
            visibility = true;
        }

        //Oluþan iþaret ve sayýyý yazdýrýyoruz
        if (visibility)
        {
            text.text = isaret + random2.ToString();
        }
        else
        {
            text.text = "???";
            meshRenderer.material = cone2;
        }
        
    }
    
}
