using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Room room;

    private void OnTriggerEnter(Collider other)
    {
        Caretaker caretaker = other.GetComponent<Caretaker>();
        if (caretaker != null)
        {
            caretaker.EnterRoom(room);
        }
    }
}
