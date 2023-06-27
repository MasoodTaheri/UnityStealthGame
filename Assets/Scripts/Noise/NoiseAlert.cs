using Assets.Scripts.EnemyCode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Noise
{
    public class NoiseAlert : NoiseGenerator
    {


        public GameObject AlertObject;
        public float AlertTime;
        public float AlertDuration;
        public bool Alert;


        //public LayerMask DetectableMask;
        [SerializeField] private float _speed;

        //// Start is called before the first frame update
        //void Start()
        //{

        //}

        // Update is called once per frame
        void Update()
        {
            if (Alert)
            {
                if (AlertTime > AlertDuration)
                {
                    Alert = false;
                    AlertObject.transform.localScale = Vector3.zero;
                }
                AlertObject.transform.localScale += Vector3.one * Time.deltaTime * _speed;
                if (AlertObject.transform.localScale.x > 4)
                    AlertObject.transform.localScale = Vector3.zero;
                AlertTime += Time.deltaTime;
            }


            foreach (Enemy enemy in Enemes)
            {
                Ray ray = new Ray(transform.position, enemy.transform.position - transform.position);
                Debug.DrawRay(ray.origin, ray.direction * AlertRadius);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            //Debug.Log("noise alert OnTriggerEnter");
            AlertTime = 0;
            //foreach (Enemy enemy in Enemes)
            //{
            //    //Debug.Log("noise alert enemy" + enemy.gameObject.name);
            //    Ray ray = new Ray(transform.position, enemy.transform.position - transform.position);

            //    if (Physics.Raycast(ray, out RaycastHit hit, AlertRadius))
            //    {
            //        //Debug.Log(hit.collider.gameObject.name, hit.collider.gameObject);
            //        if (hit.collider.gameObject.CompareTag("Enemy"))
            //        {
            //            //Debug.Log("noise raycast hit to the Enemy");
            //            enemy.controller.TransitionTo(enemy.controller.NoiseAlertState);
            //            enemy.SetAlertPosition(transform.position);
            //        }
            //        //else
            //        //Debug.Log("noise raycast hit noting");
            //    }

            //}

            MakeNoise();
            Alert = true;






        }
    }
}