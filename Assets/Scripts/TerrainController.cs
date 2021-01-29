using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TerrainController : MonoBehaviour
{
    private TerrainManager[] terrains;
    [SerializeField] private Transform player;
    Thread t;

    // Start is called before the first frame update
    void Start()
    {
        Terrain[] ts = GameObject.FindObjectsOfType<Terrain>();
        terrains = new TerrainManager[ts.Length];

        int randX = Random.Range(0, 10000);
        int randY = Random.Range(0, 10000);

        for (int i = 0; i < ts.Length; i++)
        {
            terrains[i] = ts[i].GetComponent<TerrainManager>();
            terrains[i].terrain = terrains[i].GetComponent<Terrain>();
            terrains[i].xOffest = randX;
            terrains[i].yOffset = randY;
            terrains[i].GenerateTerrain();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < terrains.Length; i++)
        {
            Vector2 pPos = new Vector2(player.position.x, player.position.z);
            Vector2 tPos = new Vector2(terrains[i].transform.position.x, terrains[i].transform.position.z);

            float xPos = terrains[i].transform.position.x;
            float zPos = terrains[i].transform.position.z;

            float offestX = pPos.x < 0 ? -500 : 500;
            float offestY = pPos.y < 0 ? -500 : 500;
            if (Mathf.Abs(Mathf.Abs(pPos.x) - (Mathf.Abs(tPos.x) + offestX)) > 1000)
            {
                float value = (pPos.x - tPos.x);
                xPos += 2000 * (value / Mathf.Abs(value));
            }
            else if (Mathf.Abs(Mathf.Abs(pPos.y) - (Mathf.Abs(tPos.y) + offestY)) > 1000)
            {
                float value = (pPos.y - tPos.y);
                zPos += 2000 * (value / Mathf.Abs(value));
            }

            if (xPos != terrains[i].transform.position.x || zPos != terrains[i].transform.position.z)
            {
                Vector3 newPos = terrains[i].transform.position;
                newPos.x = xPos;
                newPos.z = zPos;

                terrains[i].transform.position = newPos;
                terrains[i].GenerateTerrain();
            }
        }
    }
}
