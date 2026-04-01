using UnityEngine;

public class TargetScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            UIManager.Instance.ScoreUpdate();
        }
    }
}
