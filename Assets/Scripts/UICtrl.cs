using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class UICtrl : MonoBehaviour
{
    #region Fields
    [SerializeField] private UIWinMenu _winUI;
    [SerializeField] private GameObject _loseUI;
    [SerializeField] private CanvasGroup _startUI;
    [SerializeField] private TextMeshProUGUI _scoreText;
    private Caretaker _caretaker;
    #endregion

    #region Methods
    public void SpawnWinGameUI()
    {
        _caretaker.blockPlayerMovement = true;
        _winUI.transform.localScale = Vector3.zero;
        _scoreText.gameObject.SetActive(false);
        _winUI.gameObject.SetActive(true);
        _winUI.transform.DOScale(1.1f, 0.4f).OnComplete(() =>
        {
            _winUI.transform.DOScale(1, 0.4f).OnComplete(() =>
            {
                _winUI.stampAnimation.Func_PlayUIAnim(false);
                DOVirtual.DelayedCall(.4f, () =>
                {
                    int finalScore = 0;
                    for (int i = 0; i < GPCtrl.instance.scoreList.Count; i++)
                    {
                        finalScore += GPCtrl.instance.scoreList[i];
                    }
                    _scoreText.text = finalScore.ToString();
                    _scoreText.gameObject.SetActive(true);
                });
            });
        });

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
        if (_winUI.gameObject.activeInHierarchy)
        {
            _winUI.transform.DOScale(1.1f, 0.4f);
            _winUI.transform.DOScale(0f, 0.4f);
            _winUI.gameObject.SetActive(false);
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
        if (!_winUI.gameObject.activeInHierarchy || !_loseUI.activeInHierarchy)
        {
            SceneManager.LoadScene(0);  
        }
    }

    public void RetryGame()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    public void CloseStartMenu()
    {
        _startUI.DOFade(0, .3f).OnComplete(() =>
        {
            _startUI.gameObject.SetActive(false);
            GPCtrl.instance.StartGame();
        });
    }
    #endregion

    #region Unity API
    private void Awake()
    {
        _winUI.gameObject.SetActive(false);
        _loseUI.SetActive(false);
        _startUI.gameObject.SetActive(true);
    }

    private void Start()
    {
        _caretaker = GPCtrl.instance.caretaker;
    }
    #endregion
}
