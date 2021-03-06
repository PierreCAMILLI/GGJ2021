using UnityEngine;
using UnityEngine.Events;

namespace Dungeon
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Room Room;

        [SerializeField] private Door NextRoomDoor;

        [SerializeField] private GameObject In;
        
        [SerializeField] private bool keyRequired;

        /*
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;

            other.transform.position = NextRoomDoor.In.transform.position;

            Room.RoomManager.ChangeRoom(NextRoomDoor.Room);
        }
        */

        public void OnAction()
        {
            if (keyRequired) {
                if (PlayerInfos.Instance.Keys > 0) {
                    GlobalEvents.Instance.OnBlackScreenFadedEvent.AddListener(TeleportPlayer);
                    GlobalEvents.Instance.EventTeleport.Invoke();
                    PlayerInfos.Instance.Keys--;
                }
            } else {
                GlobalEvents.Instance.OnBlackScreenFadedEvent.AddListener(TeleportPlayer);
                GlobalEvents.Instance.EventTeleport.Invoke();
            }
        }

        private void TeleportPlayer()
        {
            if (NextRoomDoor && NextRoomDoor.In && Room.RoomManager && NextRoomDoor.Room)
            {
                PlayerController.Instance.transform.position = NextRoomDoor.In.transform.position;
                Room.RoomManager.ChangeRoom(NextRoomDoor.Room);
                return;
            }
            Debug.LogWarning("Door not assigned!");
        }
    }
}
