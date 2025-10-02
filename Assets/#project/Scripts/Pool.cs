using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool<T>
where T : IPoolClient               //en gros doit "T" doit avoir interface (t hérite de) 
{
    private GameObject anchor;
    private GameObject prefab; 
    private Queue<T> queue = new();
    private int batch;
    public Pool(GameObject anchor, GameObject prefab, int batch)  //constructeur
    {
        this.anchor = anchor;
        this.prefab = prefab;
        this.batch = batch;

        CreateBatch();

    }

    private void CreateBatch()
    {
        for (int _ = 0; _ < batch; _++)
        {
            GameObject go = GameObject.Instantiate(prefab);
            if (go.TryGetComponent(out T client))
            {
                Add(client);
            }
            else
            {
                throw new ArgumentException("prefab doesn't have IPoolClient component");
            }
        }
    }

    public void Add(T client)
    {
        queue.Enqueue(client);
        client.Fall();
    }

    public T Get()
    {
        if (queue.Count == 0) CreateBatch();
        T client = queue.Dequeue();
        client.Arise(anchor.transform.position, anchor.transform.rotation);
        return client;
    }

}
