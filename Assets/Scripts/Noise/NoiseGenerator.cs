using Assets.Scripts.EnemyCode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Noise
{
    public class NoiseGenerator : MonoBehaviour
    {
        public float AlertRadius;
        public List<Enemy> Enemes;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void MakeNoise()
        {
            FindEnemyToNotifyAlert();
        }

        public void FindEnemyToNotifyAlert()
        {
            foreach (Enemy enemy in Enemes)
            {
                //Debug.Log("noise alert enemy" + enemy.gameObject.name);
                Ray ray = new Ray(transform.position, enemy.transform.position - transform.position);

                if (Physics.Raycast(ray, out RaycastHit hit, AlertRadius))
                {
                    //Debug.Log(hit.collider.gameObject.name, hit.collider.gameObject);
                    if (hit.collider.gameObject.CompareTag("Enemy"))
                    {
                        //Debug.Log("noise raycast hit to the Enemy");
                        enemy.controller.TransitionTo(enemy.controller.NoiseAlertState);
                        enemy.SetAlertPosition(transform.position);
                    }
                    //else
                    //Debug.Log("noise raycast hit noting");
                }

            }
        }
    }
}