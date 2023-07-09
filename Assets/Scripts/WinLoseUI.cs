using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class WinLoseUI : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _winUI;
    
    [SerializeField] private GameObject _loseUI;

    private Caretaker _caretaker;

    #endregion

    #region Init Methods

    private void Awake()
    {
        _winUI.SetActive(false);
        _loseUI.SetActive(false);
    }

    private void Start()
    {
        _caretaker = GPCtrl.instance.caretaker;
    }

    #endregion

    #region Logic Methods

    public void SpawnWinGameUI()
    {
        _caretaker.blockPlayerMovement = true;

        _winUI.transform.localScale = Vector3.zero;
        
        _winUI.SetActive(true);

        _winUI.transform.DOScale(1.1f, 0.4f);
        _winUI.transform.DOScale(1, 0.4f);
    }

    public void SpawnLoseUI()
    {
        _caretaker.blockPlayerMovement = true;
        
        _loseUI.transform.localScale = Vector3.zero;

        _loseUI.SetActive(true);

        _loseUI.transform.DOScale(1.1f, 0.4f);
        _loseUI.transform.DOScale(1, 0.4f);
    }

    private void CloseUI()
    {
        if (_winUI.activeInHierarchy)
        {
            _winUI.transform.DOScale(1.1f, 0.4f);
            _winUI.transform.DOScale(0f, 0.4f);
            
            _winUI.SetActive(false);
        }

        if (_loseUI.activeInHierarchy)
        {
            _loseUI.transform.DOScale(1.1f, 0.4f);
            _loseUI.transform.DOScale(0f, 0.4f);
            
            _loseUI.SetActive(false);
        }
    }

    public void BackToMainMenu()
    {
        CloseUI();

        if (!_winUI.activeInHierarchy || !_loseUI.activeInHierarchy)
        {
            SceneManager.LoadScene(0);  
        }
    }

    public void RetryGame()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    #endregion
}
