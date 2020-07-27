using UnityEngine;

[RequireComponent(typeof(RectTransform)), RequireComponent(typeof(TMPro.TextMeshProUGUI))]
public class UIWobbleAndGrow : MonoBehaviour
{
    private RectTransform uiElement;
    private TMPro.TextMeshProUGUI text;
    private float initialFontSize;
    private bool clockwise = true;
    private bool growing = true;
    private readonly int rotation = 10;
    private readonly int fontDiff = 4;
    private void Awake()
    {
        uiElement = GetComponent<RectTransform>();
        text = GetComponent<TMPro.TextMeshProUGUI>();
        initialFontSize = text.fontSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (growing)
        {
            text.fontSize += 0.1f;
            if (text.fontSize >= initialFontSize + fontDiff)
            {
                growing = false;
            }
        }
        else
        {
            text.fontSize -= 0.1f;
            if (text.fontSize <= initialFontSize - fontDiff)
            {
                growing = true;
            }
        }

        float zRotation = uiElement.eulerAngles.z;
        if (clockwise)
        {
            uiElement.rotation = Quaternion.Euler(0, 0, uiElement.eulerAngles.z - 0.1f);
            if (AlmostEquals(zRotation, 360 - rotation, 0.1f))
            {
                clockwise = false;
            }
        }
        else
        {
            uiElement.rotation = Quaternion.Euler(0, 0, uiElement.eulerAngles.z + 0.1f);
            if (AlmostEquals(zRotation, rotation, 0.1f))
            {
                clockwise = true;
            }
        }
    }

    public static bool AlmostEquals(float f1, float f2, float precision)
    {
        return (Mathf.Abs(f1 - f2) <= precision);
    }
}
