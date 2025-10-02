using UnityEngine;

public class TeleportPoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject, 0.25f);
    }
}
