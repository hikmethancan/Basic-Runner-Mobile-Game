
using System.Collections;
using UnityEngine.Events;

public class UIManager : Singleton<UIManager>
{
    public UnityAction ONLevelStart;
    private TapToPlayPanel tapToPlayPanel;
    private CurrencyUI currenyUI;
    private FinishPanel finishPanel;
    private LevelManager levelManager;

    public LevelManager LevelManager
    {
        get
        {
            if (levelManager == null)
            {
                return levelManager = GetComponentInChildren<LevelManager>(true);
            }

            return levelManager;
        }
    }
    public FinishPanel FinishPanel
    {
        get
        {
            if (finishPanel == null)
            {
                return finishPanel = GetComponentInChildren<FinishPanel>(true);
            }

            return finishPanel;
        }
    }
    public TapToPlayPanel TapToPlayPanel
    {
        get
        {
            if (tapToPlayPanel == null)
            {
                return tapToPlayPanel = GetComponentInChildren<TapToPlayPanel>(true);
            }

            return tapToPlayPanel;
        }
    }
    
    public CurrencyUI CurrencyUI
    {
        get
        {
            if (currenyUI == null)
            {
                return currenyUI = GetComponentInChildren<CurrencyUI>(true);
            }

            return currenyUI;
        }
    }

    private void Awake()
    {
        TapToPlayPanel.gameObject.SetActive(true);
        ONLevelStart += () =>
        {
            tapToPlayPanel.gameObject.SetActive(false);
        };
    }

    public void FinishPanelActive()
    {
        FinishPanel.gameObject.SetActive(true);
    }
    
}
