using UnityEngine;

namespace Scripts
{
    /// <summary>
    /// Class responsible
    /// </summary>
    public abstract class MovementStrategy
    {
        /// <summary>
        /// Variable to store movement direction vector
        /// </summary>
        protected Vector3 _movement = default;
        protected bool isFlying = default;

        public bool IsFlying { get => isFlying; }

        /// <summary>
        /// Abstract movement method, to be called in fixed update, uses Rigidbody
        /// </summary>
        /// <param name="player"> Reference to player script </param>
        public abstract void Movement(Player player);
    }
}