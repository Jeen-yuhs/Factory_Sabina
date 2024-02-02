using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.HomeworkScripts
{
    public class EnemyArmoured : Enemy
    {
        public override void Move(Vector3 targetPosition)
        {
            _agent.Move(targetPosition);
            Debug.Log("EnemyArmoured Move"); // replace           
        }
    }
}
