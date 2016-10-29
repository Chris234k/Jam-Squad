using UnityEngine;
using System.Collections;

public class LazerWallObstacle : Obstacle
{
    public GameObject nodeA;
    public GameObject nodeB;
    public TrailRenderer lazer;

    public float spawnRadius;
    float coolDown;

    void Start()
    {
        WasSpawned(null);
    }

    public override void WasSpawned(Spawner spawner)
    {
        nodeA.transform.position = GetPointInSphere(spawnRadius, transform.position);
        nodeB.transform.position = GetPointInSphere(spawnRadius, transform.position);

        // Prevent trail from drawing while adjusting to the spawn pos
        lazer.enabled = false;
        lazer.transform.position = nodeA.transform.position;
        lazer.enabled = true;

        coolDown = Random.Range(1f, 3f);
        InvokeRepeating("Lazer", coolDown, coolDown);

        int doubleInvoke = Random.Range(0, 3);
        if(doubleInvoke == 1)
        {
            coolDown = Random.Range(1f, 3f);
            InvokeRepeating("Lazer", coolDown, coolDown);
        }
    }

    void Lazer()
    {
        lazer.transform.position = nodeA.transform.position;
        LeanTween.move(lazer.gameObject, nodeB.transform.position, 0.2f).setEase(LeanTweenType.easeInCubic);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}