using UnityEngine;

namespace Dungeon
{
    using System;

    public class Room : MonoBehaviour
    {
        public RoomManager RoomManager;

        public void Awake()
        {
            RoomManager.RegisterRoom(this);
        }
    }
}
