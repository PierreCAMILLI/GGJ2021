using System.Collections.Generic;
using UnityEngine;

public class RoomManager : SingletonBehaviour<RoomManager>
{
    [SerializeField] private Room CurrentRoom;

    [SerializeField] private List<Room> Rooms;

    private void Start()
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
