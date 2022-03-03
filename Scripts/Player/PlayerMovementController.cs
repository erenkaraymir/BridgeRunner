using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public static PlayerMovementController playerMovementController;

    [SerializeField] public float _forwardSpeed;
    [SerializeField] private float _horizontalSpeed;
    private float xPosition;

    [SerializeField] private float _positiveLimitX;
    [SerializeField] private float _negativeLimitX;

    private float newX;
    private float defaultZ;

    public void Start()
    {
        playerMovementController = this;
    }

    void Update()
    {
        if (LevelController.levelController.gameState != LevelController.GameState.GameMenu)
        {
            return;
        }
        if (Input.GetMouseButton(0))
        {
            xPosition = Input.GetAxis("Mouse X");
        }
        newX = transform.position.x +  xPosition * _horizontalSpeed * Time.deltaTime;
        newX = Mathf.Clamp(newX, _negativeLimitX, _positiveLimitX);
        defaultZ = transform.position.z + (_forwardSpeed * Time.deltaTime);

        Vector3 playerPosition = new Vector3(newX, transform.position.y, defaultZ);
        transform.position = playerPosition;
    }
}
