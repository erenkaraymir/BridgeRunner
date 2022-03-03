using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockPicker : MonoBehaviour
{
    public bool isNull = true;
    [SerializeField] private Transform firstBlockPoint;
    public GameObject lastBlock;
    public List<GameObject> blocks;
    [SerializeField] GameObject blockObjPrefab;
    [SerializeField] Transform blockContainer;
    public static BlockPicker picker;
    public Text currentBlockText;
    [SerializeField] Transform bridge;
    [SerializeField] private GameObject efectObj;
    public AudioSource blockpickaudio;
    public AudioSource towergenerateaudio;
    public AudioSource lastVictory;


    private void Awake()
    {
        picker = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            if (isNull == false)
            {
                other.gameObject.transform.SetParent(blockContainer.transform);
                other.gameObject.transform.position = new Vector3(lastBlock.transform.position.x, lastBlock.transform.position.y + blockObjPrefab.transform.localScale.y, lastBlock.transform.position.z);
                lastBlock = other.gameObject;
                blocks.Add(lastBlock);
                currentBlockText.text = blocks.Count.ToString();
                blockpickaudio.Play();
            }
            else
            {
                other.gameObject.transform.SetParent(blockContainer.transform);
                other.gameObject.transform.position = blockContainer.position;
                lastBlock = other.gameObject;
                blocks.Add(lastBlock);
                isNull = false;
                currentBlockText.text = blocks.Count.ToString();
            }
        }

        else if (other.CompareTag("Trap"))
        {
            if(isNull == false)
            {
                Destroy(other.gameObject);
                lastBlock.transform.SetParent(null);
                blocks.Remove(lastBlock);
                currentBlockText.text = blocks.Count.ToString();
                lastBlock.transform.position = Vector3.zero;
                //Destroy(lastBlock);
                if (blocks.Count == 0)
                {
                    lastBlock = null;
                    isNull = true;
                }
                else
                {
                    lastBlock = blocks[blocks.Count - 1];
                }

            }
            else
            {
                return;
            }
           
        }
    }

    public void PlusObj(int random)
    {
        for (int i = 0; i < random; i++)
        {
                if(isNull == true){
                var objX = Instantiate(blockObjPrefab, blockContainer.transform.position, Quaternion.identity);
                objX.transform.SetParent(blockContainer.transform);
                lastBlock = objX;
                blocks.Add(objX);
                isNull = false;
                currentBlockText.text = blocks.Count.ToString();
                }
                else
                {
                PlusValue();
                }
            blockpickaudio.Play();

        }
    }

    public void ReduceObj(int random)
    {
        for (int i = 0; i < random; i++)
        {
            ReduceValue();
            blockpickaudio.Play();
        }
    }

    public void ImpactObj(int random)
    {
        if(isNull == false)
        {
            int plusValue = blocks.Count * random - blocks.Count;
            for (int i = 0; i < plusValue; i++)
            {
                PlusValue();
                blockpickaudio.Play();
            }
        }
        else
        {
            return;
        }
    }

    public void DivideObj(int random)
    {
        float value = Convert.ToSingle(blocks.Count / random);

        int reduceValue = blocks.Count - Convert.ToInt32(Mathf.Ceil(value));

        if(isNull == false)
        {
            for (int i = 0; i < reduceValue; i++)
            {
                ReduceValue();
                blockpickaudio.Play();

            }
        }
    }


    //Eðer listemiz boþ deðilse ve mevcut objelere yeni objeler eklenecekse bu fonksiyon kullanýlýr.
    public void PlusValue()
    {
        var obj = Instantiate(blockObjPrefab, new Vector3(lastBlock.transform.position.x, lastBlock.transform.position.y + blockObjPrefab.transform.localScale.y, lastBlock.transform.position.z), Quaternion.identity,blockContainer.transform);
        //obj.transform.SetParent(blockContainer.transform);
        lastBlock = obj;
        blocks.Add(obj);
        currentBlockText.text = blocks.Count.ToString();
    }

    public void ReduceValue()
    {
        if (blocks.Count > 0)
        {
            blocks.Remove(lastBlock);
            Destroy(lastBlock);
            currentBlockText.text = blocks.Count.ToString();
            if (blocks.Count == 0)
            {
                lastBlock = null;
                isNull = true;
            }
            else
            {
                lastBlock = blocks[blocks.Count - 1];
            }
        }
        else
        {
            isNull = true;

        }
    }

    public void GenerateBlock()
    {
        if(blocks.Count > 0)
        {
            lastBlock.transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y - transform.localScale.y / 2, transform.position.z);
            DestroyOnListBlock();
           currentBlockText.text = blocks.Count.ToString();
            if (blocks.Count == 0)
            {
                lastBlock = null;
                isNull = true;
            }
            else
            {
                lastBlock = blocks[blocks.Count - 1];
            }
        }
    }

    private void DestroyOnListBlock()
    {
        blocks.Remove(lastBlock);
        lastBlock.transform.SetParent(null);
    }


    public void GenerateTower()
    {
        if(blocks.Count > 0)
        {
            RaycastXControl.raycastXControl.CollectRay();
            lastBlock.transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y - transform.localScale.y / 2, transform.position.z);
            transform.position = new Vector3(transform.position.x, transform.position.y + 3 * lastBlock.transform.localScale.y, transform.position.z);
            DestroyOnListBlock();
           currentBlockText.text = blocks.Count.ToString();
            towergenerateaudio.Play();
            if (blocks.Count == 0)
            {
                lastBlock = null;
                isNull = true;
                AnimationController.animationController.WinAnimation();
                efectObj.transform.position = transform.position;
                efectObj.SetActive(true);
                LevelController.levelController.FinishGame();
                ScoreCalculater.scoreCalculater.ScoreCalculator();
                lastVictory.Play();
            }
            else
            {
                lastBlock = blocks[blocks.Count - 1];
            }
        }
    }
}
