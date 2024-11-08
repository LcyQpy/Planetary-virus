using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Button ExitBtn;
    public Button StartBtn;
    void Start()
    {
        ExitBtn.onClick.AddListener(OnExitBtnClick);
        StartBtn.onClick.AddListener(OnStartBtnClick);
    }

    private void OnExitBtnClick()
    {
        Application.Quit();
    }

    private void OnStartBtnClick()
    {
        SceneManager.LoadScene(1);
    }
}
