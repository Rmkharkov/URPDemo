using UniRx;
using UnityEngine;

namespace Movement
{
    public class BaseMovementController : BaseController<BaseMovementModel>
    {
        private MovementConfig UsedMovementConfig => MovementConfig.Instance;
        private Rigidbody Body => Model.Body;

        public void StrafeRight(float factor)
        {
            Body.AddForce(Vector3.right*UsedMovementConfig.MoveForces.x);
            LimitSpeed();
        }
        
        public void StrafeLeft(float factor)
        {
            Body.AddForce(Vector3.left*UsedMovementConfig.MoveForces.x);
            LimitSpeed();
        }

        public void Forward(float factor)
        {
            Body.AddForce(Vector3.forward*UsedMovementConfig.MoveForces.x);
            LimitSpeed();
        }
        
        public void Backward(float factor)
        {
            Body.AddForce(Vector3.back*UsedMovementConfig.MoveForces.x);
            LimitSpeed();
        }

        public void Stop()
        {
            Body.velocity = Vector3.zero;
            Body.angularVelocity = Vector3.zero;
        }

        private void LimitSpeed()
        {
            var limitedVelocity =
                new Vector3(
                    Mathf.Clamp(Body.velocity.x, -UsedMovementConfig.MaximumSpeed, UsedMovementConfig.MaximumSpeed),
                    Body.velocity.y,
                    Mathf.Clamp(Body.velocity.z, -UsedMovementConfig.MaximumSpeed, UsedMovementConfig.MaximumSpeed));
            Body.velocity = limitedVelocity;
        }
    }
}