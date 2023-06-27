using Assets.Scripts.Noise;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class playerController : MonoBehaviour
    {
        public NoiseGenerator NoiseGenerator;

        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speed;
        [SerializeField] private float _Runspeed;

        private Vector3 movement;
        void Update()
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (Input.GetKey(KeyCode.LeftShift))//go faster but with Noise
            {
                movement = movement * _Runspeed * Time.deltaTime;
                NoiseGenerator.MakeNoise();
            }
            else
                movement = movement * _speed * Time.deltaTime;
            _characterController.Move(movement);
        }
    }
}