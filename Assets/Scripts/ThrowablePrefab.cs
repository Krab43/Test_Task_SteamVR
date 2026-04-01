using Valve.VR.InteractionSystem;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshFilter))]
public class ThrowablePrefab : MonoBehaviour
{
    private void Awake()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        
        if (meshFilter.sharedMesh != null)
        {
            MeshCollider mc = gameObject.AddComponent<MeshCollider>();
            mc.convex = true;
        }
    }
    
    private void HandHoverUpdate(Hand hand)
    {
        if (hand.GetGrabStarting() != GrabTypes.None)
        {
            hand.AttachObject(gameObject, hand.GetGrabStarting());
        }
    }
    
    private void OnDetachedFromHand(Hand hand)
    {
        GetComponent<Rigidbody>().useGravity = true;
    }
}
