using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text fpsText;

    private void Update()
    {
        float fps = 1f / Time.deltaTime;
        fpsText.text = $"FPS: {fps:0}";
    }
}
