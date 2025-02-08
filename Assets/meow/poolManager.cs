using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class c : MonoBehaviour
{
    // 프리펩 보관할 변수
    public GameObject[] prefabs;

    // 풀 담당하는 리스트 (배열로 변경)
    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // 선택된 풀에서 오브젝트 가져오기
        foreach(GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
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
