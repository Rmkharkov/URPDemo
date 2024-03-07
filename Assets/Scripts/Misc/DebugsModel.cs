using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

namespace Misc
{
    [System.Serializable]
    public class DebugsModel : BaseModel
    {
        [SerializeField] private Button callDebugsButton;
        [SerializeField] private GameObject debugsObject;
        
        [SerializeField] private Volume volume;
        [SerializeField] private Slider volumeWeightSlider;
        [SerializeField] private Toggle toneMappingToggle;
        
        [SerializeField] private Slider bloomThresholdSlider;
        [SerializeField] private Slider bloomIntensitySlider;
        
        [SerializeField] private Slider vignetteIntensitySlider;
        [SerializeField] private Slider vignetteSmoothnessSlider;
        
        
        [SerializeField] private Toggle liftToggle;
        [SerializeField] private Toggle gammaToggle;
        [SerializeField] private Toggle gainToggle;

        public Button CallDebugsButton => callDebugsButton;
        public GameObject DebugsObject => debugsObject;
        
        public Volume Volume => volume;
        public Slider VolumeWeightSlider => volumeWeightSlider;
        public Toggle TonemappingToggle => toneMappingToggle;
        
        public Slider BloomThresholdSlider => bloomThresholdSlider;
        public Slider BloomIntensitySlider => bloomIntensitySlider;
        
        public Slider VignetteIntensitySlider => vignetteIntensitySlider;
        public Slider VignetteSmoothnessSlider => vignetteSmoothnessSlider;

        public Toggle LiftToggle => liftToggle;
        public Toggle GammaToggle => gammaToggle;
        public Toggle GainToggle => gainToggle;
    }
}