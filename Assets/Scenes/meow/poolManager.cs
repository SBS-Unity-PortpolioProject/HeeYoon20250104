using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class c : MonoBehaviour
{
    // ������ ������ ����
    public GameObject[] prefabs;

    // Ǯ ����ϴ� ����Ʈ (�迭�� ����)
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length]; // �迭 ����

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>(); // �� ����Ʈ �ʱ�ȭ
        }

        Debug.Log(pools.Length);
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // ���õ� Ǯ���� ������Ʈ ��������
        foreach(GameObject item in pools[index])
        {
            if (item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                
            }
        }

        if (!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
