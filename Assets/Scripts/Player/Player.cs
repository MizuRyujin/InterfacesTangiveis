using System;
using UnityEngine;

namespace Scripts
{
    public class Player : MonoBehaviour
    {
        //* DEV VARIABLES
        /// <summary>
        /// Variable to enable dev tools
        /// </summary>
        [SerializeField] private bool _devMode = default;

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
        /// Reference to to stamina script
        /// </summary>
        private Stamina _staminaScript;

        /// <summary>
        /// Variable to store the current movement behaviour being used
        /// </summary>
        private MovementStrategy _currMovement;

        /// <summary>
        /// Reference to the flight movement strategy behaviour
        /// </summary>
        private FlyBehaviour _flightMovement;

        /// <summary>
        /// Reference to the walk movement strategy behaviour
        /// </summary>
        private WalkingBehaviour _walkMovement;

        /// <summary>
        /// Reference to the model game object
        /// </summary>
        private Transform _model;

        //* Input system variables
        /// <summary>
        /// Reference to the Unity's new input system script
        /// </summary>
        private PlayerController _playerController;

        /// <summary>
        /// Vector to store input system movement input
        /// </summary>
        private Vector2 _movementInput;

        /// <summary>
        /// Variable to check if player is flying or not
        /// </summary>
        private bool _flying;

        private Animator _animator;


        //* Class properties
        /// <summary>
        /// Property that has the reference to the players rigidbody
        /// </summary>
        /// <value> Private variable value </value>
        public Rigidbody Rb => _rb;

        /// <summary>
        /// Reference to the stamina script
        /// </summary>
        public Stamina StaminaScript => _staminaScript;

        /// <summary>
        /// Property that has the reference to the player values scriptable object
        /// </summary>
        /// <value> Private variable value </value>
        public PlayerValues Values => _values;

        /// <summary>
        /// Property to get the the player input value
        /// </summary>
        /// <value> Private variable value </value>
        public Vector2 MovementInput => _movementInput;

        /// <summary>
        /// Property to get the player model transform
        /// </summary>
        /// <value> Private variable value </value>
        public Transform Model => _model;
        /// <summary>
        /// Property to get the _flying bool value
        /// </summary>
        public bool Flying => _flying;

        /// <summary>
        /// Action type delegate to do stuff
        /// </summary>
        public Action Action;

        /// <summary>
        /// Property to have the value of the bool and inform other scripts if
        /// dev tools are to be used
        /// </summary>
        public bool DevMode => _devMode;

        public Vector3 MaxHeight => new Vector3(transform.position.x,
                                                650.0f,
                                                transform.position.z);


        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();

            _staminaScript = GetComponent<Stamina>();

            _flightMovement = new FlyBehaviour();
            _walkMovement = new WalkingBehaviour();
            _currMovement = _flightMovement;
            _flying = true;

            _model = transform.GetChild(0);

            Action += ChangeMovement;

            _playerController = new PlayerController();
            _playerController.FlightActions.MovementControl.performed += ctx => _movementInput = ctx.ReadValue<Vector2>();
            _playerController.FlightActions.LiftOff.performed += ctx => ChangeMovement();
            // _playerController.UI.Navigate.performed += ctx => _movementInput = ctx.ReadValue<Vector2>();S

        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {
            // transform.position = transform.position.y > MaxHeight.y ? MaxHeight : transform.position;
            // transform.rotation = transform.position.y > MaxHeight.y - 10f ? Quaternion.identity : transform.rotation;
        }

        /// <summary>
        /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
        /// </summary>
        private void FixedUpdate()
        {
            _currMovement.Movement(this);
            CheckCollisionGround();
        }

        /// <summary>
        /// Method to change the current movement
        /// </summary>
        private void ChangeMovement()
        {
            Vector3 auxRotation;
            _flying = !_flying;

            if (_flying)
            {
                _animator.SetTrigger("Fly");
                auxRotation = _currMovement.Rotation;
                auxRotation.x = -20.0f;
                _currMovement = _flightMovement;
                _currMovement.Rotation = auxRotation;
                _rb.useGravity = false;
            }
            else
            {
                _animator.SetTrigger("Idle");
                auxRotation = _currMovement.Rotation;
                auxRotation.x = 0.0f;
                _currMovement = _walkMovement;
                _model.localRotation = Quaternion.identity;
                _currMovement.Rotation = auxRotation;
                _rb.useGravity = true;
            }
        }

        /// <summary>
        /// Method to check if the player collided with the ground to change
        /// movement type
        /// </summary>
        private void CheckCollisionGround()
        {
            if (_flying)
            {
                if (Physics.Raycast(transform.position,
                        transform.forward, 4f, LayerMask.GetMask("Ground")))
                {
                    ChangeMovement();
                }
            }
        }

        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            _playerController.Enable();
        }

        /// <summary>
        /// This function is called when the behaviour becomes disabled or inactive.
        /// </summary>
        private void OnDisable()
        {
            _playerController.Disable();
        }

        /// <summary>
        /// Callback to draw gizmos that are pickable and always drawn.
        /// </summary>
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward);
        }
    }
}
