using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Vector2 startPosition;
    private bool usingMobileInput;
    private Camera camera;
    public int speed;
    private Animator anim;
    private float horizontalMovement;
    private float verticalMovement;
    private int currentHealth;
    public int maxHealth;
    public Transform attackPoint;
    public float attackRange = 1f;
    public int attackDmg = 15;
    public LayerMask enemyLayers;
    // Start is called before the first frame update
    void Start()
    {
        usingMobileInput = Application.platform == RuntimePlatform.Android ||
                         Application.platform == RuntimePlatform.IPhonePlayer;
        camera = Camera.main;
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
       
        anim.SetFloat("horizontalSpeed", Mathf.Abs(horizontalMovement));
        anim.SetFloat("verticalSpeed", Mathf.Abs(verticalMovement));
        if (usingMobileInput)
            MobileInput();
        else
        KeyboardInput();
    }

   void KeyboardInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        verticalMovement = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        transform.position += new Vector3(horizontalMovement, verticalMovement, 0.0f);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }
    void MobileInput()
    {
        foreach (var touch in Input.touches)
        {
            var destination = camera.ScreenToWorldPoint(touch.position);
            transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime * speed);
        }
    }
    void Attack()
    {
        anim.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.transform.parent.GetComponent<EnemyBehaviour>().TakeDamage(attackDmg);
            Debug.Log("Hit!");
        }
    }
    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
    }
}
