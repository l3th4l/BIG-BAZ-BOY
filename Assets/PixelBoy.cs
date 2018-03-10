using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/PixelBoy")]
internal sealed class PixelBoy : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private int h;

    [SerializeField]
    private int w = 720;

    protected void Start()
    {
        this.cam = GetComponent<Camera>();

        if (!SystemInfo.supportsImageEffects)
        {
            this.enabled = false;
            return;
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        source.filterMode = FilterMode.Point;
        RenderTexture buffer = RenderTexture.GetTemporary(this.w, this.h, -1);
        buffer.filterMode = FilterMode.Point;
        Graphics.Blit(source, buffer);
        Graphics.Blit(buffer, destination);
        RenderTexture.ReleaseTemporary(buffer);
    }

    private void Update()
    {
        float ratio = ((float)this.cam.pixelHeight / (float)this.cam.pixelWidth);
        this.h = Mathf.RoundToInt(this.w * ratio);
    }
}