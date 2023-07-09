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
    }

    public void ResetTimer()
    {
        timer = 0;
    }

    public void LaunchHero(HeroData data)
    {
        currentHero = Instantiate(data.heroPrefab);
        currentHero.data = data;
        currentHero.ExploreRoom(startRoom);
    }

    public void StartGame() {
        LaunchHero(heroDataList[Random.Range(0, heroDataList.Count)]);
    }

    public void EndWave()
    {
        Debug.Log("END WAVE");
        //Score Calculation
        UINotif.Pop("SCORE : " + currentHero.usedInteractableList.Count * 5);
        Destroy(currentHero);
        DOVirtual.DelayedCall(180f, () => LaunchHero(heroDataList[Random.Range(0, heroDataList.Count)]));
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
