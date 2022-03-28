using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public bool canFire = true;
    public bool followPlayer = false;
    public bool turnToPlayer = false;
    public float Speed = 10f;
    public float Health = 1f;
    public float RateOfFire = 2.5f;
    public int BulletsPerShot = 1;
    public bool isMaxDistance;
    public float MaxDistance = 0f; // 0 = Max Distance off
    public int ShotType = 1; // 1 = Normal (Straight line), 2 = Circle, 3 = Spiral
    public float SecsBetweenShots = 0.1f;
    public float GenerateCharge = 1f;

    private float Firetime;
    private bool active;
    private bool destroyed = false;

    public bool isDamaged = false;
    public GameObject deathEffect;
    public GameObject Projectile;
    public GameObject[] PowerUps = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        MaxDistance = Random.Range(MaxDistance - 5, MaxDistance + 5);
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        Move();
    }

    // Moves the enemy
    private void Move()
    {
        if (turnToPlayer && GameObject.FindWithTag("Player"))
        {
            Quaternion Rotate = Quaternion.LookRotation(GameObject.FindWithTag("Player").transform.position - transform.position, Vector3.up);
            transform.rotation = Rotate;
            transform.eulerAngles = new Vector3(90, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        
        if (!isMaxDistance || transform.position.z > MaxDistance)
        {
            transform.Translate(-transform.forward * Speed * Time.deltaTime);
            if (transform.position.z < -(GameManager.instance.zBound + 5)) {
                Destroy(gameObject);
                takeDamage(100);
            }
        }
        
    }

    // Fires
    private void Shoot()
    {
        if (canFire && Time.time > Firetime)
        {
            StartCoroutine(FireShots(Projectile));
            Firetime = Time.time + RateOfFire;
        }
    }

    // Enemy takes damage
    public void takeDamage(float damage)
    {
        Health -= damage;

        if (Health <= 0 && !destroyed)
        {
            Destroy(gameObject);
            destroyed = !destroyed;
            Instantiate(deathEffect, transform.position, transform.rotation);
            dropPowerup();
            GameManager.instance.ultimateCharge += GenerateCharge;
            GameManager.instance.enemyCount--;
        }
    }

    // Collision
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (!other.transform.GetComponent<PlayerScript>().isInvincible)
            {
                other.transform.GetComponent<PlayerScript>().DeathTrigger();
                Destroy(gameObject);
            }
            takeDamage(100);
        }
    }

    // Drop power-up on death
    private void dropPowerup()
    {
        int number = Random.Range(1, 100);
        if (number < 6)
        {
            int choosePowerUp = Random.Range(1, 100);
            if (choosePowerUp < 45) //45
            {
                Instantiate(PowerUps[0], transform.position, PowerUps[0].transform.rotation);
            }
            else if (choosePowerUp > 90) //90
            {
                Instantiate(PowerUps[2], transform.position, PowerUps[2].transform.rotation);
            }
            else
            {
                Instantiate(PowerUps[1], transform.position, PowerUps[1].transform.rotation);
            }
        }
    }

    // Fire shots patterns
    public IEnumerator FireShots(GameObject Beam)
    {
        for (int i = 0; i < BulletsPerShot; i++)
        {
            if (ShotType == 1)
            {
                Instantiate(Beam, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 2f), transform.rotation);
            }
            else if (ShotType == 2 && transform.position.z <= MaxDistance)
            {
                float set_angle = 30;
                for (float angle = 0; angle < 360; angle += set_angle)
                {
                    Quaternion Start = transform.rotation;
                    Quaternion End = transform.rotation * Quaternion.Euler(0, 0, set_angle);
                    transform.rotation = Quaternion.Slerp(Start, End, Time.time * 10f);
                    Instantiate(Beam, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 2f), transform.rotation);
                    transform.rotation *= Quaternion.Euler(0, 0, 5);
                }
            }
            else if (ShotType == 3 && transform.position.z <= MaxDistance && !active)
            {
                float set_angle = 10;
                active = true;
                for (float angle = 0; angle < 360; angle += set_angle)
                {
                    Quaternion Start = transform.rotation;
                    Quaternion End = transform.position.x > 0 ? transform.rotation * Quaternion.Euler(0, 0, set_angle) : transform.rotation * Quaternion.Euler(0, 0, -set_angle);
                    transform.rotation = Quaternion.Slerp(Start, End, Time.time * 10f);
                    Instantiate(Beam, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 2f), transform.rotation);
                    yield return new WaitForSeconds(0.005f);
                }
                yield return new WaitForSeconds(1f);
                active = false;
                
            }
            
            yield return new WaitForSeconds(SecsBetweenShots);
        }
    }
}
