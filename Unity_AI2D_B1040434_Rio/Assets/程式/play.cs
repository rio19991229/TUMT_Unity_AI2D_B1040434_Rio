using UnityEngine;                                
using UnityEngine.Events;

public class play : MonoBehaviour
{
    public int speed = 50;                        
    public float jump = 50f;                     
    public string playName = "玩家";               
    public bool pass = false;                     
    public bool isGround;
    [Range(0,200)]
    public float hp = 100;

    public UnityEvent onEat;

    private Rigidbody2D r2d;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) Turn();
        if (Input.GetKeyDown(KeyCode.A)) Turn(180);
    }
    private void FixedUpdate()
    {
        Walk(); 
        Jump();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }
    /// <summary>
    /// 走路
    /// </summary>
    private void Walk()
    {
        r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
    }
    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            r2d.AddForce(new Vector2(0, jump));
        }
    }
    /// <summary>
    /// 轉彎
    /// </summary>
    /// <param name="direction">方向，左轉為 180，右轉為 0</param>
    private void Turn(int direction = 0)
    {
        transform.eulerAngles = new Vector3(0, direction, 0);
    }
/// <summary>
/// 傷害
/// </summary>
/// <param name="damage"></param>
    public void Damage(float damage)
    {
        hp -= damage;
    }
}
