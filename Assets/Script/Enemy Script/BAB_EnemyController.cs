using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAB_EnemyController : MonoBehaviour
{
    private Animator animator;
    private Transform target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float range;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = FindObjectOfType<BAB_PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        animator.SetBool("isMoving", true);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

}
