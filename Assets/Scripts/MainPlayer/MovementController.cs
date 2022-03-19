using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Common;
using DG.Tweening;

public class MovementController : MonoBehaviour
{
    public float moveSpeed; 
    
    private LeanManualTranslate leanManualTranslate;
    private float firstMultiplier = 0f;
    private bool canMoveForward = false;
    
    public LeanManualTranslate LeanManualTranslate
    {
        get
        {
            if (leanManualTranslate == null)
            {
                return leanManualTranslate = GetComponent<LeanManualTranslate>();
            }

            return leanManualTranslate;
        }
    }

    private void Start()
    {
        firstMultiplier = LeanManualTranslate.Multiplier;
        LeanManualTranslate.Multiplier = 0f;
        UIManager.Instance.ONLevelStart += () =>
        {
            LeanManualTranslate.Multiplier = firstMultiplier;
            canMoveForward = true;
        };

    }
    public void CloseDragInput()
    {
        LeanManualTranslate.Multiplier = 0f;
        canMoveForward = false;
    }

    private void Update()
    {
        if (canMoveForward)
        {
            transform.Translate(transform.forward * Time.deltaTime * moveSpeed);
        }
    }
}
