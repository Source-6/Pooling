using UnityEngine;

public class TeleportPoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CreatureBehavior creature))
        {
            creature.Teleport();
        }
    }
}
