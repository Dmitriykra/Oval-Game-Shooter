using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsController : MonoBehaviour
{
    [SerializeField] List<GameObject> rooms = new List<GameObject>();
    public int addRoomIndex;
    public int deleteRoomIndex;
    [SerializeField] EnemySpawner enemySpawner;
    int countAllActiveRooms;
    bool isFirstStart = true;
    int totalRooms;
    private void Start() 
    {
        //устанавливаем максимальный индекс
        totalRooms = rooms.Count-1;
        //на старте добавляю первую комнату к нулевой (всего на сцене получается две)ж
        AddNewRoom(1);
    }
    
    //метод добавляет комнаты
    public void AddNewRoom(int room)
    {
        //проверка на максимальное кол-во новых комнат чтобы не вылезти за пределы списка
        if(addRoomIndex < totalRooms)
        {
            addRoomIndex += room;
            rooms[addRoomIndex].SetActive(true);
        }
    }

    //метод убирает комнаты
    public void DesableRoom(int room)
    { 
        rooms[deleteRoomIndex].SetActive(false);
        deleteRoomIndex += room;
    }

    //метод переключает комнаты при перемещении вперед - назад
    public void RestartRooms(bool oldRoom, bool newRoom)
    {    
        //если возвращаемся назад     
        if(oldRoom)
        {
            //если кол-во удаленных комнат > 0
            if(deleteRoomIndex > 0) 

                //сначал уменьшем кол-во старых комнат
                deleteRoomIndex--;

                //и потом включаем оставшуюся старую комнату на сцене
                rooms[deleteRoomIndex].SetActive(oldRoom);

                //выключаем последнюю открытую новую комнату
                rooms[addRoomIndex].SetActive(newRoom);

                //после выключения новой комнаты, уменьшаем их кол-во на 1
                addRoomIndex--;
                
            //если осталось последняя старая комната с индексом 0
            if(deleteRoomIndex == 0)
            {
                //если получилось так что осталось 2 активные новые комнаты 
                if(deleteRoomIndex == 0 && rooms[2].activeInHierarchy)
                {
                    //то убираем последнюю новую комнату с индексом 2 (тогда на сцене будет 2 комнаты с индексом 0 и 1)
                    rooms[2].SetActive(false);
                    //и вычитаем ее индекс из общего кол-ва новых комнат
                    addRoomIndex--;
                }

                //в другом случае включаем BoxCollider и убираем isMoveForward для третьей комнаты с индексом 2
                rooms[2].GetComponentInChildren<BoxCollider>().enabled = true;
                rooms[2].GetComponentInChildren<AddRoom>().isMoveForward = false;
                
            }
        }
        else
        {
            //если идем в перет выключем старую комнату
            rooms[deleteRoomIndex].SetActive(oldRoom);

            //добавляем старую комнату в кол-во старых индексов
            deleteRoomIndex++;

            //добавляем новую комнату в новые индексы если єто еще можно сделать
            if(addRoomIndex < totalRooms) addRoomIndex++;

            //активируем комнату с новым индексом
            rooms[addRoomIndex].SetActive(newRoom);
        } 
    }
}
