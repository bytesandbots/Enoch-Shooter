using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float overallhealth = 10;
    private float currenthealth;
    public GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = overallhealth;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            takedamage(6);
            Destroy(collision.gameObject);

        }
    }
    public void takedamage(float damage)
    {
        currenthealth -= damage;
        if (currenthealth <= 0)
        {
            GameObject.FindFirstObjectByType<SpawnManager>().bob();
            GameObject Explosionclone = Instantiate(Explosion, gameObject.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(Explosionclone, 1);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
