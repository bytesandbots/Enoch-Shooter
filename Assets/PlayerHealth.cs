using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float overallhealth = 40;
    private float currenthealth;
    public GameObject Explosion;
    public Image HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = overallhealth;
        HealthBar.fillAmount = currenthealth/overallhealth;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            takedamage(1);
            Destroy(collision.gameObject);

        }
    }
    public void takedamage(float damage)
    {
        currenthealth -= damage;
        HealthBar.fillAmount = currenthealth / overallhealth;
        if (currenthealth <= 0)
        {
            SceneManager.LoadScene("Lose");
            Destroy(gameObject);
        }
        GameObject Explosionclone = Instantiate(Explosion, gameObject.gameObject.transform.position, Quaternion.identity);
        Destroy(Explosionclone, 1);
    }
    // Update is called once per frame
    void Update()
    {

    }
}