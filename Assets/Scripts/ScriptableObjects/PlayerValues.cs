using UnityEngine;

namespace Scripts
{
    [CreateAssetMenu(fileName = "PlayerValues", menuName = "ValueObjects/PlayerValues")]
    public class PlayerValues : ScriptableObject
    {
        [SerializeField] private float _flightSpeed = 20.0f;
        [SerializeField] private float _rotateSpeed = 5.0f;
        [SerializeField] private float _modelRotationSpeed = 10.0f;
        [SerializeField] private float _walkSpeed = 10.0f;

        public float FlightSpeed { get => _flightSpeed; }
        public float RotateSpeed { get => _rotateSpeed; }
        public float ModelRotationSpeed { get => _modelRotationSpeed; }
        public float WalkSpeed { get => _walkSpeed; }
    }
}