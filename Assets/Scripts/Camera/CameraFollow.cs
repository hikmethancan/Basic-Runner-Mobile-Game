using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{   
    
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 finishOffset;
    [SerializeField] private float followSpeed;

    
    private Transform player;
    private void Start()
    {
        player = GameObject.Find("MainPlayer").transform;

    }
    
    private void LateUpdate()
    {
        if (!MainPlayer.Instance.CollectiblesCatcher.isFinished)
        {
            transform.position = Vector3.Lerp(transform.position, player.position + offset, Time.deltaTime * followSpeed);
        }
        else
        {
            MoveToFinishCamera();
        }
    }
    
    private void MoveToFinishCamera()
    {
        // // transform.position = Vector3.Lerp(transform.position+new Vector3(0,0,4f*Time.deltaTime), player.position + finishOffset, Time.deltaTime * .8f);
        // DOTween.Complete("moveToFinish");
        // transform.DOMove(player.position + finishOffset, 10f).SetEase(Ease.OutSine)
        //     .SetId("moveToFinish");
        // DOTween.Complete("rotateToFinish");
        // transform.DORotate(new Vector3(20.1f, 180f, 0f), 10f).SetEase(Ease.OutSine).SetId("rotateToFinish");
        player.transform.DORotate(new Vector3(0,180f,0), 3f).SetEase(Ease.OutSine);
    }

}
