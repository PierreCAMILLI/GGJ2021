using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private RoomManager RoomManager;

    [SerializeField] private Room Room;

    [SerializeField] private Door NextRoomDoor;

    [SerializeField] private GameObject In;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // todo: Remove this when trigger only targets the player
        if (true)
        {
            Debug.Log("Remove this when trigger only targets the player");
            return;
        }

        RoomManager.ChangeRoom(NextRoomDoor.Room);
        other.transform.position = NextRoomDoor.In.transform.position;
    }
}