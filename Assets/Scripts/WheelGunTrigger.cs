
using UnityEngine;

public class WheelGunTrigger : MonoBehaviour
{
    public PitStopManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<WheelGunMarker>() != null)
        {
            manager.TightenWheel();
        }
    }
}

public class WheelGunMarker : MonoBehaviour
{
}
