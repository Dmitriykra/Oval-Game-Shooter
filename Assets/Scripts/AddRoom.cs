using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    [SerializeField] GameObject removeRoom;
    [SerializeField] RoomsController roomsController;
    [SerializeField] public bool isMoveForward;
    void EnableRemoveRoom()
    {
        removeRoom.GetComponent<BoxCollider>().enabled = true;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && roomsController != null)
        {
            if(!isMoveForward)
            {
                roomsController.AddNewRoom(1);
                EnableRemoveRoom();
                
            }
            else
            {
                EnableRemoveRoom();
                roomsController.RestartRooms(true, false);
            }
            isMoveForward = true;
        }
    }
}
