using System;
using UnityEngine;

public class ItemSpwanPoint : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab; //  生成したいアイテム
    [SerializeField] private Transform[] spwanPoints; // いくつかのスポーンポイント
    [SerializeField] private float spwanRadius = 3f; // 半径

    void Start()
    {
        SpwanItems();
    }

    private void SpwanItems()
    {
        foreach(Transform sp in spwanPoints)
        {
            Vector3 randomPos = GetRandomPositionAround(sp.position);
            Instantiate(itemPrefab,randomPos,Quaternion.identity);
        }
    }

    Vector3 GetRandomPositionAround(Vector3 center)
    {
        Vector2 circle = UnityEngine.Random.insideUnitCircle * spwanRadius;
        Vector3 pos = new Vector3(center.x + circle.x, center.y, center.z + circle.y);

        return pos;
    }
}
