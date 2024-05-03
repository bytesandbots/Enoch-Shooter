using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform[] barrels;
    public float NukeRadius = 10;
    public float frequency = 0.1f;
    public float NukeFrequency = 5f;
    public GameObject Explosion;
    public GameObject SmallExplosion;
    private float ctime;
    private float cnuketime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cnuketime > NukeFrequency) 
        {
            if (Input.GetKey(KeyCode.M))
            {
                Collider2D[] victims = Physics2D.OverlapCircleAll(transform.position, NukeRadius);
                foreach (Collider2D victim in victims)
                {
                    if (victim.gameObject.CompareTag("enemy"))
                    {
                        victim.GetComponent<EnemyHealth>().takedamage(10);
                        GameObject Explosionclone = Instantiate(Explosion, victim.gameObject.transform.position, Quaternion.identity);
                        Destroy(Explosionclone, 1);
                    }
                    if (victim.gameObject.CompareTag("Bullet"))
                    {
                        Destroy(victim.gameObject);
                        GameObject SmallExplosionclone = Instantiate(SmallExplosion, victim.gameObject.transform.position, Quaternion.identity);
                        Destroy(SmallExplosionclone, 1);
                    }
                }
                cnuketime = 0;
            }
            
        }
        else
        {
            cnuketime += Time.deltaTime;
        }
        if (ctime > frequency)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                ctime = 0;
                foreach (Transform barrel in barrels)
                {
                    GameObject Clone = Instantiate(projectile, barrel.position, barrel.rotation);
                    Destroy(Clone, 3f);
                }
            }
        }
        else
        {
            ctime += Time.deltaTime;
        }

    }
}
