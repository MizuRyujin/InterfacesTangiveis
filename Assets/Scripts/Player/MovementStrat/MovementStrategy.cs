using UnityEngine;

namespace Scripts
{
    /// <summary>
    /// Class responsible for movement strategies
    /// </summary>
    public abstract class MovementStrategy
    {
        /// <summary>
        /// Variable to store movement direction vector
        /// </summary>
        protected Vector3 _movement = default;

        /// <summary>
        /// Variable to check if player is flying or not
        /// </summary>
        protected bool isFlying = default;

        /// <summary>
        /// Property to check if player is flying or not
        /// </summary>
        /// <value></value>
        public bool IsFlying { get => isFlying; }

        /// <summary>
        /// Abstract movement method, to be called in fixed update, uses Rigidbody
        /// </summary>
        /// <param name="player"> Reference to player script </param>
        public abstract void Movement(Player player);

        /// <summary>
        /// Abstract method to rotate player game object towards input, uses Rigidbody
        /// </summary>
        /// <param name="player"> Reference to player script </param>
        public abstract void RotateToInput(Player player);
    }
}