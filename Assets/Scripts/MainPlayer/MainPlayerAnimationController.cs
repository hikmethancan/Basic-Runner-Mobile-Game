using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    public Animator Animator
    {
        get
        {
            if (animator == null)
            {
                return animator = GetComponentInChildren<Animator>();
            }

            return animator;
        }
    }

    private void Start()
    {
        UIManager.Instance.ONLevelStart += () =>
        {
            SetRun1();
        };
    }

    public void SetIdle()
    {
        Animator.SetTrigger("Idle");
    }
    
    public void SetRun1()
    {
        Animator.SetTrigger("Run1");
        Animator.SetBool("Run22",false);
    }
    
    public void SetRun2()
    {
        Animator.SetTrigger("Run2");
        Animator.SetBool("Run22",true);
    }

    public void SetDance()
    {
        Animator.SetTrigger("Dance");
    }
}
