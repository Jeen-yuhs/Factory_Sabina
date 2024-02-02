using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.HomeworkScripts
{
    public class EnemyInfantry : Enemy
    {
        public override void Move(Vector3 targetPosition)
        {
            _agent.Move(targetPosition);
            Debug.Log("EnemyInfantry Move");         
        }
    }
}