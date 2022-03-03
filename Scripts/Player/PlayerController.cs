using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public static PlayerController playerController;
    void Start()
    {
        playerController = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Finish"))
        //{
        //    //LevelController.levelController.gameState = LevelController.GameState.FinishMenu;
        //   //LevelController.levelController.FinishGame();
        //}
        if (other.CompareTag("FallTrigger"))
        {
            LevelController.levelController.gameState = LevelController.GameState.GameOverMenu;
            LevelController.levelController.GameOver();
            AnimationController.animationController.DeadAnimation();
        }
    }
}
