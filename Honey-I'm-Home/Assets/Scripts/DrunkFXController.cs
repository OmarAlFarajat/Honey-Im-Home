using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DrunkFXController : MonoBehaviour
{
    PostProcessVolume _volume;
    DrunkFX _drunkFX;
    Bloom _bloom;
    ChromaticAberration _chromaticAbberation;

    float drunkMeter;
    float initialDrunkMeter;
    DrunkPlayerMovement playerMovementStats;
    bool hasFirstLoopPassed = false;

    private void Awake()
    {
        _volume = GetComponent<PostProcessVolume>();
        playerMovementStats = GameObject.Find("Player").GetComponent<DrunkPlayerMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _volume.profile.TryGetSettings(out _drunkFX);
        _volume.profile.TryGetSettings(out _bloom);
        _volume.profile.TryGetSettings(out _chromaticAbberation);
        initialDrunkMeter = playerMovementStats.DrunkMeter;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        adjustFXBasedOnDrunkMeter();
    }

    private void adjustFXBasedOnDrunkMeter()
    {
        drunkMeter = playerMovementStats.DrunkMeter;

        if (initialDrunkMeter == drunkMeter && hasFirstLoopPassed)
        {
            return;
        }

        /*----Drunk FX----*/

        // Amplitude (Min = 0, Max = 0.005)
        _drunkFX.amplitude.value = 0.005f;

        // Frequency (Min = 0, Max = 1)
        _drunkFX.frequency.value = 0.5f;

        // Size (Only dealing with X and Y values) -> (Min = 0, Max = 10)
        _drunkFX.size.value.x = (drunkMeter / 20) + (Random.Range(0, 15) / 3);
        _drunkFX.size.value.y = (drunkMeter / 20) + (Random.Range(0, 15) / 3);

        // Speed (Only dealing with X and Y values) -> (Min = 0, Max = 10)
        _drunkFX.speed.value.x = (drunkMeter / 20) + (Random.Range(0, 15) / 3);
        _drunkFX.speed.value.y = (drunkMeter / 20) + (Random.Range(0, 15) / 3);

        /*---Bloom---*/

        // Intensity (Min = 0, Max = 3)
        _bloom.intensity.value = (drunkMeter / 100) * 3;

        /*---Chromatic Abberation---*/

        // Intensity (Min = 0, Max = 1)
        _chromaticAbberation.intensity.value = (drunkMeter / 100);


        initialDrunkMeter = drunkMeter;

        if (!hasFirstLoopPassed)
            hasFirstLoopPassed = true;
    }
}
