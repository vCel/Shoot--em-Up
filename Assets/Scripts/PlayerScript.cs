using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    SpriteRenderer PlayerSprite;
    public GameObject Projectile;
    public GameObject MissileProjectile;
    private Vector3 position;

    public float JetSpeed = 60.0f;
    public float RateOfFire = 0.0f;
    public float MissleROF = 1f;
    public bool isInvincible;
    public bool isDamaged;

    public Sprite JetSprite1, JetSprite2;
    public GameObject deathEffect;
    
    private float FireTime;
    private float MissileTime;

    private int BulletLevel = 1;
    private int MissileLevel = 1;
    private int MissileUltAmount = 20;

    private float BulletAngle = 20f;
    private float halfSpeed;
    // Start is called before the first frame update
    void Start()
    {
        halfSpeed = JetSpeed/2;
        PlayerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;

        MovePlayer();
        Boundary();
        Shoot();
        Missiles();
        transform.position = position;
    }

    // Player shoot and the amount based on power-ups
    private void Shoot()
    {
        if (Time.time > FireTime)
        {
            Instantiate(Projectile, new Vector3(transform.position.x - 2f, transform.position.y - 1f, transform.position.z + 2f), transform.rotation);
            Instantiate(Projectile, new Vector3(transform.position.x + 2f, transform.position.y - 1f, transform.position.z + 2f), transform.rotation);

            if (BulletLevel == 2)
            {
                Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 4f), transform.rotation);
            }
            else if (BulletLevel == 3)
            {
                Instantiate(Projectile, new Vector3(transform.position.x - 2f, transform.position.y - 1f, transform.position.z + 2f), transform.rotation * Quaternion.Euler(0, 0, BulletAngle));
                Instantiate(Projectile, new Vector3(transform.position.x + 2f, transform.position.y - 1f, transform.position.z + 2f), transform.rotation * Quaternion.Euler(0, 0, -BulletAngle));
            }
            else if (BulletLevel == 4)
            {
                Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 4f), transform.rotation);
                Instantiate(Projectile, new Vector3(transform.position.x - 2f, transform.position.y - 1f, transform.position.z + 2f), transform.rotation * Quaternion.Euler(0, 0, BulletAngle));
                Instantiate(Projectile, new Vector3(transform.position.x + 2f, transform.position.y - 1f, transform.position.z + 2f), transform.rotation * Quaternion.Euler(0, 0, -BulletAngle));
            }


            FireTime = Time.time + RateOfFire;
        }
        
        
    }

    // Fire missiles
    private void Missiles()
    {
        if (Time.time > MissileTime)
        {
            StartCoroutine(SpawnMissile(MissileLevel, 1f));
            MissileTime = Time.time + MissleROF;
        }
    }

    //Controlling the player and the buttons
    private void MovePlayer()
    {
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            position.z += JetSpeed * Time.deltaTime;
            PlayerSprite.sprite = JetSprite2;
        } else
        {
            PlayerSprite.sprite = JetSprite1;
        }
        
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            position.z -= JetSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            position.x += JetSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            position.x -= JetSpeed * Time.deltaTime;
        }
        if (Input.GetKey("left shift") || Input.GetKey("right shift"))
        {
            JetSpeed = halfSpeed;
        }
        else
        {
            JetSpeed = halfSpeed * 2;
        }
        if (Input.GetKeyDown("space"))
        {
            if (GameManager.instance.ultimateCharge >= 100)
            {
                StartCoroutine(SpawnMissile(MissileUltAmount, 0.2f));
                GameManager.instance.ultimateCharge = 0;
            }
           
        }
    }

    // Set the player boundary
    private void Boundary()
    {
        // Checking X Boundaries
        if (position.x >= GameManager.instance.xBound)
            position.x = GameManager.instance.xBound;
        else if (position.x <= -GameManager.instance.xBound)
            position.x = -GameManager.instance.xBound;

        if (position.z >= GameManager.instance.zBound)
            position.z = GameManager.instance.zBound;
        else if (position.z <= -GameManager.instance.zBound)
            position.z = -GameManager.instance.zBound;

    }

    // Triggers on death
    public void DeathTrigger()
    {
        Destroy(gameObject);
        Instantiate(deathEffect, transform.position, transform.rotation);
        GameManager.instance.Lives--;

    }

    // Increases the level of the power-up
    public void IncreaseLevel(string PowerUpType)
    {
        if (PowerUpType == "Bullet")
        {
            BulletLevel += 1;
        } else if (PowerUpType == "Missile")
        {
            MissileLevel += 1;
        }
    }

    // Gets and returns the power-up levels
    public int GetPowerUps(string Type)
    {
        if (Type == "Bullet")
        {
            return BulletLevel;
        }
        else if (Type == "Missile")
        {
            return MissileLevel;
        }
        return 1; // In case it doesn't have the proper value
    }

    // Spawns a homing missile
    public IEnumerator SpawnMissile(int MissileAmount, float Delay)
    {
        for (int missilenum = 0; missilenum < MissileAmount - 1; missilenum++)
        {
            Instantiate(MissileProjectile, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), transform.rotation * Quaternion.Euler(0, 0, Random.Range(-30, 30)));
            yield return new WaitForSeconds(Delay);
        }
    }
}
