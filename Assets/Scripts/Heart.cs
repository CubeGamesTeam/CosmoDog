using DG.Tweening;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float speed;
    [SerializeField] private DOTweenAnimation deathAnimation;

    [SerializeField] private GameObject deathEffect;

    private void Update()
    {
        transform.Translate(Vector2.left * speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(deathEffect,transform.position,Quaternion.identity);
            Player.Instance.GetDamage(damage);
            DestroyEnemy();
        }
        
        if (other.CompareTag("ScoreManager"))
        {
            deathAnimation.DOPlayForward();
        }
        
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    


}
