using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    public float speed = 2f;
    public float rangeX = 45f, rangeZ = 45f;
    private SceneControl sc;
    public ParticleSystem deathParticles;

    Vector3 dir;
    float t;


    void Start()
    {
        PickDirection();
        sc = FindObjectOfType<SceneControl>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > 2f) { PickDirection(); t = 0; }

        transform.position += dir * speed * Time.deltaTime;

        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -rangeX, rangeX);
        pos.z = Mathf.Clamp(pos.z, -rangeZ, rangeZ);
        transform.position = pos;
        transform.rotation = Quaternion.LookRotation(dir);

    }
    void PickDirection()
    {
        dir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }
    public void Kill()
    {
        enabled = false;
        Collider col = GetComponent<Collider>();
        col.enabled = false;
        
        Instantiate(deathParticles, transform.position, Quaternion.identity);

        Destroy(gameObject);
        sc.onSlimeKill();
    }

}
