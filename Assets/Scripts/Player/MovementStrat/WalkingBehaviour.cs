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
            throw new System.NotImplementedException();
        }

        private void WalkForward(Player player)
        {

        }
    }
}