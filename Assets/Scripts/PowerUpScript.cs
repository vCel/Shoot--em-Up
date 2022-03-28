using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public int PowerUpType;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, -0.1f) * 100 * Time.deltaTime, Space.World); // Moves power-up
    }

    // 
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (PowerUpType == 1)
            {
                BulletUp(other);
            }
            else if (PowerUpType == 2)
            {
                MissileUp(other);
            }
            else
            {
                LifeUp();
            }
        }
    }

    // Increases amount of bullets
    void BulletUp(Collider Player)
    {
        if (Player.transform.GetComponent<PlayerScript>().GetPowerUps("Bullet") != 4)
        {
            Player.transform.GetComponent<PlayerScript>().IncreaseLevel("Bullet");
            Destroy(gameObject);
        }
    }

    // Fires lock on missiles at enemies
    void MissileUp(Collider Player)
    {
        if (Player.transform.GetComponent<PlayerScript>().GetPowerUps("Missile") != 4)
        {
            Player.transform.GetComponent<PlayerScript>().IncreaseLevel("Missile");
            Destroy(gameObject);
        }
    }

    // Restores life by one if not max already.
    void LifeUp()
    {
        if (GameManager.instance.Lives < 3)
        {
            GameManager.instance.addLives();
            Destroy(gameObject);
        }
    }
}
