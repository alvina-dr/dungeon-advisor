using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Trap : Interactable
{
    public override void Interact() {
        activated = true;
        //animation repair
        Debug.Log("TRAP REPAIRED");
        //Launch mini game
        SceneManager.LoadSceneAsync("TrapMinigame", LoadSceneMode.Additive);
    }
    

    public override void Deactivate() {
        activated = false;
    }
}
