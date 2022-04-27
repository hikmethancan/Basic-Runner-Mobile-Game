
using DG.Tweening;
using UnityEngine;

public class MoveToCurrencyUI : MonoBehaviour
{
    private Vector3 goldPos;
    Vector2 viewportPoint; 
    

    private void Start()
    {
        transform.DOMove(UIManager.Instance.CurrencyUI.GoldImage.position, .5f).SetEase(Ease.InSine).OnComplete(() =>
        {
            gameObject.SetActive(false);
            UIManager.Instance.CurrencyUI.GoldImage.DOPunchScale(Vector3.one * .9f, .2f, 2, .5f);
        });
    }

   
    
}
