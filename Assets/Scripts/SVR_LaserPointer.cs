using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine;

public class SVR_LaserPointer : MonoBehaviour
{
    [SerializeField] private SteamVR_Action_Boolean triggerAction = 
        SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");
    
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private LayerMask buttonLayer;

    private LineRenderer _lineRenderer;
    private SVR_ButtonScript _currentButton;

    private void Awake()
    {
        _lineRenderer = gameObject.AddComponent<LineRenderer>();
        _lineRenderer.startWidth = 0.005f;
        _lineRenderer.endWidth = 0.005f;
        _lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        _lineRenderer.material.color = Color.red;
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, buttonLayer))
        {
            DrawLaser(ray.origin, hit.point);

            SVR_ButtonScript button = hit.collider.GetComponent<SVR_ButtonScript>();

            if (button != null)
            {
                if (_currentButton != button)
                {
                    _currentButton?.OnHoverExit();
                    _currentButton = button;
                    _currentButton.OnHoverEnter();
                }

                if (triggerAction.GetStateDown(SteamVR_Input_Sources.Any))
                {
                    _currentButton.Press();
                }
            }
        }
        else
        {
            DrawLaser(ray.origin, ray.origin + ray.direction * maxDistance);

            _currentButton?.OnHoverExit();
            _currentButton = null;
        }
    }

    private void DrawLaser(Vector3 start, Vector3 end)
    {
        _lineRenderer.SetPosition(0, start);
        _lineRenderer.SetPosition(1, end);
    }
}