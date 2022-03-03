using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSpawner : MonoBehaviour
{
    public bool spawnBlocksBridge = false;
    [SerializeField] private BoxCollider hiddenPlatform;
    private float creatingBrigdeTimer;
    [SerializeField] Transform playerFoot;
    [SerializeField] private GameObject objPrefab;
    BridgeColliderSpawner _bridgeSpawner;
    [SerializeField] private float blockSpawnTime;
    private float falltime = 0.1f;
    private bool finish = false;
    [SerializeField] private ParticleSystem[] efect;
    [SerializeField] private GameObject FinishTower;
    [SerializeField] private GameObject finishObj;
    private float creatingTowerTimer;
    public AudioSource generatebridgeaudio;
    [SerializeField] RaycastXControl raycast;

    private void Start()
    {
        _bridgeSpawner = BridgeColliderSpawner.bridgeColliderSpawner;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StartCollider"))
        {
            spawnBlocksBridge = true;
        }
        else if (other.gameObject.CompareTag("EndCollider"))
        {
            spawnBlocksBridge = false;
        }
        else if (other.gameObject.CompareTag("Finis"))
        {
            finish = true;
            ScoreCalculater.scoreCalculater.blockCount = BlockPicker.picker.blocks.Count;
            //raycast.enabled = true;
        }
    }

    private void Update()
    {
        if (spawnBlocksBridge)
        {
            creatingBrigdeTimer -= Time.deltaTime;
            if (creatingBrigdeTimer < 0 && BlockPicker.picker.isNull == false)
            {
                creatingBrigdeTimer = blockSpawnTime;
                BlockPicker.picker.GenerateBlock();
                generatebridgeaudio.Play();
            }
            else if(BlockPicker.picker.isNull == true && finish == false)
            {
                hiddenPlatform.gameObject.SetActive(false);
                falltime -= Time.deltaTime;
                if(falltime < 0)
                {
                    transform.GetComponent<PlayerMovementController>()._forwardSpeed = 0;
                }
            }
        }
        else if(finish == true)
        {
            PlayerController.playerController.animator.SetBool("running", false);
            PlayerMovementController.playerMovementController._forwardSpeed = 0;
            FinishTower.SetActive(true);
            creatingTowerTimer -= Time.deltaTime;
            if(creatingTowerTimer < 0)
            {
                creatingTowerTimer = 0.05f;
                BlockPicker.picker.GenerateTower();
                transform.GetComponent<Rigidbody>().useGravity = false;
            }
            
        }
    }
}