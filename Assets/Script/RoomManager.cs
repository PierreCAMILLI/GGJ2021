using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public Room CurrentRoom;

    public List<Room> Rooms;

    public void Start()
    {
        foreach (var room in Rooms)
        {
            room.gameObject.SetActive(false);
        }

        CurrentRoom.gameObject.SetActive(true);
    }

    public void ChangeRoom(Room room)
    {
        CurrentRoom.gameObject.SetActive(false);
        room.gameObject.SetActive(true);
        CurrentRoom = room;
    }
}
