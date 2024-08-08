using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리펩을 보관하는 변수
    public GameObject[] prefabs;

    // 프리펩 풀을 담당하는 리스트
    List<GameObject>[] pools;

    void Awake()
    {
        // 풀 리스트를 초기화
        pools = new List<GameObject>[prefabs.Length];

        //pools 안의 리스트를 초기화
        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }

    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // 선택한 풀의 놀고 있는(비활성화 된) 게임오브젝트 접근
        // 발견하면 select 변수에 할당
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // 놀고있는 게임 오브젝트가 없다면
        // 새롭게 생성후 select 변수에 할당
        if (!select)
        {
            select = Instantiate(prefabs[index], transform); //transform은 자식으로 넣는 것을 말함
            pools[index].Add(select);

        }

        return select;
    }
}
