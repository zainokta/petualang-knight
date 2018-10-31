using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour {
    private Rigidbody2D rb;
    private BoxCollider2D box2D;
    private Vector3 knockback;
    private int damage = 10;
    private int randomGold;
    private int goldDrop;
    private int moonStoneDrop;
    private int playerGold;
    private int playerMoonStone;
    private GameObject particle;

    public int enemyHp = 100;

    void Start ()
    {
        particle = Resources.Load("Particle System") as GameObject;
        knockback = new Vector3(8000, 0, 0);
        playerGold = PlayerPrefsManager.GetPlayerGold();
        playerMoonStone = PlayerPrefsManager.GetPlayerMoonStone();
        rb = GetComponent<Rigidbody2D>();
        box2D = GetComponent<BoxCollider2D>();
	}

    private void Update()
    {
        Debug.Log("enemy hp = " + enemyHp);
        randomGold = Random.Range(100, 300);
        HealthPointCheck();
        GoldDrop();
        MoonStoneDrop();
    }

    void FixedUpdate ()
    {
        rb.velocity = new Vector2(-4, 0);
	}

    void HealthPointCheck()
    {
        if (enemyHp <= 0)
        {
            goldDrop = Random.Range(1, 5);
            moonStoneDrop = Random.Range(1, 20);
            Destroy(gameObject);
        }
    }

    void GoldDrop()
    {
        if (goldDrop == 3)
        {
            Debug.Log(randomGold + " Gold received");
            playerGold += randomGold;
            PlayerPrefsManager.SetPlayerGold(playerGold);
            goldDrop = 0;
        }
    }
    
    void MoonStoneDrop()
    {
        if (moonStoneDrop == 5)
        {
            Debug.Log("Moon stone received");
            playerMoonStone++;
            PlayerPrefsManager.SetPlayerMoonStone(playerMoonStone);
            moonStoneDrop = 0;
        }
    }

    void EnemyDamaged(int damage)
    {
        enemyHp -= damage;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            box2D.isTrigger = true;
            rb.gravityScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && GameManager.instance.isDashing == true)
        {
            GameManager.instance.PlayAudio(GameManager.instance.clip);
            EnemyDamaged(enemyHp);
        }
        if(other.tag == "Player" && GameManager.instance.isDashing == false)
        {
            particle = Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(particle, 1f);
            GameManager.instance.PlayAudio(GameManager.instance.clip);
            EnemyDamaged(PlayerPrefsManager.GetPlayerDamage()/2);
            FindObjectOfType<PlayerScript>().Damaged(damage);
            rb.AddForce(knockback);
        }
    }
}
