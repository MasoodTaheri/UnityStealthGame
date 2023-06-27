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

        public SpawnPointController spawnPointController;
        public List<NoiseAlert> NoiseAlert;
        public List<PathController> PathControllers;
        private List<Enemy> EnemyList = new List<Enemy>();
        private playerController Player;





        void Start()
        {

            Player = Instantiate(PlayerControllerPrefab, spawnPointController.GetSpawnPoint().position, Quaternion.identity);
            var enemy = Instantiate(EnemyPrefab, spawnPointController.GetSpawnPoint().position, Quaternion.identity);
            enemy.PlayerTransform = Player.transform;
            enemy.SetPathController(PathControllers[Random.Range(0, PathControllers.Count)]);
            EnemyList.Add(enemy);

            foreach (var enemyItem in EnemyList)
            {
                Player.NoiseGenerator.Enemes.Add(enemyItem);
            }


            foreach (var item in NoiseAlert)
            {
                foreach (var enemyItem in EnemyList)
                {
                    item.Enemes.Add(enemyItem);
                }
            }

        }
    }
}