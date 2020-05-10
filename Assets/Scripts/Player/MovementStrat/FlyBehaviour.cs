using UnityEngine;

namespace Scripts
{
    /// <summary>
    /// Class responsible for the flight behaviour
    /// </summary>
    public class FlyBehaviour : MovementStrategy
    {
        private bool _turning;

        /// <summary>
        /// Override method for the flight movement
        /// </summary>
        /// <param name="player"> Reference to the player script </param>
        public override void Movement(Player player)
        {
            AlwaysForward(player);
            RotateToInput(player);
            RotateModel(player);
        }

        /// <summary>
        /// Override method for the rotation towards player input
        /// </summary>
        /// <param name="player"> Reference to the player script </param>
        public override void RotateToInput(Player player)
        {
            if (player.MovementInput != Vector2.zero)
            {
                if (player.MovementInput.x != 0.0f)
                {
                    _turning = true;
                }
                else
                {
                    _turning = false;
                }

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
            float speed;

            if (_turning)
            {
                speed = player.Values.FlightSpeed * 0.5f;    
            }
            else
            {
                speed = player.Values.FlightSpeed;
            }

            //* Even though move position says that moves the kinematic body,
            //* RB isn't kinematic
            player.Rb.MovePosition(
                player.transform.position + player.transform.forward *
                speed * Time.deltaTime);

            Debug.Log(speed);
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
                    ModelRotAnim(player, 0.0f, 0.0f, 60.0f);
                }
                if (player.MovementInput.x > 0.0f)
                {
                    ModelRotAnim(player, 0.0f, 0.0f, -60.0f);
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
    }
}