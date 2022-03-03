using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeColliderSpawner : MonoBehaviour
{
    [SerializeField] public Transform startPos;
    [SerializeField] public Transform endPos;
    [SerializeField] private BoxCollider startBoxCollider;
    [SerializeField] private BoxCollider endBoxCollider;
    [SerializeField] private BoxCollider bridge;
    [SerializeField] private Transform firstPlatform;
    [SerializeField] private Transform secondPlatform;  
    public Vector3 direction;
    private float distance;
    public static BridgeColliderSpawner bridgeColliderSpawner;
    private void Awake()
    {
        bridgeColliderSpawner = this;
    }

    private void Start()
    {
        startBoxCollider.transform.position = new Vector3(firstPlatform.position.x,firstPlatform.localScale.y / 2 + firstPlatform.position.y + startBoxCollider.size.y / 2, firstPlatform.position.z + firstPlatform.localScale.z / 2 + startBoxCollider.transform.localScale.x/2);
        endBoxCollider.transform.position = new Vector3(secondPlatform.position.x,secondPlatform.localScale.y/2 + secondPlatform.position.y + endBoxCollider.size.y / 2, secondPlatform.position.z + -secondPlatform.localScale.z / 2 + endBoxCollider.transform.localScale.x / 2);
        direction = endPos.position - startPos.position;
        distance = direction.magnitude;
        direction = direction.normalized;
        bridge.transform.forward = direction;
        bridge.size = new Vector3(bridge.size.x, bridge.size.y, distance);

        bridge.transform.position = startPos.transform.position + (direction * distance / 2) + (new Vector3(0, -direction.z, direction.y) * bridge.size.y / 2);
    }

}
