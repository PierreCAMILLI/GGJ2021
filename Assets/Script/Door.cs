using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private RoomManager RoomManager;

    [SerializeField] private Room Room;

    [SerializeField] private Door NextRoomDoor;

    [SerializeField] private GameObject In;

    private void OnTriggerEnter2D(Collider2D other)
    {
        RoomManager.ChangeRoom(NextRoomDoor.Room);
        other.transform.position = NextRoomDoor.In.transform.position;
    }
}
