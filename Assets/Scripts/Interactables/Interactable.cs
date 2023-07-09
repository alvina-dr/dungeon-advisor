using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    #region Fields
    public bool activated;
    #endregion

    #region Methods 

    public abstract void Interact();

    public virtual void Activate()
    {
        activated = true;
    }
    public virtual void Deactivate()
    {

    }


    #endregion
}
