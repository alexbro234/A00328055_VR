
using UnityEngine;

public class VictoryCarSpin : MonoBehaviour
{
    [Header("Victory Spin Settings")]
    public float spinSpeed = 180f;

    private bool spinning = false;

    void Update()
    {
        if (spinning)
        {
            transform.Rotate(
                Vector3.up,
                spinSpeed * Time.deltaTime,
                Space.World
            );
        }
    }

    public void StartSpinning()
    {
        spinning = true;
    }
}
