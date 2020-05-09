using UnityEngine;

namespace Scripts
{
    public class Player : MonoBehaviour
    {
        //* Class variables
        /// <summary>
        /// Reference to player values scriptable object
        /// </summary>
        [SerializeField] private PlayerValues _values = default;
        
        /// <summary>
        /// Reference to player game object Rigidbody reference
        /// </summary>
        private Rigidbody _rb = default;

        //* Movement Strategy variables
        /// <summary>
        /// Variable to store the current movement behaviour being used
        /// </summary>
        private MovementStrategy _currMovement = default;

        /// <summary>
        /// Reference to the flight movement strategy behaviour
        /// </summary>
        private FlyBehaviour _flightMovement = default;
        
        /// <summary>
        /// Reference to the model game object
        /// </summary>
        private Transform _model = default;

        //* Input system variables
        /// <summary>
        /// Reference to the Unity's new input system script
        /// </summary>
        private PlayerController _playerController = default;

        /// <summary>
        /// Vector to store input system movement input
        /// </summary>
        private Vector2 _movementInput = default;

        //* Class properties
        public Rigidbody Rb { get => _rb; }
        public PlayerValues Values { get => _values; }
        public Vector2 MovementInput { get => _movementInput; }
        public Transform Model { get => _model; }

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            //_rb.isKinematic = true;

            _flightMovement = new FlyBehaviour();
            _currMovement = _flightMovement;
            _model = transform.GetChild(0);

            _playerController = new PlayerController();
            _playerController.FlightActions.MovementControl.performed += ctx => _movementInput = ctx.ReadValue<Vector2>();

        }

        /// <summary>
        /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
        /// </summary>
        private void FixedUpdate()
        {
            _currMovement.Movement(this);
        }

        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            _playerController.FlightActions.MovementControl.Enable();

            _playerController.Enable();
        }

        /// <summary>
        /// This function is called when the behaviour becomes disabled or inactive.
        /// </summary>
        private void OnDisable()
        {
            _playerController.FlightActions.MovementControl.Enable();

            _playerController.Disable();
        }
    }
}
