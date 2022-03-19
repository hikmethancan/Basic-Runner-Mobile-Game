using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{

    public void IncreaseMaxStackAmount()
    {
        if (!UIManager.Instance.CurrencyUI.DecreaseGoldAmount()) return;
        MainPlayer.Instance.StackController.maxStackCount++;
        PlayerPrefsKeys.MaxStackAmount = MainPlayer.Instance.StackController.maxStackCount;
        MainPlayer.Instance.MainPlayerFillBarControl.FillBar();
    }
}
