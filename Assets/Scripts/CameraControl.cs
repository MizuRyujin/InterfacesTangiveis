﻿using UnityEngine;

namespace Scripts
{
    public class CameraControl : MonoBehaviour
    {
        //* Class variables
        [SerializeField] private Transform _target = default;
        [SerializeField] private float _distanceToTarget = default;

        private void LateUpdate()
        {
            RotateWithPlayer();
            Vector3 desiredPos =_target.position - transform.forward * _distanceToTarget;
            transform.position = desiredPos;
        }

        private void RotateWithPlayer()
        {
            transform.rotation = _target.rotation;
        }
    }
}
