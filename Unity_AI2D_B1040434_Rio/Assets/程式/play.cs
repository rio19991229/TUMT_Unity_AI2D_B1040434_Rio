using UnityEngine;                                
using UnityEngine.Events;
using UnityEngine.UI;

public class play : MonoBehaviour
{
    public int speed = 15;
    public float jump = 2.5f;
    public bool pass = false;
    public bool isGround = false;
    public float hp = 100;
    public float playdam = 5;

    public UnityEvent onEat;

    private Rigidbody2D r2d;
    private Transform tra;
    public Animator ani;
    private AudioSource aud;

    public AudioClip candtsound;

    public Image hpBar;
    private float hpmax;

    public GameObject finsh;
    public static play fin;


    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        tra = GetComponent<Transform>();
        aud = GetComponent<AudioSource>();

        hpmax = hp;
        fin = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) Turn(0);
        if (Input.GetKeyDown(KeyCode.A)) Turn(180);
        Attack(); 
    }

    private void FixedUpdate()
    {
        Walk();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
        Debug.Log("碰到" + collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            collision.gameObject.GetComponent<enemy>().EnemyDam(playdam);
        }
        if (collision.tag == "candy")
        {
            Destroy(collision.gameObject);
            npc.count.countCandy += 1;
            aud.PlayOneShot(candtsound, 0.5f);
        }
    }

    void Walk()
    {
        ani.SetBool("走路", Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0);
        r2d.AddForce(new Vector2(speed * (Input.GetAxis("Horizontal")), 0));
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ani.SetTrigger("攻擊");
        }

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            r2d.AddForce(new Vector2(0, jump));
        }
    }

    void Turn(int direction)
    {
        tra.eulerAngles = new Vector3(0, direction, 0);
    }

    public void Damage(float damage)
    {
        hp -= damage;
        hpBar.fillAmount = hp / hpmax;

        if (hp <= 0)
        {
            finsh.SetActive(true);

            Destroy(this);
        }
    }
}
