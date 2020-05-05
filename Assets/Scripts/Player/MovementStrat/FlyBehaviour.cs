using UnityEngine;

namespace Scripts
{
    public class FlyBehaviour : MovementStrategy
    {
        public override void Movement(Player player)
        {
            player.Rb.MovePosition(player.transform.position + player.transform.forward * Time.deltaTime);
        }

        private void AlwaysForward()
        {
            //* Mexo com um vector constaste * velocidade
        }

        private void RotateToInput(Player player)
        {
            //* Rotate player object towards input
        }
    }
}