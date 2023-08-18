using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    #region Fields
    public bool activated;
    public GameObject particle;
    #endregion

    #region Methods 

    public abstract void Interact();

    public virtual void Activate()
    {
        activated = true;
        GameObject _particle = Instantiate(particle, transform);
    }
    public virtual void Deactivate()
    {

    }


    #endregion
}
