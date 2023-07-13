using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRoom : MonoBehaviour
{
    [SerializeField] GameObject addRoom;
    [SerializeField] RoomsController roomsController;
    [SerializeField] bool isMoveForward;
    void EnableAddRoom()
    {
        addRoom.GetComponent<BoxCollider>().enabled = true;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && roomsController != null)
        {
            if(!isMoveForward)
            {
                roomsController.DesableRoom(1);
                EnableAddRoom();
            }
            else
            {
                EnableAddRoom();
                roomsController.RestartRooms(false, true);
            }
            isMoveForward = true;
        }
    }
}
