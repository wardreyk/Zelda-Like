using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class FunctionPathFinding : MonoBehaviour
{
    public Transform player;
    [SerializeField]
    public NavMeshPath pathent;

    Vector2 pCDirection;

    public NavMeshAgent agent;

    float timer;

   public float wanderingTime;
    public float shootTime;
    public float followTime;

    public float curWanderingTime;
    public float curShootTime;
    public float curFollowTime;

    Vector2 minMaxWanderTimer = new Vector2(5f, 8f);
    public float speed;
    public float followingSpeed;
    public float accelerationSpeed;
    public float bulletForce;

    public float shootDistance;

    public float shootIntervale;

    public float wanderingRadius;

    public GameObject bulletPrefab;
    public Transform[] firePoint;

    public float playerDetectionDistance;

    public float minimumRange;
    public float maximumRange;
    public void FollowPlayer()
    {
       agent.SetDestination(player.position);
        

    }

    public void DoShoot()
    {
        StopCoroutine(nameof(ShootInvervalle));

        pCDirection = (player.transform.position - transform.position).normalized * bulletForce;

        curShootTime =+ Time.deltaTime;
        if (curShootTime >= shootTime)
        {
            for (int i = 0; i < firePoint.Length; i++)
            {
                GameObject fireBullet = Instantiate(bulletPrefab, firePoint[i].position, firePoint[i].rotation);
                fireBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(pCDirection.x, pCDirection.y);
            }
        }   
        DontShoot();

    }

    void DontShoot()
    {
     
        StartCoroutine(nameof(ShootInvervalle));
    }

    IEnumerator ShootInvervalle()
    {
        yield return new WaitForSeconds(shootIntervale);
        DoShoot();
    }

    public void Wander()
    {
        timer += Time.deltaTime;

        if (timer >= curWanderingTime)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderingRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;

            curWanderingTime = Random.Range(minMaxWanderTimer.x, minMaxWanderTimer.y);
        }


    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection = new Vector3(randDirection.x, randDirection.y, 0f);

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    
    public bool playerInSight()
    {
        Vector2 direction = player.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction, playerDetectionDistance);
        Debug.DrawRay(transform.position, direction.normalized * playerDetectionDistance, Color.red);
        Debug.Log("playerInSightActivé");

        //print(hit.collider.gameObject.name);
        if (hit.collider != null)
        {
            Debug.Log("Joueur Détécté");
            return hit.collider.gameObject.CompareTag("Player");
            
        }
        else
        {
            Debug.Log("Joueur Non Détécté");
            return false;
          
        }
    }
    public bool isPlayerInDetectionRange(NavMeshPath path)
    {
        //return Vector2.Distance(transform.position, player.position + Vector3.up) < enemyBehaviorSO.playerDetectionDistance;
        float dist = 0f;
        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            dist += Vector3.Distance(path.corners[i], path.corners[i + 1]);
        }

        return dist < playerDetectionDistance;

    }

    public float playerDistance(NavMeshPath path)
    {
        //return Vector2.Distance(transform.position, player.position + Vector3.up);

        float dist = 0f;
        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            dist += Vector2.Distance(path.corners[i], path.corners[i + 1]);
        }

        return dist;
    }
}
