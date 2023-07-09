using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPCtrl : MonoBehaviour
{
    public static GPCtrl instance;

    public float timer;
    public List<Interactable> allInteractableList = new List<Interactable>();
    public Room startRoom;
    public List<HeroData> heroDataList;
    public Hero currentHero;
    public Caretaker caretaker;

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
        Destroy(currentHero);
    }

    public void GameOver()
    {

    }
}
