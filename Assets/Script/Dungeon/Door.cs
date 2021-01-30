using UnityEngine;
using UnityEngine.Events;

namespace Dungeon
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Room Room;

        [SerializeField] private Door NextRoomDoor;

        [SerializeField] private GameObject In;

        /*
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;

            other.transform.position = NextRoomDoor.In.transform.position;

            Room.RoomManager.ChangeRoom(NextRoomDoor.Room);
        }
        */

        public void OnAction(PlayerController player)
        {
            GlobalEvents.Instance.OnBlackScreenFadedEvent.AddListener(TeleportPlayer);
            GlobalEvents.Instance.EventTeleport.Invoke();
        }

        private void TeleportPlayer()
        {
            PlayerController.Instance.transform.position = NextRoomDoor.In.transform.position;
            Room.RoomManager.ChangeRoom(NextRoomDoor.Room);
        }
    }
}
