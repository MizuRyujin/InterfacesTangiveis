using UnityEngine;

namespace Scripts
{
    public class WalkingBehaviour : MovementStrategy
    {
        public override void Movement(Player player)
        {
            WalkForward(player);
            RotateToInput(player);
        }

        public override void RotateToInput(Player player)
        {
            if (player.MovementInput != Vector2.zero)
            {
                _rotation.y += player.MovementInput.x *
                    player.Values.RotateSpeed * Time.deltaTime;
            }

            player.Rb.MoveRotation(Quaternion.Euler(_rotation));
        }

        private void WalkForward(Player player)
        {
            if (player.MovementInput != Vector2.zero)
            {
                _movement.z = player.MovementInput.y *
                    player.Values.WalkSpeed * Time.deltaTime;
            }
            else
            {
                _movement.z = 0.0f;
            }

            player.Rb.MovePosition(player.Rb.transform.position +
                player.Rb.transform.forward * _movement.z);
        }
    }
}