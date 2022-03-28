using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeam : MonoBehaviour
{

    public float lifeTime = 4.0f;
    public float velocity = 400f;
    public float Damage = 10f;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime * transform.up;
    }

    // Hits player
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && !other.transform.GetComponent<PlayerScript>().isInvincible && !other.transform.GetComponent<PlayerScript>().isDamaged)
        {
            other.transform.GetComponent<PlayerScript>().isDamaged = true; 
            other.transform.GetComponent<PlayerScript>().DeathTrigger();
            Destroy(gameObject);
        }
    }
}
