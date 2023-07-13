using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolObject : MonoBehaviour
{
    //Объект для помещения в PoolObject 
    [SerializeField] GameObject prefab;
    public int poolSize = 10;
    List<GameObject> objectPool;

    // Start is called before the first frame update
    void Start()
    {
        CreatObjectPooll();
    }

    private void CreatObjectPooll()
    {
        objectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            // Создаем новый экземпляр объекта из префаба
            GameObject obj = Instantiate(prefab);
            obj.name = prefab.name+i;
            obj.transform.SetParent(this.transform);
            obj.SetActive(false);

            // Добавляем объект в пул
            objectPool.Add(obj);
        }
    }

   public GameObject GetObjectFromPool()
    {
        // Ищем неактивный объект в пуле и возвращаем его
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // Если все объекты в пуле заняты, создаем новый экземпляр объекта и добавляем его в пул
        GameObject newObj = Instantiate(prefab);
        newObj.name = "new " + prefab.name; 
        newObj.transform.SetParent(this.transform);
        objectPool.Add(newObj);
        return newObj;
    }
}
