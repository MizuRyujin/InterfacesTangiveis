using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject banana;
    private GameObject bananaInstanced;
    [SerializeField] private GameObject apple;
    private GameObject appleInstanced;

    private Vector3 prevPos;
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    int timer;

    // Update is called once per frame
    void Update()
    {

        timer++;

        if (timer >= 1000)
        {
            if (prevPos != transform.position)
            {
                BuildFruits();
                prevPos = transform.position;
            }

            if (bananaInstanced != null)
            {
                if (Vector3.Distance(bananaInstanced.transform.position, player.position) > 200)
                {
                    bananaInstanced.SetActive(false);
                }
                else
                {
                    bananaInstanced.SetActive(true);
                }
            }
            if (appleInstanced != null)
            {
                if (Vector3.Distance(appleInstanced.transform.position, player.position) > 200)
                {
                    appleInstanced.SetActive(false);
                }
                else
                {
                    appleInstanced.SetActive(true);
                }
            }
            timer = 0;
        }
    }

    private void BuildFruits()
    {
        if (bananaInstanced != null)
        {
            Destroy(bananaInstanced);
        }
        if (appleInstanced != null)
        {
            Destroy(appleInstanced);
        }

        Vector3 posB = new Vector3(Random.Range(transform.position.x - 10, transform.position.x + 10), 500, Random.Range(transform.position.z - 10, transform.position.z + 10));
        Vector3 posA = new Vector3(Random.Range(transform.position.x - 10, transform.position.x + 10), 500, Random.Range(transform.position.z - 10, transform.position.z + 10));

        bananaInstanced = Instantiate(banana, posB, Quaternion.identity);
        appleInstanced = Instantiate(apple, posA, Quaternion.identity);

        bananaInstanced.isStatic = true;
        appleInstanced.isStatic = true;

        MoveFruit();
        prevPos = transform.position;

    }
    private void MoveFruit()
    {
        Vector3 bRayPos = bananaInstanced.transform.position;
        bRayPos.y = 500f;
        Vector3 aRayPos = appleInstanced.transform.position;
        aRayPos.y = 500f;

        Physics.Raycast(bRayPos, Vector3.down, out RaycastHit bhit, 10000);

        Physics.Raycast(aRayPos, Vector3.down, out RaycastHit ahit, 10000);

        if (bhit.collider != null && bhit.collider.gameObject.layer != 4)
        {
            bananaInstanced.SetActive(true);
            Vector3 bNewPoint = bhit.point;
            bNewPoint.y += 10f;
            bananaInstanced.transform.position = bNewPoint;
        }
        else
        {
            Destroy(bananaInstanced);
        }

        if (ahit.collider != null && bhit.collider.gameObject.layer != 4)
        {
            appleInstanced.SetActive(true);
            Vector3 aNewPoint = ahit.point;
            aNewPoint.y += 10f;
            appleInstanced.transform.position = aNewPoint;
        }
        else
        {
            Destroy(appleInstanced);
        }
    }
}
