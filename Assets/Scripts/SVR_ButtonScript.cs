using Valve.VR.InteractionSystem;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Interactable))]
public class SVR_ButtonScript : MonoBehaviour
{
    public UnityEvent OnPressed;

    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color hoverColor = Color.cyan;
    [SerializeField] private Color pressedColor = Color.green;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        SetColor(normalColor);
    }

    public void OnHoverEnter()
    {
        SetColor(hoverColor);
    }

    public void OnHoverExit()
    {
        SetColor(normalColor);
    }

    public void Press()
    {
        SetColor(pressedColor);
        OnPressed?.Invoke();
        Invoke(nameof(ResetColor), 0.2f); // скидає колір через 0.2 секунди
    }

    private void ResetColor()
    {
        SetColor(normalColor);
    }

    private void SetColor(Color color)
    {
        if (_renderer != null)
            _renderer.material.color = color;
    }
}
