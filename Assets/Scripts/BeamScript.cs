using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamScript : MonoBehaviour
{
    SpriteRenderer BeamSprite;

    public float lifeTime = 2f;
    public float velocity = 400f;
    public float Damage = 10f;

    public Sprite[] sprites = new Sprite[3];

    // Start is called before the first frame update
    void Start()
    {
        BeamSprite = GetComponent<SpriteRenderer>();
        newSprite();
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime * transform.up;
        if (transform.position.z >= GameManager.instance.zBound + 10)
        {
            Destroy(gameObject);
        }
    }

    // Random sprite when fired
    private void newSprite()
    {
        int ranNum = Random.Range(1, 4);
        BeamSprite.sprite = sprites[ranNum - 1];
    }

    // When it touches the enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy" && other.GetComponent<Enemy1>())
        {
            other.GetComponent<Enemy1>().takeDamage(Damage);
            Destroy(gameObject);
        } else if (other.transform.tag == "Enemy" && other.GetComponent<BossScripts>())
        {
            other.GetComponent<BossScripts>().takeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
