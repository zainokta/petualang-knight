using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerScript : MonoBehaviour
{
    public static int healAmount = 15;

    public int playerDmg;
    public int maxHP;
    public int playerHP;

    private Rigidbody2D rb;
    private BoxCollider2D box2D;
    private Vector3 startPos;
    private Vector3 endPos;
    private float dashSpeed = 25f;
    private float recoverySpeed = 5f;
    private float playerSpeed = 2.5f;
    private bool dashRecovery;
    private Animator animator;

	void Start ()
    {
        if (PlayerPrefs.HasKey("Damage"))
        {
            playerDmg = PlayerPrefsManager.GetPlayerDamage();
        }
        else
        {
            PlayerPrefsManager.SetPlayerDamage(100);
            playerDmg = PlayerPrefsManager.GetPlayerDamage();
        }

        if (PlayerPrefs.HasKey("Health"))
        {
            playerHP = PlayerPrefsManager.GetPlayerHealth();
        }
        else
        {
            PlayerPrefsManager.SetPlayerHealth(100);
            playerHP = PlayerPrefsManager.GetPlayerHealth();
        }

        if(!PlayerPrefs.HasKey("Max Health"))
        {
            PlayerPrefsManager.SetPlayerMaxHealth(100);
        }

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        box2D = GetComponent<BoxCollider2D>();
        startPos = transform.position;

        endPos = new Vector3(6, transform.position.y, transform.position.z);
    }

    private Vector2 GetInput()
    {
        Vector2 input = new Vector2
        {
            x = CrossPlatformInputManager.GetAxis("Horizontal"),
            y = CrossPlatformInputManager.GetAxis("Vertical")
        };
        return input;
    }

    void FixedUpdate()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if(sceneName == "LevelSelection")
        {
            Vector2 input = GetInput();
            rb.velocity = new Vector2(input.x * playerSpeed, input.y * playerSpeed);
            if (input.x < 0)
                GetComponent<SpriteRenderer>().flipX = true;
            else if (input.x > 0)
                GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            if (transform.position.x >= endPos.x)
            {
                transform.position = endPos;
                dashRecovery = true;
            }
            DashRecovery();
        }
        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 0.5f, maxScreenBounds.x - 0.5f), Mathf.Clamp(transform.position.y, minScreenBounds.y + 0.5f, maxScreenBounds.y - 0.5f), transform.position.z);
    }

    void DashRecovery()
    {
        if (dashRecovery == true)
        {
            rb.velocity = new Vector2(-recoverySpeed, 0);
            if (transform.position.x <= startPos.x)
            {
                rb.velocity = new Vector2(0, 0);
                dashRecovery = false;
                GameManager.instance.isDashing = false;
                animator.Play("Walk");
            }
        }
    }

    public void Dash()
    {
        if(UIController.instance.dashButton.image.fillAmount == 1)
        {
            rb.velocity = new Vector2(dashSpeed, 0);
            GameManager.instance.isDashing = true;
            UIController.instance.dashButton.image.fillAmount = 0;
            animator.Play("Attack");
        }
    }

    public void Potion()
    {
        if(UIController.instance.potionButton.image.fillAmount == 1)
        {
            Healing(healAmount);
            UIController.instance.potionButton.image.fillAmount = 0;
        }
    }

    public void Healing(int heal)
    {
        if(playerHP < PlayerPrefsManager.GetPlayerMaxHealth())
        {
            playerHP += heal;
            PlayerPrefsManager.SetPlayerHealth(playerHP);
            if (playerHP >= PlayerPrefsManager.GetPlayerMaxHealth())
            {
                playerHP = PlayerPrefsManager.GetPlayerMaxHealth();
                PlayerPrefsManager.SetPlayerHealth(playerHP);
            }
        }
    }

    public void Damaged(int damage)
    {
        playerHP -= damage;
        PlayerPrefsManager.SetPlayerHealth(playerHP);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "NPC")
        {
            box2D.isTrigger = false;
        }
        if (other.tag == "Wall")
        {
            box2D.isTrigger = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "NPC")
        {
            box2D.isTrigger = true;
        }
        if (other.tag == "Wall")
        {
            box2D.isTrigger = true;
        }
    }
}
