using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animatorPlayer;
    public Animator animatorUI;
    public static AnimationController animationController;

    private void Awake()
    {
        animationController = this;
    }

    private void Start()
    {
        animatorPlayer.SetBool("win", false);
        animatorPlayer.SetBool("dead", false);
    }

    public void DeadAnimation()
    {
        animatorPlayer.SetBool("dead",true);
    }

    public void WinAnimation()
    {
        animatorPlayer.SetBool("win", true);
    }
}
