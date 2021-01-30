using System.Collections.Generic;
using UnityEngine;

namespace Dungeon
{
    using UnityEngine.Events;

    public class RoomManager : SingletonBehaviour<RoomManager>
    {
        [SerializeField] private Room CurrentRoom;

        [SerializeField] private UnityEvent RoomChanged;


        private readonly List<Room> _rooms = new List<Room>();

        private void Start()
        {
            foreach (var room in _rooms)
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

            RoomChanged.Invoke();
        }

        public void RegisterRoom(Room room)
        {
            _rooms.Add(room);
        }
    }
}
