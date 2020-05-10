using UnityEngine;

namespace Scripts
{
    /// <summary>
    /// Class responsible for the flight behaviour
    /// </summary>
    public class FlyBehaviour : MovementStrategy
    {
        /// <summary>
        /// Override method for the flight movement
        /// </summary>
        /// <param name="player"> Reference to the player script </param>
        public override void Movement(Player player)
        {
            AlwaysForward(player);
            RotateToInput(player);
            RotateModel(player);

            Debug.Log(_movement);
        }

        /// <summary>
        /// Override method for the rotation towards player input
        /// </summary>
        /// <param name="player"> Reference to the player script </param>
        public override void RotateToInput(Player player)
        {
            if (player.MovementInput != Vector2.zero)
            {
                _movement += new Vector3(
                    player.MovementInput.y, player.MovementInput.x, 0.0f) *
                    player.Values.RotateSpeed * Time.deltaTime;

                if (!player.DevMode)
                {
                    _movement.x = Mathf.Clamp(_movement.x, -60, 60);
                }
            }

            player.Rb.MoveRotation(Quaternion.Euler(_movement));
        }

        /// <summary>
        /// Method to make the player always move forward towards it's own z
        /// </summary>
        /// <param name="player"> Reference to the player script </param>
        private void AlwaysForward(Player player)
        {
            //* Even though move position says that moves the kinematic body,
            //* RB isn't kinematic
            player.Rb.MovePosition(
                player.transform.position + player.transform.forward *
                player.Values.FlightSpeed * Time.deltaTime);
        }

        /// <summary>
        /// Method to rotate the player's model to the direction it is moving 
        /// </summary>
        /// <param name="player"> Reference to the player script </param>
        private void RotateModel(Player player)
        {
            if (player.MovementInput != Vector2.zero)
            {
                if (player.MovementInput.x < 0.0f)
                {
                    ModelRotAnim(player, 0.0f, 60.0f);
                }
                if (player.MovementInput.x > 0.0f)
                {
                    ModelRotAnim(player, 0.0f, -60.0f);
                }
            }
            if (player.MovementInput != Vector2.zero && (_movement.x != -60.0f && _movement.x != 60.0f))
            {
                if (player.MovementInput.y > 0.0f)
                {
                    ModelRotAnim(player, 35f);
                }
                if (player.MovementInput.y < 0.0f)
                {
                    ModelRotAnim(player, -35f);
                }
            }
            else
            {
                ResetQuaternion(player);
            }
        }

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
        private void ModelRotAnim(Player player, float xValue = 0.0f, float zValue = 0.0f)
        {
            player.Model.localRotation = Quaternion.Slerp(
                    player.Model.localRotation,
                    Quaternion.Euler(xValue, 0.0f, zValue),
                    (player.Values.ModelRotationSpeed) * Time.deltaTime);
        }

        /// <summary>
        /// Method to reset the rotation of an object
        /// </summary>
        /// <param name="player"> Reference to player script </param>
        private void ResetQuaternion(Player player)
        {
            player.Model.localRotation = Quaternion.Slerp(
                player.Model.localRotation,
                Quaternion.identity,
                (player.Values.ModelRotationSpeed) * Time.deltaTime);
        }
    }
}