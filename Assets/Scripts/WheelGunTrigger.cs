
using UnityEngine;

public class WheelGunTrigger : MonoBehaviour
{
    public PitStopManager manager;

    private void OnTriggerEnter(Collider other)
    {
        // Check whether the object touching the zone is the wheel gun
        WheelGunMarker gun =
            other.GetComponentInParent<WheelGunMarker>();

        if (gun != null)
        {
            Debug.Log("Wheel gun touched the wheel!");

            // Tell the game manager to tighten the wheel
            if (manager != null)
            {
                manager.TightenWheel();
            }
        }
    }
}
