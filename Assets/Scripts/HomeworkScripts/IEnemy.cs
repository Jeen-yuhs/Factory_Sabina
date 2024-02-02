using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.HomeworkScripts
{   
    public interface IEnemy
    {
        object gameObject { get; }

        /// <summary>
        /// Configure enemy by data
        /// </summary>
        /// <param name="data"></param>
        void Configure(EnemyData data);

        /// <summary>
        /// Move enemy
        /// </summary>
        void Move(Vector3 targetPosition);        
        void TakeDamage(float dmg);
       // void OnEnemyKilled();
    }
}
