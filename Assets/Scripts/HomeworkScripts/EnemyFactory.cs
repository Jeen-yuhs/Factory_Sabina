using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;


namespace Assets.Scripts.HomeworkScripts 
{  
    /// <summary>
    /// Generic factory for creating enemies
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EnemyFactory<T> where T: MonoBehaviour, IEnemy
    {
        
        public T CreateEnemy(EnemyData data)
        {        
            GameObject instance = GameObject.Instantiate(data.Prefab);  
            T enemy = instance.GetComponent<T>();
            enemy.Configure(data);
            return enemy;
        }        
    }
}