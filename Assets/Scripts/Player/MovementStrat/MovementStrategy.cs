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
        /// Abstract movement method, to be called in fixed update, uses Rigidbody
        /// </summary>
        /// <param name="player"> Reference to player script </param>
        public abstract void Movement(Player player);

        /// <summary>
        /// Abstract method to rotate player game object towards input, uses Rigidbody
        /// </summary>
        /// <param name="player"> Reference to player script </param>
        public abstract void RotateToInput(Player player);

        /// <summary>
        /// Method that does a smooth rotation of an object using a quaternion
        /// </summary>
        /// <param name="player">
        /// Reference to the player script
        /// </param>
        /// <param name="xValue">
        /// Vector x value to be used in a euler quaternion 
        /// </param>
        /// <param name="zValue">
        /// Vector z value to be used in a euler quaternion
        /// </param>
        public virtual void ModelRotAnim(Player player,
            float xValue = 0.0f, float yValue = 0.0f, float zValue = 0.0f)
        {
            player.Model.localRotation = Quaternion.Slerp(
                    player.Model.localRotation,
                    Quaternion.Euler(xValue, yValue, zValue),
                    (player.Values.ModelRotationSpeed) * Time.deltaTime);
        }

        /// <summary>
        /// Method to reset the rotation of an object
        /// </summary>
        /// <param name="player"> Reference to player script </param>
        public virtual void ResetQuaternion(Player player)
        {
            player.Model.localRotation = Quaternion.Slerp(
                player.Model.localRotation,
                Quaternion.identity,
                (player.Values.ModelRotationSpeed) * Time.deltaTime);
        }
    }
}