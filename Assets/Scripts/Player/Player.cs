using UnityEngine;

namespace Scripts
{
    public class Player : MonoBehaviour
    {
        //* Class variables
        private Rigidbody _rb = default;

        //* Movement Strategy variables
        private MovementStrategy _currMovement = default;
        private FlyBehaviour _flightMovement = default;

        //* Input system variables
        private PlayerController _playerController = default;

        //* Class properties
        public Rigidbody Rb { get => _rb; }

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.isKinematic = true;

            _flightMovement = new FlyBehaviour();

            _currMovement = _flightMovement;

        }

        /// <summary>
        /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
        /// </summary>
        private void FixedUpdate()
        {
            _currMovement.Movement(this);
        }
    }
}
