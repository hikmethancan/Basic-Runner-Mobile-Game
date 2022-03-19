using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void GameStart()
    {
        UIManager.Instance.ONLevelStart?.Invoke();
        Debug.Log("Şuanki level indexi : "+SceneManager.GetActiveScene().buildIndex);
    }
}
