using UnityEngine;

namespace Scripts
{
    [CreateAssetMenu(fileName = "PlayerValues", menuName = "ValueObjects/PlayerValues")]
    public class PlayerValues : ScriptableObject
    {
        /// <summary>
        /// Variable responsible for the flight speed
        /// </summary>
        /// <value> Default value of 20.0f </value>
        [SerializeField] private float _flightSpeed = 20.0f;
        
        /// <summary>
        /// Variable responsible for the rotational speed when input is given
        /// </summary>
        /// <value> Default value of 5.0f </value>
        [SerializeField] private float _rotateSpeed = 5.0f;
        
        /// <summary>
        /// Variable responsible for the rotation speed of the player model
        /// </summary>
        /// <value> Default value of 10.0f </value>
        [SerializeField] private float _modelRotationSpeed = 10.0f;

        /// <summary>
        /// Variable responsible for the walking speed
        /// </summary>
        /// <value> Default value of 10.0f </value>
        [SerializeField] private float _walkSpeed = 10.0f;

        /// <summary>
        /// Property to get the flight speed value
        /// </summary>
        /// <value> Private variable value </value>
        public float FlightSpeed { get => _flightSpeed; }
        
        /// <summary>
        /// Property to get the rotational speed value
        /// </summary>
        /// <value> Private variable value </value>
        public float RotateSpeed { get => _rotateSpeed; }
        
        /// <summary>
        /// Property to get the model rotational speed
        /// </summary>
        /// <value> Private variable value </value>
        public float ModelRotationSpeed { get => _modelRotationSpeed; }
        
        /// <summary>
        /// Property to get the walking speed value
        /// </summary>
        /// <value> Private variable value </value>
        public float WalkSpeed { get => _walkSpeed; }
    }
}