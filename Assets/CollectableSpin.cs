using UnityEngine;

public class CollectableSpin : MonoBehaviour
{
    public float spinSpeed = 180f;

    void Update()
    {
        transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
    }
}
