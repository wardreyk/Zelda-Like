using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_EnemyController : MonoBehaviour
{
    private Animator animator;
    private Transform target;
    
    public Transform hompos;

    [SerializeField]
    private float speed;
    
    [SerializeField]
    private float maxRange;
    
    [SerializeField]
    private float minRange;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = FindObjectOfType<BAB_PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position)>= minRange)
        {
            FollowPlayer();
        }
        else if (Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            GoHome();
        }
    }

    public void FollowPlayer()
    {
        animator.SetBool("isMoving", true);
        animator.SetFloat("moveX", (target.position.x - transform.position.x));
        animator.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void GoHome()
    {
        animator.SetFloat("moveX", (hompos.position.x - transform.position.x));
        animator.SetFloat("moveY", (hompos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, hompos.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, hompos.position) == 0)
        {
            animator.SetBool("isMoving", false);
        }
    }
}
