using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    // 10초에 1개 유저 반경 x 50 z 50 사이에서 랜덤한 위치에 드랍
    // 아이템 타입은 랜덤

    public GameObject player;
    [SerializeField] private GameObject[] items = null;
    public float itemregen = 5f;
    public float curTime;

    private void SpawnItem()
    {
        int rand = Random.Range(0, items.Length);
        var item = Instantiate(items[rand]);
        Vector3 pos = new Vector3(player.transform.position.x + Random.Range(-25, 25), 20, player.transform.position.z + Random.Range(-25, 25));
        item.transform.position = pos;
        Debug.Log("보급 아이템이 도착했다!");
    }

    private void Update()
    {
        curTime += Time.deltaTime;
        if(curTime > itemregen)
        {
            curTime = 0;
            SpawnItem();
        }
    }
}
