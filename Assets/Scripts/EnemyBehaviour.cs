using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private float minimumDistance;
    //[SerializeField]
    //private bool meleeAttacker;

    private float distance;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        var target = GameObject.FindWithTag("Player");
        distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance > minimumDistance)
        {
            anim.SetBool("isAttacking", false);

            transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isAttacking", true);
        }

    }
 
}
