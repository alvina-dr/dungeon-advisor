using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Warrior : Hero
{
    public override void ChooseNextRoom()
    {
        base.ChooseNextRoom();
        for (int i = 0; i < currentRoom.relatedRoomList.Count; i++)
        {
            if (!exploredRoomList.Contains(currentRoom.relatedRoomList[i])) {
                ExploreRoom(currentRoom.relatedRoomList[i]);
                return;
            }
        }
        GPCtrl.instance.EndWave();
    }

    public override void ExploreRoom(Room _room)
    {
        //if ()
        //condition d'arr�t d'exploration
        base.ExploreRoom(_room);
    }
}
