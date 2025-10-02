using UnityEngine;

public class CreatureBehavior : MonoBehaviour, IPoolClient
{
    public SpawnPoint sp;
    public void Arise(Vector3 position, Quaternion rotation)
    {
        gameObject.SetActive(true);
        transform.position = position;
        transform.rotation = rotation;
    }

    public void Fall()
    {
        gameObject.SetActive(false);
    }

    public void Teleport()
    {
        sp.Teleport(this);
    }

}
