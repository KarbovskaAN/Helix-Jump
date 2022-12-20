using UnityEngine;
using UnityEngine.UI;

public class Gradient : MonoBehaviour
{
    public RawImage img;
    private Texture2D backgroundTexture ;

    public Color ColorUp;
    public Color ColorDown;

    void Awake()
    {
        backgroundTexture  = new Texture2D(1, 2);
        backgroundTexture.wrapMode = TextureWrapMode.Clamp;
        backgroundTexture.filterMode = FilterMode.Bilinear;
        SetColor( ColorDown, ColorUp ) ;
    }

    public void SetColor( Color color1, Color color2 )
    {
        backgroundTexture.SetPixels( new Color[] { color1, color2 } );
        backgroundTexture.Apply();
        img.texture = backgroundTexture;
    }
}
