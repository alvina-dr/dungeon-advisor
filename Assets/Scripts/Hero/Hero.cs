using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : MonoBehaviour
{
    public HeroData data;
    public Room previousRoom;
    public Room currentRoom;
    public Room nextRoom;
    public List<Room> allRoomList;
    public List<Room> exploredRoomList;
    public float timer;

    public virtual void ChooseNextRoom() {
        timer = 0;
        previousRoom = currentRoom;
    }
    public void ExploreRoom(Room _room)
    {
        exploredRoomList.Add(_room);
        currentRoom = _room;
        transform.position = currentRoom.roomCenter.position;
        if (GPCtrl.instance.caretaker.currentRoom == _room)
        {
            GPCtrl.instance.GameOver();
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= data.timePerRoom) ChooseNextRoom();
    }
}
