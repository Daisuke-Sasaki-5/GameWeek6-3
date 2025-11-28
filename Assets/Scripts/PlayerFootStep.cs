using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerFootStep : MonoBehaviour
{
    [Header("AudioSource")]
    public AudioSource audioSource;

    [Header("Footstep Clips")]
    public AudioClip grassClips;
    public AudioClip dirtClips;
    public AudioClip rockClips;

    private Terrain terrain;
    private TerrainData terrainData;

    void Start()
    {
        terrain = Terrain.activeTerrain;
        terrainData = terrain.terrainData;
    }

    public void PlayerFootsStep(Vector3 playerPos)
    {
        int dominaotinLayer = GetDominantTerrainTexture(playerPos);

        switch(dominaotinLayer)
        {
            case 0:
                audioSource.clip = grassClips;
                break;
            case 1:
                audioSource.clip = dirtClips;
                break;
            case 2:
                audioSource.clip = rockClips;
                break;
        }

        audioSource.Play();
    }

    private int GetDominantTerrainTexture(Vector3 worldPos)
    {
        // Terrainのデータにアクセス
        TerrainData data = terrainData;

        // ワールド座標 →　Terrain座標へ変換
        Vector3 terrainPos = worldPos - terrain.transform.position;

        float x = terrainPos.x / data.size.x;
        float z = terrainPos.z / data.size.z;

        // Terrainのサイズに対して現在位置がどの割合にいるか
        int mapX = Mathf.Clamp((int)(x * data.alphamapWidth), 0, data.alphamapWidth - 1);
        int mapZ = Mathf.Clamp((int)(z * data.alphamapWidth), 0, data.alphamapHeight - 1);

        // その他のalpamapを取得
        float[,,] alphamaps = data.GetAlphamaps(mapX, mapZ, 1, 1);

        int maxIndex = 0;
        float maxMix = 0;

        // どのレイヤーが最も濃いか
        for(int i = 0; i < data.alphamapLayers;  i++)
        {
            if(alphamaps[0,0,i] > maxMix)
            {
                maxMix = alphamaps[0,0,i];
                maxIndex = i;
            }
        }
        return maxIndex;
    }
}
