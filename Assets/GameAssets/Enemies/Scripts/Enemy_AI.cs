using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]

public class Enemy_AI : MonoBehaviour, IEntity
{
    //distance the Enemy can shoot from
    public float attackDistance = 3f;
    //distance in which the enemy recogizes the player and runs toward him
    public float aggroRange = 10;
    public float movementSpeed = 4f;
    public float npcHP = 100;
    public float npcDmg = 10;
    public float attackRate = 0.5f;
    public Transform FirePoint;
    public GameObject npcDeadPrefab;
    public GameObject bulletPrefab;

    private GameObject player;
    private Transform playerTransform;
    private float nextAttackTime = 0;
    
    NavMeshAgent agent;
    Rigidbody r;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = attackDistance;
        agent.speed = movementSpeed;
        r = GetComponent<Rigidbody>();
        r.useGravity = true;
        r.isKinematic = true;
        //looking for Player here
        player = GameObject.Find("CVirtPlayerController");
        playerTransform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(player.transform.position, this.transform.position));
        if (Vector3.Distance(player.transform.position, this.transform.position) < attackDistance)     //((agent.remainingDistance - attackDistance) < 0.01f)
        {
            if (Time.time > nextAttackTime)
            {
                Fire();
                //time till next shot
                nextAttackTime = Time.time + attackRate;
            }
        }

        if (Vector3.Distance(playerTransform.position,transform.position) <= aggroRange) {
            //Move towards player
            agent.destination = playerTransform.position;
            //Look at Player
            transform.LookAt(new Vector3(playerTransform.transform.position.x, transform.position.y, playerTransform.position.z));
        }
    }

    public void ApplyDamage(float points)
    {
        npcHP -= points;
        if (npcHP <= 0)
        {
            //Replace Enemy with DEAD-Prefab and bouice it a little
            GameObject npcDead = Instantiate(npcDeadPrefab, transform.position, transform.rotation);
            npcDead.GetComponent<Rigidbody>().velocity = (-(playerTransform.position - transform.position).normalized * 8) + new Vector3(0, 5, 0);
            Destroy(npcDead, 10);
            Destroy(gameObject);
            GameObject.Find("Killcounter_Hud").GetComponent<killcounter>().updateKill();
        }
    }

    public void Fire()
    {
        GameObject spawnedBullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        Enemy_Bullet bullet = spawnedBullet.GetComponent<Enemy_Bullet>();
        bullet.SetDamage(npcDmg);
    }
}
