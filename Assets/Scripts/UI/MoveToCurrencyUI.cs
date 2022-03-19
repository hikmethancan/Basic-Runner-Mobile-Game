using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveToCurrencyUI : MonoBehaviour
{
    private Vector3 goldPos;
    Vector2 viewportPoint; 
    
    private void Update()
    {
        // transform.position = Vector3.MoveTowards(transform.position,UIManager.Instance.CurrencyUI.GoldImage.position,Time.deltaTime * 12f);
    }

    private void Start()
    {
        StartCoroutine(MoveToCurrency());
    }

    IEnumerator MoveToCurrency()
    {
        float time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime * 1.5f;
            transform.position += Vector3.forward * Time.deltaTime * MainPlayer.Instance.MovementController.moveSpeed;
            transform.DOMove(UIManager.Instance.CurrencyUI.GoldImage.position, 7f).SetEase(Ease.InSine);
        }
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);
    }
    
}
