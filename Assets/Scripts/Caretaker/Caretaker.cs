using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Caretaker : MonoBehaviour
{
    #region Fields
    
    public Vector3 direction;
    
    public float speed;
    
    public Rigidbody rb;
    
    public List<Interactable> interactableList;
    
    public Room currentRoom;

    [SerializeField] private GameObject _movementParticles;

    [SerializeField] private Transform _particlesPosition;

    public float timeBtwTrails;

    public CinemachineBrain cinemachineBrain;
    
    #endregion

    #region Methods
    public void Interact()
    {
        if (interactableList[interactableList.Count - 1] == null) return;
        
        if (interactableList[interactableList.Count - 1].activated) return;

        Interactable _interactable = interactableList[interactableList.Count - 1];
        
        _interactable.Interact();
        
        interactableList.Remove(_interactable);
    }

    public void EnterRoom(Room _room)
    {
        if (currentRoom != null) currentRoom.virtualCamera.gameObject.SetActive(false); 
        currentRoom = _room;
        currentRoom.virtualCamera.gameObject.SetActive(true);
        if (GPCtrl.instance.currentHero.currentRoom == _room)
        {
            GPCtrl.instance.GameOver();
        }
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

        if (direction != Vector3.zero)
        {
            if (timeBtwTrails <= 0)
            {
                Instantiate(_movementParticles, _particlesPosition);

                timeBtwTrails = 0.5f;
            }
            else
            {
                timeBtwTrails -= Time.deltaTime;
            }
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
