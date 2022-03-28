using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScripts : MonoBehaviour
{
    public float Speed = 10f;
    public float Health = 1f;
    public float RateOfFire = 0.005f;
    public float GenerateCharge = 10f;
    public bool isMiniboss;
    public GameObject[] PowerUps = new GameObject[3];
    public GameObject deathEffect;

    public GameObject Bullet;
    public GameObject EnemySpawn;
    public GameObject EnemySpawn2;
    public GameObject EnemySpawn3;
    public GameObject Missile;


    private bool destroyed = false;
    private float CurrentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        CurrentSpeed = Speed;
        if (isMiniboss)
        {
            Miniboss1();
        } 
        else
        {
            Boss1();
        }
    }

    // Update is called once per frame
    void Update()
    {

            if (transform.position.z > 35)
            {
                transform.Translate(transform.forward * -Speed * Time.deltaTime);
            }
            else
            {
                if (!isMiniboss)
                {
                    StartCoroutine(RotateBoss());
                }
                else
                {
                    if (transform.position.x <= -(GameManager.instance.xBound - 10))
                    {
                        CurrentSpeed = Speed;
                    }
                    else if (transform.position.x > (GameManager.instance.xBound - 10))
                    {
                        CurrentSpeed = -Speed;
                    }
                transform.Translate(transform.right * CurrentSpeed * Time.deltaTime);
            }
                
            }
        
    }

    // Function for miniboss
    private void Miniboss1()
    {
        InvokeRepeating("PickAbility", 2, 3);
    }

    // Function for boss
    private void Boss1()
    {
        InvokeRepeating("PickAbilityBoss", 2, 3);
    }

    // Chooses a random ability.
    private void PickAbility()
    {
        int RandomInt = Random.Range(1, 100);
        if (RandomInt > 50)
        {
            StartCoroutine(Shoot(Bullet, -6, -5, 20));
            StartCoroutine(Shoot(Bullet, 6, -5, 20));
        } else
        {
            StartCoroutine(Shoot(Missile, -10, 0, 5));
            StartCoroutine(Shoot(Missile, 10, 0, 5));
        }
    }

    // Chooses a random ability to activate
    private void PickAbilityBoss()
    {
        int RandomInt = Random.Range(1, 100);
        if (RandomInt < 20) // Shoots spinner
        {
            StartCoroutine(Shoot(Bullet, -6, 0, 80));
        }
        else if (RandomInt > 80) // Shoots laser
        {
            StartCoroutine(Shoot(Missile, -10, 0, 2));
            StartCoroutine(SpawnEnemy(EnemySpawn2, 2));
        }
        else if (RandomInt > 60 && RandomInt < 80) // Spawns enemy 6
        {
            StartCoroutine(SpawnEnemy(EnemySpawn, 4));
        }
        else // Spawns enemy 4
        {
            if (!GameObject.Find("Enemy4(Clone)"))
            {
                //StartCoroutine(SpawnEnemy(EnemySpawn3, 1, -25, 50)); 
                StartCoroutine(SpawnEnemy(EnemySpawn3, 1, Random.Range(-25, 25), -50));
                StartCoroutine(SpawnEnemy(EnemySpawn3, 1, Random.Range(-25, 25), -50));
            }
            else
            {
                StartCoroutine(SpawnEnemy(EnemySpawn2, 2));
            }
            
        }
        Debug.Log(RandomInt);
    }

    // Rotates the bullet towards the player
    private void rotateMissile(GameObject newprojectile)
    {
        if (GameObject.FindWithTag("Player")) {
            Quaternion Rotate = Quaternion.LookRotation(GameObject.FindWithTag("Player").transform.position - newprojectile.transform.position, Vector3.up);
            newprojectile.transform.rotation = Rotate;
            newprojectile.transform.eulerAngles = new Vector3(90, newprojectile.transform.eulerAngles.y, newprojectile.transform.eulerAngles.z);
        }
    }

    // Shoots bullet
    public IEnumerator Shoot(GameObject Projectile, float xAxis, float zAxis, int projectileAmount)
    {
        for (int i = 0; i < projectileAmount; i++)
        {
            GameObject newBullet = Instantiate(Projectile, transform.position + new Vector3(xAxis, 0, zAxis), transform.rotation);
            if (Projectile == Missile) { rotateMissile(newBullet); yield return new WaitForSeconds(RateOfFire * 100); }
            yield return new WaitForSeconds(RateOfFire);
        }
    }

    // Spawns enemy
    public IEnumerator SpawnEnemy(GameObject Enemy, int amount, float xPos = 0, float zPos = 0)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(Enemy, transform.position + new Vector3(xPos, 0, xPos), Quaternion.Euler(90, 180,0));
            yield return new WaitForSeconds(0.6f);
        }
    }
    // Spins the boss
    public IEnumerator RotateBoss()
    {
        Quaternion Start = transform.rotation;
        Quaternion End = transform.rotation * Quaternion.Euler(0, 0, 1);
        transform.rotation = Quaternion.Slerp(Start, End, Time.time * 0.2f);
        yield return new WaitForSeconds(0.1f);
    }

    // Takes damage
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
            if (!isMiniboss) { GameManager.instance.TriggerWin(); }
        }
    }

    // Drop power up on death
    private void dropPowerup()
    {
        int choosePowerUp = Random.Range(1, 100);
        if (choosePowerUp < 50)
        {
            Instantiate(PowerUps[0], transform.position, PowerUps[0].transform.rotation);
        }
        else
        {
            Instantiate(PowerUps[1], transform.position, PowerUps[1].transform.rotation);
        }
        Instantiate(PowerUps[2], transform.position, PowerUps[2].transform.rotation);
    }

    // Activates when colliding with player
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player" && !other.transform.GetComponent<PlayerScript>().isInvincible)
        {
            other.transform.GetComponent<PlayerScript>().DeathTrigger();
            takeDamage(10);
        }
    }

}
