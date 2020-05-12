using UnityEngine;

namespace Scripts
{
    public class Player : MonoBehaviour
    {
        //* DEV VARIABLES
        [SerializeField] private bool _devMode = default;
        //*

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
        /// Reference to the walk movement strategy behaviour
        /// </summary>
        private WalkingBehaviour _walkMovement = default;

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

        /// <summary>
        /// Variable to check if player is flying or not
        /// </summary>
        private bool _flying = default;

        //* Class properties
        /// <summary>
        /// Property that has the reference to the players rigidbody
        /// </summary>
        /// <value> Private variable value </value>
        public Rigidbody Rb { get => _rb; }

        /// <summary>
        /// Property that has the reference to the player values scriptable object
        /// </summary>
        /// <value> Private variable value </value>
        public PlayerValues Values { get => _values; }

        /// <summary>
        /// Property to get the the player input value
        /// </summary>
        /// <value> Private variable value </value>
        public Vector2 MovementInput { get => _movementInput; }

        /// <summary>
        /// Property to get the player model transform
        /// </summary>
        /// <value> Private variable value </value>
        public Transform Model { get => _model; }

        public bool DevMode { get => _devMode; }


        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();

            _flightMovement = new FlyBehaviour();
            _walkMovement = new WalkingBehaviour();
            _currMovement = _flightMovement;
            _flying = true;

            _model = transform.GetChild(0);

            _playerController = new PlayerController();
            _playerController.FlightActions.MovementControl.performed += ctx => _movementInput = ctx.ReadValue<Vector2>();
            _playerController.FlightActions.LiftOff.performed += ctx => ChangeMovement();

        }

        /// <summary>
        /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
        /// </summary>
        private void FixedUpdate()
        {
            _currMovement.Movement(this);
        }

        private void ChangeMovement()
        {
            Vector3 auxRotation;
            _flying = !_flying;

            if (_flying)
            {
                auxRotation = _currMovement.Rotation;
                auxRotation.x = -20.0f;
                _currMovement = _flightMovement;
                _currMovement.Rotation = auxRotation;
                _rb.useGravity = false;
            }
            else
            {
                auxRotation = _currMovement.Rotation;
                auxRotation.x = 0.0f;
                _currMovement = _walkMovement;
                _model.localRotation = Quaternion.identity;
                _currMovement.Rotation = auxRotation;
                _rb.useGravity = true;
            }
        }

        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            _playerController.FlightActions.MovementControl.Enable();
            _playerController.FlightActions.LiftOff.Enable();

            _playerController.Enable();
        }

        /// <summary>
        /// This function is called when the behaviour becomes disabled or inactive.
        /// </summary>
        private void OnDisable()
        {
            _playerController.FlightActions.MovementControl.Enable();
            _playerController.FlightActions.LiftOff.Enable();

            _playerController.Disable();
        }
    }
}
