using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ShroomEffect : MonoBehaviour
{
    public Volume volume;
    public float distortionIncrement = 0.25f;
    public float aberrationIncrement = 0.25f;



    private ChromaticAberration chromaticAberration;
    private LensDistortion lensDistortion;

    private void Start()
    {
        if (volume.profile.TryGet<ChromaticAberration>(out ChromaticAberration aberration))
        {
            chromaticAberration = aberration;
        }
        if (volume.profile.TryGet<LensDistortion>(out LensDistortion distortion))
        {
            lensDistortion = distortion;
        }
    }

    public void IncreaseEffect()
    {
        chromaticAberration.intensity.value += aberrationIncrement;
        lensDistortion.intensity.value += distortionIncrement;

    }
}
