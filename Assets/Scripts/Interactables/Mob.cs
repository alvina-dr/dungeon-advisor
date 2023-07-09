using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mob : Interactable
{
    public GameObject activatedModel;
    public GameObject deactivatedModel;
    public override void Interact()
    {
        SceneManager.LoadScene("TrapMinigame", LoadSceneMode.Additive);
        GPCtrl.instance.caretaker.currentRoom.virtualCamera.gameObject.SetActive(false);
        GPCtrl.instance.caretaker.blockPlayerMovement = true;
        GPCtrl.instance.currentInteractable = this;
    }

    public override void Activate()
    {
        base.Activate();
        activatedModel.SetActive(true);
        deactivatedModel.SetActive(false);
    }


    public override void Deactivate()
    {
        base.Deactivate();
        activated = false;
        activatedModel.SetActive(false);
        deactivatedModel.SetActive(true);
    }
}
