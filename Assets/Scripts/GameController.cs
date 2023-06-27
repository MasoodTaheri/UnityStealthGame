using Assets.Scripts.EnemyCode;
using Assets.Scripts.Noise;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        public playerController PlayerControllerPrefab;
        public GuardEnemy EnemyPrefab;
        public SpawnPointController SpawnPointController;
        public List<NoiseAlert> NoiseAlert;
        public List<PathController> PathControllers;

        private List<Enemy> _enemyList = new List<Enemy>();
        private playerController _player;


        void Start()
        {

            _player = Instantiate(PlayerControllerPrefab, SpawnPointController.GetSpawnPoint().position, Quaternion.identity);

            var enemy = Instantiate(EnemyPrefab, SpawnPointController.GetSpawnPoint().position, Quaternion.identity);
            enemy.Setup(_player.transform, PathControllers[Random.Range(0, PathControllers.Count)]);
            _enemyList.Add(enemy);

            _player.NoiseGenerator.Enemes = new List<Enemy>(_enemyList);

            foreach (var item in NoiseAlert)
            {
                item.Enemes = new List<Enemy>(_enemyList);
            }

        }
    }
}