using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DrunkFXController : MonoBehaviour
{
    PostProcessVolume _volume;
    DrunkFX _drunkFX;
    float drunkMeter;
    DrunkPlayerMovement playerMovementStats;

    private void Awake()
    {
        _volume = GetComponent<PostProcessVolume>();
        playerMovementStats = GameObject.Find("Player").GetComponent<DrunkPlayerMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _volume.profile.TryGetSettings(out _drunkFX);
    }

    // Update is called once per frame
    void Update()
    {
        adjustFXBasedOnDrunkMeter();
    }

    private void adjustFXBasedOnDrunkMeter()
    {
        drunkMeter = playerMovementStats.DrunkMeter;

        /*----Drunk FX----*/

        // Amplitude (Min = 0, Max = 0.05)
        _drunkFX.amplitude.value = 0.01f;

        // Frequency (Min = 0, Max = 1)
        _drunkFX.frequency.value = 0.5f;

        // Size (Only dealing with X and Y values) -> (Min = 0, Max = 10)
        _drunkFX.size.value.x = drunkMeter / 10;
        _drunkFX.size.value.y = drunkMeter / 10;

        // Speed (Only dealing with X and Y values) -> (Min = 0, Max = 10)
        _drunkFX.speed.value.x = drunkMeter / 10;
        _drunkFX.speed.value.y = drunkMeter / 10;

    }
}
