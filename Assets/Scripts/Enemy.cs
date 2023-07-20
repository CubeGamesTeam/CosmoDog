using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float speed;
    [SerializeField] private DOTweenAnimation deathAnimation;

    private void Update()
    {
        transform.Translate(Vector2.left * speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
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
