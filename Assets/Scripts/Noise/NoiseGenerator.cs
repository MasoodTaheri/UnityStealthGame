using Assets.Scripts.EnemyCode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Noise
{
    public class NoiseGenerator : MonoBehaviour
    {
        [SerializeField] private float AlertRadius;
        [HideInInspector] public List<Enemy> Enemes;

        public void MakeNoise()
        {
            FindEnemyToNotifyAlert();
        }

        public void FindEnemyToNotifyAlert()
        {
            foreach (Enemy enemy in Enemes)
            {
                Ray ray = new Ray(transform.position, enemy.transform.position - transform.position);

                if (Physics.Raycast(ray, out RaycastHit hit, AlertRadius))
                {
                    if (hit.collider.gameObject.CompareTag("Enemy"))
                    {
                        enemy.StateController.TransitionTo(enemy.StateController.NoiseAlertState);
                        enemy.SetAlertPosition(transform.position);
                    }
                }

            }
        }
    }
}