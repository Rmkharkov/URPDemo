using UnityEngine;

namespace Movement
{
    public class BaseMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody body;
        private MovementConfig UsedMovementConfig => MovementConfig.Instance;

        protected void StrafeRight(float factor)
        {
            body.AddForce(Vector3.right*UsedMovementConfig.MoveForces.x);
            LimitSpeed();
        }
        
        protected void StrafeLeft(float factor)
        {
            body.AddForce(Vector3.left*UsedMovementConfig.MoveForces.x);
            LimitSpeed();
        }

        protected void Forward(float factor)
        {
            body.AddForce(Vector3.forward*UsedMovementConfig.MoveForces.x);
            LimitSpeed();
        }
        
        protected void Backward(float factor)
        {
            body.AddForce(Vector3.back*UsedMovementConfig.MoveForces.x);
            LimitSpeed();
        }

        protected void Stop()
        {
            body.velocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
        }

        private void LimitSpeed()
        {
            var limitedVelocity =
                new Vector3(
                    Mathf.Clamp(body.velocity.x, -UsedMovementConfig.MaximumSpeed, UsedMovementConfig.MaximumSpeed),
                    body.velocity.y,
                    Mathf.Clamp(body.velocity.z, -UsedMovementConfig.MaximumSpeed, UsedMovementConfig.MaximumSpeed));
            body.velocity = limitedVelocity;
        }
    }
}