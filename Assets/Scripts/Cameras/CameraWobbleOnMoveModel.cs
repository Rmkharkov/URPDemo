using UnityEngine;

namespace Cameras
{
    [System.Serializable]
    public class CameraWobbleOnMoveModel : BaseModel
    {
        [SerializeField] private Transform trackTransform;
        [SerializeField] private Rigidbody trackBody;
        [SerializeField] private Animator cameraAnimator;
        public Transform TrackTransform => trackTransform;
        public Rigidbody TrackBody => trackBody;
        public Animator CameraAnimator => cameraAnimator;
    }
}