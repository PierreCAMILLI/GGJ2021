using UnityEngine;

public class Door : MonoBehaviour
{
    public RoomManager RoomManager;

    public Room Room;

    public Door NextRoomDoor;

    public GameObject In;

    public void OnTriggerEnter2D(Collider2D other)
    {
        RoomManager.ChangeRoom(NextRoomDoor.Room);
        other.transform.position = NextRoomDoor.In.transform.position;
    }
}
