using UnityEngine.Rendering.Universal;

namespace Misc
{
    public class DebugsController : BaseController<DebugsModel>
    {
        private Tonemapping _tonemapping;
        private Bloom _bloom;
        private Vignette _vignette;
        private LiftGammaGain _liftGammaGain;

        public void Init()
        {
            _tonemapping = Model.Volume.profile.components.Find(c => c is Tonemapping) as Tonemapping;
            _bloom = Model.Volume.profile.components.Find(c => c is Bloom) as Bloom;
            _vignette = Model.Volume.profile.components.Find(c => c is Vignette) as Vignette;
            _liftGammaGain = Model.Volume.profile.components.Find(c => c is LiftGammaGain) as LiftGammaGain;
            
            Model.CallDebugsButton.onClick.AddListener(SwitchDebugsWindow);
            
            Model.VolumeWeightSlider.onValueChanged.AddListener(UpdateVolumeWeight);
            Model.TonemappingToggle.onValueChanged.AddListener(ToggleTonemapping);
            Model.BloomThresholdSlider.onValueChanged.AddListener(UpdateBloomThreshold);
            Model.BloomIntensitySlider.onValueChanged.AddListener(UpdateBloomIntensity);
            Model.VignetteIntensitySlider.onValueChanged.AddListener(UpdateVignetteIntensity);
            Model.VignetteSmoothnessSlider.onValueChanged.AddListener(UpdateVignetteSmoothness);
            Model.LiftToggle.onValueChanged.AddListener(ToggleLift);
            Model.GammaToggle.onValueChanged.AddListener(ToggleGamma);
            Model.GainToggle.onValueChanged.AddListener(ToggleGain);
        }
        
        private void UpdateVolumeWeight(float factor)
        {
            Model.Volume.weight = factor;
        }

        private void ToggleTonemapping(bool on)
        {
            _tonemapping.active = on;
        }

        private void UpdateBloomThreshold(float factor)
        {
            _bloom.threshold.value = factor;
        }

        private void UpdateBloomIntensity(float factor)
        {
            _bloom.intensity.value = factor;
        }

        private void UpdateVignetteIntensity(float factor)
        {
            _vignette.intensity.value = factor;
        }

        private void UpdateVignetteSmoothness(float factor)
        {
            _vignette.smoothness.value = factor;
        }

        private void ToggleLift(bool on)
        {
            _liftGammaGain.lift.overrideState = on;
        }

        private void ToggleGamma(bool on)
        {
            _liftGammaGain.gamma.overrideState = on;
        }

        private void ToggleGain(bool on)
        {
            _liftGammaGain.gain.overrideState = on;
        }

        private void SwitchDebugsWindow()
        {
            var isOn = Model.DebugsObject.activeSelf;
            Model.DebugsObject.SetActive(!isOn);
        }
    }
}