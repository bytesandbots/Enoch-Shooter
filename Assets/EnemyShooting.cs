using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform[] barrels;
    public float frequency = 0.1f;
    private float ctime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ctime > frequency)
        {

            ctime = 0;
            foreach (Transform barrel in barrels)
            {
                GameObject Clone = Instantiate(projectile, barrel.position, barrel.rotation);
                Destroy(Clone, 3f);
            }

        }
        else
        {
            ctime += Time.deltaTime;
        }

    }
}
