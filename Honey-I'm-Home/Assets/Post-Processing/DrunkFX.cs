using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(DrunkFXRenderer), PostProcessEvent.AfterStack, "Custom/DrunkFX")]
public sealed class DrunkFX : PostProcessEffectSettings
{
    [Range(0f, 0.005f), Tooltip("Distortion Amplitude")]
    public FloatParameter amplitude = new FloatParameter { value = 0.005f };

    [Range(0f, 1f), Tooltip("Distortion Frequency")]
    public FloatParameter frequency = new FloatParameter { value = 0.5f };

    [Tooltip("Speed of distortion on x & y")]
    public Vector4Parameter speed = new Vector4Parameter { value = new Vector4(1f, 1f, 0f, 0f) };

    [Tooltip("Size of distortion on x & y")]
    public Vector4Parameter size = new Vector4Parameter { value = new Vector4(1f, 1f, 0f, 0f) };
}

public sealed class DrunkFXRenderer : PostProcessEffectRenderer<DrunkFX>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Custom/DrunkFX"));
        sheet.properties.SetFloat("_Amplitude", settings.amplitude);
        sheet.properties.SetFloat("_Frequency", settings.frequency);
        sheet.properties.SetVector("_Speed", settings.speed);
        sheet.properties.SetVector("_Size", settings.size);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}