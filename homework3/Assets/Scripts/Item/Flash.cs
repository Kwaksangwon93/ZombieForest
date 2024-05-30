using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Flash : Item
{
    public float duration;
    private Coroutine coroutine;
    private GameObject player;
    public PostProcessVolume volume;
    private Vignette vignette;
    public float bright = 0.05f;
    private float passiveIntensity = 0.7f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        volume = player.transform.GetChild(1).GetComponent<PostProcessVolume>();
        if (volume != null)
        {
            volume.profile.TryGetSettings(out vignette);
        }
    }

    public void SetVignetteIntensity(float intensity)
    {
        if (vignette != null)
            vignette.intensity.value = intensity;
    }

    public override void ItemUsed()
    {
        base.ItemUsed();
        SetVignetteIntensity(vignette.intensity.value - bright);
    }
}