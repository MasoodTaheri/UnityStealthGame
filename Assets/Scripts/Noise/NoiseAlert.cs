using Assets.Scripts.EnemyCode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Noise
{
    public class NoiseAlert : NoiseGenerator
    {

        [SerializeField] private GameObject _alertObject;
        [SerializeField] private float _alertDuration;
        [SerializeField] private float _growUpAlertSpeed;

         private float _alertTime;
         private bool _alert;



        void Update()
        {
            if (_alert)
            {
                if (_alertTime > _alertDuration)
                {
                    _alert = false;
                    _alertObject.transform.localScale = Vector3.zero;
                }
                _alertObject.transform.localScale += Vector3.one * Time.deltaTime * _growUpAlertSpeed;
                if (_alertObject.transform.localScale.x > 4)
                    _alertObject.transform.localScale = Vector3.zero;
                _alertTime += Time.deltaTime;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            _alertTime = 0;
            MakeNoise();
            _alert = true;
        }
    }
}