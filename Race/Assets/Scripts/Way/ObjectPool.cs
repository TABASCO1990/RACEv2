using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;

    private List<GameObject> _pool = new List<GameObject>();
    private int _firstObject = 1;

    protected void Initialize(GameObject prefab)
    {
        GameObject spawned = Instantiate(prefab, _container.transform);
        spawned.SetActive(false);
        _pool.Add(spawned);       
    }

    protected bool TryGetRandomObject(out GameObject result)
    {
        var randomSelection = _pool.Where(x => x.activeSelf == false).Skip(_firstObject);
        result = randomSelection.ElementAtOrDefault(new System.Random().Next() % randomSelection.Count());

        return result != null;
    }

    protected bool TryGetFirstObject(out GameObject result)
    {
        result = _pool.First(x => x.activeSelf == false);

        return result != null;
    }
}
