using UnityEngine;

namespace Scripts
{
    public class FlyBehaviour : MovementStrategy
    {
        public override void Movement(Player player)
        {
            AlwaysForward(player);
            RotateToInput(player);
            RotateModel(player);
        }

        public override void RotateToInput(Player player)
        {
            if (player.MovementInput != Vector2.zero)
            {
                _movement += new Vector3(
                    player.MovementInput.y, player.MovementInput.x, 0.0f) *
                    player.Values.RotateSpeed * Time.deltaTime;
            }

            //* WITH THIS METHOD PLAYER WON'T STOP MOVING WHILE ROTATING, BUT IS BUGGY
            player.Rb.MoveRotation(Quaternion.Euler(_movement));
        }

        private void AlwaysForward(Player player)
        {
            player.Rb.MovePosition(
                player.transform.position + player.transform.forward *
                player.Values.FlightSpeed * Time.deltaTime);
        }

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

        private void ModelRotAnim(Player player, float xValue = 0.0f, float zValue = 0.0f)
        {
            player.Model.localRotation = Quaternion.Slerp(
                    player.Model.localRotation,
                    Quaternion.Euler(xValue, 0.0f, zValue),
                    (player.Values.ModelRotationSpeed) * Time.deltaTime);
        }

        private void ResetQuaternion(Player player)
        {
            player.Model.localRotation = Quaternion.Slerp(
                player.Model.localRotation,
                Quaternion.identity,
                (player.Values.ModelRotationSpeed) * Time.deltaTime);
        }
    }
}