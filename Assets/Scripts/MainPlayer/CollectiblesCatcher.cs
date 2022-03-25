
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
            other.GetComponent<CollectibleMovement>().enabled = false; // => Burayı kontrol et Script komponentine ulaş
            MainPlayer.Instance.StackController.IncreaseCurrentStackAmount();
            StartCoroutine(ScaleCollectibles(other,1f,1f));
            DiamondMoveToPlayer(other.gameObject);
        }

        if (other.gameObject.CompareTag("Gold"))
        {
            GameObject goldPref = UIManager.Instance.CurrencyUI.goldPrefab;
            Instantiate(goldPref,UIManager.Instance.CurrencyUI.goldInitPos.position,goldPref.transform.rotation);
            other.gameObject.SetActive(false);
            UIManager.Instance.CurrencyUI.IncreaseGoldAmount();
        }
        
        if (other.gameObject.CompareTag("Obstacle"))
        {
            MainPlayer.Instance.StackController.DecreaseCurrentStackAmount();
            MainPlayer.Instance.MainPlayerFillBarControl.FillBarObstackleTriggerWarning();
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
            // Vector3 localScale = other.transform.localScale;
            // localScale= Vector3.Lerp(localScale,localScale * 2f , i*1.2f);
            // localScale = Vector3.Lerp(localScale,Vector3.zero *Time.deltaTime, i);
            other.transform.position = Vector3.Lerp(other.transform.position, diamondMovePos.position, 1.2f * i);
            yield return null;
        }
        // other.gameObject.SetActive(false);
    }

    private void DiamondMoveToPlayer(GameObject diamondObj)
    {
        diamondObj.transform.DOMove(diamondMovePos.position,.5f);
    }

}
