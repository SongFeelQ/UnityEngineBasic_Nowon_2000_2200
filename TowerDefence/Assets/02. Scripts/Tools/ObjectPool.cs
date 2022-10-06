using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool _instance;
    public static ObjectPool instance
    {
        get
        {
            if (_instance == null)
                _instance = Instantiate(Resources.Load<ObjectPool>("Assets/ObjectPool"));
            return _instance;
        }
    }

    private List<PoolElement> poolElements = new List<PoolElement>();
    private Dictionary<string, Queue<GameObject>> spawnedQueuePairs = new Dictionary<string, Queue<GameObject>>();

    // ==================================================
    // *************** Public Methods *******************
    // ==================================================

    /// <summary>
    /// �ʿ��� ��ü�� ���� ����.
    /// </summary>
    /// <param name="poolElement"></param>
    public void AddPoolElement(PoolElement poolElement)
        => poolElements.Add(poolElement);

    public void InstantiateAllPoolElements()
    {
        foreach (PoolElement poolElement in poolElements)
        {
            if (spawnedQueuePairs.ContainsKey(poolElement.name) == false)
                spawnedQueuePairs.Add(poolElement.name, new Queue<GameObject>());

            for (int i = 0; i < poolElement.num; i++)
            {
                InstantiatePoolElement(poolElement);
            }
        }
    }

    /// <summary>
    /// â���� �׾Ƶξ��� ���� ǰ���߿��� �ϳ� ������ �뿩.
    /// </summary>
    /// <param name="name"> �뿩 �̸�</param>
    /// <param name="spawnPoint"> ��� ��ġ</param>
    /// <returns></returns>
    /// 
    public GameObject Spawn(string name, Vector3 spawnPoint)
    {
        if (spawnedQueuePairs.ContainsKey(name) == false)
            return null;

        // ������ ���Ҵ� ��ü���� ��� �� �������� �� ���� ������
        if (spawnedQueuePairs[name].Count <= 0)
        {
            PoolElement poolElement = poolElements.Find(element => element.name == name);
            if (poolElement != null)
            {
                // ���� ��ȯ ������ ����Ͽ� �̸� �����س���
                for (int i = 0; i < Math.Ceiling(Math.Log10(poolElement.num)); i++)
                {
                    InstantiatePoolElement(poolElement);
                }
            }
        }

        GameObject go = spawnedQueuePairs[name].Dequeue();
        go.transform.position = spawnPoint;
        go.transform.SetParent(null);
        go.SetActive(true);
        return go;
    }
    public GameObject Spawn(string name, Vector3 spawnPoint, Quaternion rotation)
    {
        if (spawnedQueuePairs.ContainsKey(name) == false)
            return null;

        // ������ ���Ҵ� ��ü���� ��� �� �������� �� ���� ������
        if (spawnedQueuePairs[name].Count <= 0)
        {
            PoolElement poolElement = poolElements.Find(element => element.name == name);
            if (poolElement != null)
            {
                // ���� ��ȯ ������ ����Ͽ� �̸� �����س���
                for (int i = 0; i < Math.Ceiling(Math.Log10(poolElement.num)); i++)
                {
                    InstantiatePoolElement(poolElement);
                }
            }
        }

        GameObject go = spawnedQueuePairs[name].Dequeue();
        go.transform.position = spawnPoint;
        go.transform.rotation = rotation;
        go.transform.SetParent(null);
        go.SetActive(true);
        return go;
    }

    /// <summary>
    /// �ݳ�
    /// </summary>
    /// <param name="obj">�ݳ� ǰ��</param>
    public void Return(GameObject obj)
    {
        if (spawnedQueuePairs.ContainsKey(obj.name) == false)
        {
            Debug.LogError($"[ObjectPool] : {obj.name} �� �ְ����Ծ�? ���� ���������� ���µ�?");
            return;
        }

        obj.transform.SetParent(transform);
        obj.transform.localPosition = Vector3.zero;
        spawnedQueuePairs[obj.name].Enqueue(obj);
        obj.SetActive(false);
        RearrangeSiblings(obj);
    }

    public void Return(GameObject obj, float sec)
    {
        if (spawnedQueuePairs.ContainsKey(obj.name) == false)
        {
            Debug.LogError($"[ObjectPool] : {obj.name} error.");
            return;
        }

        StartCoroutine(E_Return(obj, sec));
    }

    // ==================================================
    // *************** Private Methods ******************
    // ==================================================

    private void Awake()
    {
        transform.position = new Vector3(5000, 5000, 5000);
    }

    IEnumerator E_Return(GameObject obj, float sec)
    {
        yield return new WaitForSeconds(sec);

        obj.transform.SetParent(transform);
        obj.transform.localPosition = Vector3.zero;
        spawnedQueuePairs[obj.name].Enqueue(obj);
        obj.SetActive(false);
        RearrangeSiblings(obj);
    }

    private GameObject InstantiatePoolElement(PoolElement poolElement)
    {
        GameObject go = Instantiate(poolElement.prefab, transform);
        go.name = poolElement.name;
        spawnedQueuePairs[poolElement.name].Enqueue(go);
        go.SetActive(false);
        RearrangeSiblings(go);
        return go;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"> �����ϰ� ���� �ڽ� ������Ʈ </param>
    private void RearrangeSiblings(GameObject obj)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == obj.name)
            {
                obj.transform.SetSiblingIndex(i);
                return;
            }
        }

        obj.transform.SetAsLastSibling();
    }

}