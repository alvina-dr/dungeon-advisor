using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Room : MonoBehaviour
{
    public List<Interactable> interactableList;
    public float cameraZoom;
    public CinemachineVirtualCamera virtualCamera;
    public List<Room> relatedRoomList;
    public Transform roomCenter;

    //maybe allow for room creation (setup ?)
}
