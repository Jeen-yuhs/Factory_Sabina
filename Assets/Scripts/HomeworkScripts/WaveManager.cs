using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.HomeworkScripts
{
    public class WaveManager : MonoBehaviour
    {
        //public event Action OnStartNewWawe;

        public static WaveManager Instance;

        [SerializeField] private List<WaveSettings> waveSettings = new List<WaveSettings>();

       // [SerializeField] private EnemySpawner _fabric; //scriptable object - Enemy data
       // [SerializeField] private int _waweIndex;
       // [SerializeField] private int _enemyCount;
        [SerializeField] private Transform _destinationTarget;

        /// <summary>
        /// List of enemies
        /// </summary>
        public List<IEnemy> enemies = new List<IEnemy>();

        /// <summary>
        /// Wave settings
        /// </summary>
        [Serializable]
        public class WaveSettings
        {
            public int EnemyCount;
            public float WaveDelay;
            public float CostPerUnit;
            public EnemyData EnemyData;
        }

        private void Start()
        {
            CreateWave(waveSettings[1]);
        }

        /// <summary>
        /// Create wave of enemies
        /// </summary>
        /// <param name="waveData"></param>
        public void CreateWave(List<WaveSettings> waveSettings)
        {
            foreach (WaveSettings data in waveSettings)
            {
                for (int i = 0; i < data.EnemyCount; i++)
                {
                    IEnemy enemy = CreateEnemy(data.EnemyData);
                    enemy.Move(_destinationTarget.position);//you can add Vector3 enemy.Move(whereToMove);
                    enemies.Add(enemy);
                }
            }
        }

        /// <summary>
        /// Create one enemy
        /// </summary>
        /// <param name="waveData"></param>
        public void CreateWave(WaveSettings waveSettings)
        {
            for (int i = 0; i < waveSettings.EnemyCount; i++)
            {
                IEnemy enemy = CreateEnemy(waveSettings.EnemyData);
                enemy.Move(_destinationTarget.position);
               // enemy.OnEnemyKilled += OnEnemyKilled;
                enemies.Add(enemy);


                // enemy.WaveCost = wave.EnemyCost;
                //  enemy.SetDestination(_destinationTarget.position); // copy position
                //  enemy.OnEnemyKilled += OnEnemyKilled;
                //   EnemyList.Add(enemy);
                // yield return new WaitForSeconds(4f);
            }
        }

        /// <summary>
        /// Get enemy by factory type
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private IEnemy CreateEnemy(EnemyData data)
        {
            switch (data.Type)
            {
                case EnemyType.Infantry:
                    EnemyFactory<EnemyInfantry> InfantryFactory = new EnemyFactory<EnemyInfantry>();
                    return InfantryFactory.CreateEnemy(data);
                case EnemyType.Armoured:
                    EnemyFactory<EnemyArmoured> ArmouredFactory = new EnemyFactory<EnemyArmoured>();
                    return ArmouredFactory.CreateEnemy(data);
                case EnemyType.Avia:
                    EnemyFactory<EnemyAvia> AviaFactory = new EnemyFactory<EnemyAvia>();
                    return AviaFactory.CreateEnemy(data);
                default:
                    return null;
            }
        }


        //[SerializeField] private bool _started = false;

        // public List<Enemy> EnemyList = new List<Enemy>();

       // public int Wawe { get { return _waweIndex; } set { _waweIndex = value; } }

       // public event Action EnemyKilled; // Event called every time an enemy gets killed

       //  private void Awake()
       //  {
       //     if (Instance == null)
       //     {
       //          Instance = this;
       //     }
       //     else
       //     {
       //          Destroy(gameObject);
       //     }
       //  }

        //   private void OnEnable()
        //   {
        //        _gameMenager.OnGameStart += OnGameStart;
        //        OnStartNewWawe += EnemyManagerOnStartNewWawe;
        //    }

        //  private void OnDisable()
        //     {
        //        _gameMenager.OnGameStart -= OnGameStart;
        //        OnStartNewWawe -= EnemyManagerOnStartNewWawe;
        //    }

        //   private void OnGameStart()
        //   {
        //      StartCoroutine(CreateWawe(_enemyCount, _fabric.GetNextWave(0).WaveDeley));
        //   }

        //   private void EnemyManagerOnStartNewWawe()
        //   {
        //      _started = true;
        //      _waweIndex++;
        //     if (_waweIndex >= _fabric.Enemies.Count)
        //     {
        //         Debug.Log("Waves finished");
        //         return;
        //     }

        //     StartCoroutine(CreateWawe(_enemyCount, _fabric.GetNextWave(_waweIndex).WaveDeley));
        // }

        //  private void Update()
        //   {
        //      if (EnemyList.Count > 0 && EnemyList.All(x => x.gameObject.activeSelf == false) && !_started)
        //      {
        //          OnStartNewWawe?.Invoke();
        //     }
        // }

        //  public IEnumerator CreateWawe(int enemyCount, float waweDelay = 0)
        //  {
        //     Debug.Log(_waweIndex);
        //     yield return new WaitForSeconds(waweDelay);

        //     if (enemies.Count > 0)
        //     {
        //         foreach (Enemy enemy in enemies)
        //        {
        //             Destroy(enemy.gameObject);
        //        }
        //    }

        //   EnemyList = new List<Enemy>();
        //     var wave = _fabric.GetNextWave(_waweIndex);

        //    for (int i = 0; i < enemyCount; i++)
        //    {
        //       var enemy = Instantiate(wave.Enemy[UnityEngine.Random.Range(0, wave.Enemy.Length)]); // copy?
        //        enemy.WaveCost = wave.EnemyCost;
        //       enemy.SetDestination(_destinationTarget.position); // copy position
        //        enemy.OnEnemyKilled += OnEnemyKilled;
        //     EnemyList.Add(enemy);
        //     yield return new WaitForSeconds(4f);
        //     }

        //      _started = false;
        //   }

             private void OnEnemyKilled(float money)
             {
                _waveManager.PlayerMoney += money;
               _waveManager.UpdatePlayerMoney();
               EnemyKilled?.Invoke(); // Event gets invoked
             }
          
    }
}