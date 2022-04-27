
using System.Collections;
using DG.Tweening;
using UnityEngine;


public class CollectiblesCatcher : MonoBehaviour,IScaleCollectible
{
    public bool isFinished = false;

    [SerializeField] private Transform diamondMovePos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            var getDiaomnd = other.gameObject;
            getDiaomnd.GetComponent<CollectibleMovement>().repeatable = false; // => Burayı kontrol et Script komponentine ulaş
            MainPlayer.Instance.StackController.IncreaseCurrentStackAmount();
            StartCoroutine(ScaleCollectibles(other, .3f, 1.4f));
            //DiamondMoveToPlayer(other.gameObject);
        }

        if (other.gameObject.CompareTag("Gold"))
        {
            GameObject goldPref = UIManager.Instance.CurrencyUI.goldPrefab;
            Instantiate(goldPref,Camera.main.WorldToScreenPoint(other.transform.position),goldPref.transform.rotation,UIManager.Instance.CurrencyUI.transform);
            other.gameObject.SetActive(false);
            UIManager.Instance.CurrencyUI.IncreaseGoldAmount();
        }
        
        if (other.gameObject.CompareTag("Obstacle"))
        {
            MainPlayer.Instance.StackController.DecreaseCurrentStackAmount();
            MainPlayer.Instance.MainPlayerFillBarControl.FillBarObstackleTriggerWarning();
            MainPlayer.Instance.MainPlayerFillBarControl.FillBarObstackleTriggerScaleWarning();
        }

        if (other.gameObject.CompareTag("FinishBorder"))
        {
            MainPlayer.Instance.MovementController.CloseDragInput();
            MainPlayer.Instance.MainPlayerAnimationController.SetDance();
            isFinished = true;
            UIManager.Instance.Invoke("FinishPanelActive",3f);
        }
    }

    // IEnumerator CoinParticleEffect(Collider other,float time,float speed)
    // {
    //     float i = 0.0f;
    //     float rate = (1.0f / time) * speed;
    //     while (i < 1.0f) {
    //         i += Time.deltaTime * rate;
    //         other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    //         yield return null;
    //     }
    //     UIManager.Instance.CurrencyUI.ScaleCurrencyImage();
    //     other.gameObject.SetActive(false);
    // }

    public IEnumerator ScaleCollectibles(Collider other, float time, float speed)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f) {
            i += Time.deltaTime * rate;
            var diamondLocalScale = other.transform.localScale;
             other.transform.localScale = Vector3.Lerp(other.transform.localScale,other.transform.localScale * 2f , i*1.2f);
            other.transform.localScale = Vector3.Lerp(other.transform.localScale,Vector3.zero *Time.deltaTime, i);
            //other.transform.position = Vector3.Lerp(other.transform.position, diamondMovePos.position, 1.2f * i);
            yield return null;
        }
        other.gameObject.SetActive(false);
    }

    //private void ScaleDiamond(GameObject other)
    //{
    //    other.transform.DOScale()
    //}

    private void DiamondMoveToPlayer(GameObject diamondObj)
    {
        Debug.Log("Dİamond Move To Player çalışıyor");
        diamondObj.transform.DOMove(diamondMovePos.position,.5f);
    }

}
