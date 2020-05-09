using UnityEngine;

namespace Scripts
{
    public class FlyBehaviour : MovementStrategy
    {
        public override void Movement(Player player)
        {
            AlwaysForward(player);
            RotateToInput(player);
        }

        private void AlwaysForward(Player player)
        {
            //* Mexo com um vector constaste * velocidade
            player.Rb.MovePosition(
                player.transform.position + player.transform.forward *
                player.Values.FlightSpeed * Time.deltaTime);

        }

        private void RotateToInput(Player player)
        {
            //! THIS TYPE OF ROTATION DOESN'T CONSIDER IF PLAYER IS LATERAL
            if (player.MovementInput != Vector2.zero)
            {
                _movement += new Vector3(
                    player.MovementInput.y, 0.0f, -player.MovementInput.x) *
                    player.Values.RotateSpeed * Time.deltaTime;
            }

            //* WITH THIS METHOD PLAYER WON'T STOP MOVING WHILE ROTATING, BUT IS BUGGY
            player.Rb.MoveRotation(Quaternion.Euler(_movement));
        }
    }
}