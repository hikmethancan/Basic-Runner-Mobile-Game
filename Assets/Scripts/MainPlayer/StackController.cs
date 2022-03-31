
using System;
using UnityEngine;

public class StackController : MonoBehaviour
{
    [SerializeField] public int maxStackCount = 10;
    public int CurrentstackAmount { get; set; }

    private void Awake()
    {
        CurrentstackAmount = PlayerPrefsKeys.StackAmount;
        maxStackCount = PlayerPrefsKeys.MaxStackAmount;
        MainPlayer.Instance.MainPlayerFillBarControl.FillBar();
    }

    public void IncreaseCurrentStackAmount()
    {
        if (IsFullStacked())
        {
            MainPlayer.Instance.MainPlayerFillBarControl.FillBarFullWarning();
        }
       
        if (!IsFullStacked())
        {
            CurrentstackAmount++;
            PlayerPrefsKeys.StackAmount = CurrentstackAmount;
            MainPlayer.Instance.MainPlayerFillBarControl.FillBar();
        }
    }

    public void DecreaseCurrentStackAmount()
    {
        if (CurrentstackAmount <= 0) return;
        MainPlayer.Instance.MainPlayerAnimationController.SetRun1();
        CurrentstackAmount--;
        MainPlayer.Instance.MainPlayerFillBarControl.FillBar();
        PlayerPrefsKeys.StackAmount = CurrentstackAmount;
    }

    private bool IsFullStacked()
    {
        if (CurrentstackAmount >= maxStackCount)
        {
            MainPlayer.Instance.MainPlayerAnimationController.SetRun2();
            return true;
        }
        return false;

    }
}
