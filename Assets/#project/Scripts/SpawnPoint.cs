using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SpawnPoint : MonoBehaviour
{

    [SerializeField] private float cooldown = 1f;
    [SerializeField] private GameObject prefab;
    private Pool<CreatureBehavior> pool;
    [SerializeField] private Transform target;
    void Start()
    {
        pool = new(gameObject, prefab, 2);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldown);
            CreatureBehavior creature = pool.Get();
            creature.sp = this;
            creature.GetComponent<NavMeshAgent>().SetDestination(target.position);

        }
    }

    public void Teleport(CreatureBehavior creature)
    {
        pool.Add(creature);
    }

}
