using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.HomeworkScripts 
{ 
    public enum EnemyType
    {
        //Enemy types
        Infantry,
        Armoured,
        Avia        
    }

    // Enemy data
    [CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
    public class EnemyData : ScriptableObject
    {
        public GameObject Prefab;
        public EnemyType Type;
        public float MoveSpeed;
        public float Health;
    }
}