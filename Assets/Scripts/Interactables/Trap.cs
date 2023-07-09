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
        SceneManager.LoadScene("TrapMinigame", LoadSceneMode.Additive);
        GPCtrl.instance.caretaker.currentRoom.virtualCamera.gameObject.SetActive(false);
        GPCtrl.instance.caretaker.blockPlayerMovement = true;
    }


    public override void Deactivate() {
        activated = false;
    }
}
