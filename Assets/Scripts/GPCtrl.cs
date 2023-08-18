using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GPCtrl : MonoBehaviour
{
    public static GPCtrl instance;

    public float timer;
    public List<Interactable> allInteractableList = new List<Interactable>();
    public Room startRoom;
    public List<Room> roomList;
    public List<HeroData> heroDataList;
    public Hero currentHero;
    public Caretaker caretaker;
    public Interactable currentInteractable;
    public WinLoseUI _winLoseUI;
    public UINotif UINotif;
    public List<int> scoreList;

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
    }

    private void Start()
    {
        HeroData[] _heroDatas = Resources.LoadAll<HeroData>("HeroData/");
        for (int i = 0; i < _heroDatas.Length; i++)
        {
            heroDataList.Add(_heroDatas[i]);
        }        
        Interactable[] _interactables = FindObjectsOfType<Interactable>();
        for (int i = 0; i < _interactables.Length; i++)
        {
            allInteractableList.Add(_interactables[i]);
        }
        Room[] _rooms = FindObjectsOfType<Room>();
        for (int i = 0; i < _rooms.Length; i++)
        {
            roomList.Add(_rooms[i]);
        }
        StartGame();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Y))
        {
            GameWin();
        }
    }

    public void ResetTimer()
    {
        timer = 0;
    }

    public void LaunchHero(HeroData data)
    {
        UINotif.Pop("NEW WAVE");
        currentHero = Instantiate(data.heroPrefab);
        currentHero.data = data;
        currentHero.ExploreRoom(startRoom);
    }

    public void StartGame() {
        DOVirtual.DelayedCall(5f, () => LaunchHero(heroDataList[Random.Range(0, heroDataList.Count)]));
    }

    public void EndWave(bool natural = true)
    {
        int _score = currentHero.usedInteractableList.Count * 5 * 100;
        if (natural) _score *= 2;
        UINotif.Pop("SCORE : " + _score);
        scoreList.Add(_score);
        Destroy(currentHero.gameObject);
        if (scoreList.Count <3)
        {
            DOVirtual.DelayedCall(15, () => LaunchHero(heroDataList[Random.Range(0, heroDataList.Count)]));
        } else
        {
            GameWin();
        }
    }

    public void GameOver()
    {
        _winLoseUI.SpawnLoseUI();
    }

    public void GameWin()
    {
        _winLoseUI.SpawnWinGameUI();
    }
}
