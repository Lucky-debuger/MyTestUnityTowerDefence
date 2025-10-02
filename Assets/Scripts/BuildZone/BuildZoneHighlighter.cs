using Unity.VisualScripting;
using UnityEngine;

public class BuildZoneHighlighter : MonoBehaviour
{
    [Header("Colors")]
    public Color normalColor = new Color(1, 1, 1, 0.1f);
    public Color validColor = new Color(0, 1, 0, 0.3f);
    public Color invalidColor = new Color(1, 0, 0, 0.3f);

    private MeshRenderer meshRenderer;
    private Material originalMaterial;
    private Material highlightMaterial;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;

        // Создаем материал для подсветки
        highlightMaterial = new Material(originalMaterial);
        meshRenderer.material = highlightMaterial;
        SetNormalColor();
    }

    public void HighlightValid()
    {
        highlightMaterial.color = validColor;
    }

    public void HighlightInvalid()
    {
        highlightMaterial.color = invalidColor;
    }

    public void SetNormalColor()
    {
        highlightMaterial.color = normalColor;
    }
}
