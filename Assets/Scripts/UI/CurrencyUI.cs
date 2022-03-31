
using System.Diagnostics;
using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    public TMP_Text currencyText;
    public RectTransform GoldImage;
    public RectTransform goldInitPos;
    public GameObject goldPrefab;
    [HideInInspector][Range(0f,300f)]
    public int currencyAmount;
    private void Awake()
    {
        currencyAmount = PlayerPrefsKeys.GoldAmount;
    }

    private void Start()
    {
        SetCurrencyText();
        ResetData();
    }
    
    public void IncreaseGoldAmount()
    {
        currencyAmount++;
        PlayerPrefsKeys.GoldAmount = currencyAmount;
        SetCurrencyText();
        ScaleCurrencyImage();
    }

    private void SetCurrencyText()
    {
        UIManager.Instance.CurrencyUI.currencyText.SetText(currencyAmount.ToString());
    }

    public bool DecreaseGoldAmount()
    {
        if (currencyAmount == 0) return false;
        currencyAmount--;
        PlayerPrefsKeys.GoldAmount = currencyAmount;
        SetCurrencyText();
        return true;
    }
     
    public void ScaleCurrencyImage()
    {
        DOTween.Complete("scaleGoldImage");
        GoldImage.DOPunchScale(Vector3.one * .4f, .8f, 3).SetEase(Ease.Linear).SetId("scaleGoldImage");
    }


    public void ResetData()
    {
        currencyAmount = 0;
        MainPlayer.Instance.StackController.maxStackCount = 10;
        MainPlayer.Instance.StackController.CurrentstackAmount = 0;
        UIManager.Instance.LevelManager.CurrentLevelIndex = 0;
        
        PlayerPrefsKeys.StackAmount = MainPlayer.Instance.StackController.CurrentstackAmount;
        PlayerPrefsKeys.GoldAmount = currencyAmount;
        PlayerPrefsKeys.MaxStackAmount = MainPlayer.Instance.StackController.maxStackCount;
        PlayerPrefsKeys.CurrentLevel = UIManager.Instance.LevelManager.CurrentLevelIndex;
        UIManager.Instance.LevelManager.SetCurrentLevelText();
        SetCurrencyText();
        MainPlayer.Instance.MainPlayerFillBarControl.FillBar();
    }
   
}
