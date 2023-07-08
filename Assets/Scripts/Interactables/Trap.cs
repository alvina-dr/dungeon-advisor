using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trap : Interactable
{
    public override void Interact() {
        activated = true;
        //animation repair
        Debug.Log("TRAP REPAIRED");
    }
    

    public override void Deactivate() {
        activated = false;
    }
}
