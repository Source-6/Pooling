using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SpawnPoint : MonoBehaviour
{

    [SerializeField] private float cooldown = 1f;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform target;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(cooldown);
            GameObject creature = Instantiate(prefab,transform.position,transform.rotation);
            creature.GetComponent<NavMeshAgent>().SetDestination(target.position);
            
        }
    }
}
