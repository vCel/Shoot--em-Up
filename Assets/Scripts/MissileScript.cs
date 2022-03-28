using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public float Damage = 30f;

    private GameObject Nearest;
    private float MissileSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Nearest = FindClosestEnemy();

        // Rotates to the nearest enemy
        if (Nearest)
        {
            Quaternion Rotate = Quaternion.LookRotation(Nearest.transform.position - transform.position, Vector3.up);
            transform.rotation = Rotate;
            transform.eulerAngles = new Vector3(90, transform.eulerAngles.y, transform.eulerAngles.z);

            transform.Translate(-transform.forward * MissileSpeed * Time.deltaTime);
        }
        transform.Translate(-transform.forward * MissileSpeed * Time.deltaTime);
        Destroy(gameObject, 5f);
    }

    // Activates when hits enemy.
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            if (other.GetComponent<Enemy1>()) { other.GetComponent<Enemy1>().takeDamage(Damage); } else { other.GetComponent<BossScripts>().takeDamage(Damage); }
            Destroy(gameObject);
        }
    }


    // Find the nearest enemy - Taken from the Unity Script References at https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
