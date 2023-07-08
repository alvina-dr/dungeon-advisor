using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    #region Fields

    #endregion

    #region Methods 

    public abstract void Interact();

    public abstract void Deactivate();
    #endregion
}
