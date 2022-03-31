
using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MainPlayerFillBarControl : MonoBehaviour
{
    [SerializeField]
    private Image mask;
    [SerializeField] private Transform wholeFillBar;
    

    public void FillBar()
    {
        DOTween.Complete("mainPlayerFillBar");
        var currentStackAmount = MainPlayer.Instance.StackController.CurrentstackAmount;
        var maxStackAmount = MainPlayer.Instance.StackController.maxStackCount;
        var fillAmount = Mathf.InverseLerp(0, maxStackAmount, currentStackAmount);
        mask.DOFillAmount(fillAmount, .5f).SetEase(Ease.InQuad).SetId("mainPlayerFillBar");
    }

    public void FillBarFullWarning()
    {
        DOTween.Complete("fillBarWarning");
        wholeFillBar.DOPunchScale(Vector3.one * .1f, 1f,3).SetEase(Ease.Linear).SetId("obstackleWarning");

    }

    public void FillBarObstackleTriggerWarning()
    {
        DOTween.Complete("obstackleWarning");
        wholeFillBar.DOPunchRotation(Vector3.forward * 10f, .8f).SetEase(Ease.Linear).SetId("fillBarWarning");
    }
    public void FillBarObstackleTriggerScaleWarning()
    {
        DOTween.Complete("obstackleWarning");
        wholeFillBar.DOPunchScale(Vector3.one * .6f, 1f, 3).SetEase(Ease.Linear).SetId("scaleWarning");
    }
}
