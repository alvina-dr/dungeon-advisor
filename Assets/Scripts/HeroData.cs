using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/HeroData", order = 1)]
public class HeroData : ScriptableObject
{
    public Hero heroPrefab;
    public float timePerRoom;
}
