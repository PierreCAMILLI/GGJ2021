using UnityEngine;
using UnityEngine.Events;

namespace Dungeon
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private RoomManager RoomManager;

        [SerializeField] private Room Room;

        [SerializeField] private Door NextRoomDoor;

        [SerializeField] private GameObject In;

        [SerializeField] private UnityEvent RoomChanged;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;

            RoomManager.ChangeRoom(NextRoomDoor.Room);
            other.transform.position = NextRoomDoor.In.transform.position;

            RoomChanged.Invoke();
        }
    }
}
