using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife Instance;
    private Rigidbody2D rb;
    private Animator anim;
    public GameObject toucherEnemy;
    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(toucherEnemy != null && SceneManager.GetAllScenes().Length == 1)
        {
            Destroy(toucherEnemy);
            toucherEnemy = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (SceneManager.GetAllScenes().Length == 1)
            {
                toucherEnemy = collision.gameObject;
                SceneManager.LoadScene("BattleScene", LoadSceneMode.Additive);
            }
        }
    }
    private void GoBackPriviousScenes()
    {

    }
    public void MakeSingleTon()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
