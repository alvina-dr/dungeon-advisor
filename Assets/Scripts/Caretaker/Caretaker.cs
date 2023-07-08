using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Caretaker : MonoBehaviour
{
    #region Fields
    public Vector3 direction;
    public float speed;
    public Rigidbody rb;
    public List<Interactable> interactableList;
    public Room currentRoom;
    #endregion

    #region Methods
    public void Interact()
    {
        if (interactableList[interactableList.Count - 1] == null) return;
        if (interactableList[interactableList.Count - 1].activated) return;
        Debug.Log(interactableList[interactableList.Count - 1].name);
        Interactable _interactable = interactableList[interactableList.Count - 1];
        _interactable.Interact();
        interactableList.Remove(_interactable);
    }
    #endregion

    #region UnityAPI
    void Update()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.z * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Interactable _interactable = other.GetComponent<Interactable>();
        if (_interactable != null)
        {
            if (!interactableList.Contains(_interactable))
                interactableList.Add(_interactable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Interactable _interactable = other.GetComponent<Interactable>();
        if (_interactable != null)
        {
            if (!interactableList.Contains(_interactable))
                interactableList.Remove(_interactable);
        }
    }
    #endregion
}
