using UnityEngine;

namespace Input
{
    [System.Serializable]
    public class PlayerInputModel : BaseModel
    {
        [SerializeField] private OnScreenStickCustom screenStick;
        public OnScreenStickCustom Stick => screenStick;
    }
}