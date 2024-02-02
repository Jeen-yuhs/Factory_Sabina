using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Assets.Scripts.HomeworkScripts 
{ 
    public abstract class Enemy : MonoBehaviour, IEnemy
    {
        public event Action<float> OnEnemyKilled; // alerts subscribers 

        [SerializeField] protected EnemyData data;
        [SerializeField] protected NavMeshAgent _agent;
        [SerializeField] private Transform _moveTarget;
        [SerializeField] private Image _healthBar; 
        [SerializeField] private float _health;

        /// <summary>
        /// Configure enemy by data
        /// </summary>
        /// <param name="data"></param>
        public virtual void Configure(EnemyData data)
        {
            this.data = data;
        }

        public abstract void Move(Vector3 targetPosition);
        

        private float _maxHealth;

        public float WaveCost { get; internal set; }

        private void OnEnable()
        { 
            _maxHealth = _health;
        }

        public void SetDestination(Vector3 targetPosition)
        {
            _agent.SetDestination(targetPosition);
        }

        public void TakeDamage(float dmg)
        {
            _health -= dmg;

            _healthBar.fillAmount = _health / _maxHealth;

            if (_health <= 0)
            {
                gameObject.SetActive(false);
                OnEnemyKilled?.Invoke(WaveCost);
            }
        }

        private void Update()
        {
            Vector3 dir = Camera.main.transform.position - _healthBar.GetComponentInParent<Canvas>().transform.position;
            dir.x = 0;
            dir.y = 0;
            dir.z = 0;
            //_healthBar.GetComponentInParent<Canvas>().transform.rotation = Quaternion.LookRotation(dir);
        }
    }

    //public interface IEnemy
   // {
    //    void TakeDamage(float dmg);
   // }
}