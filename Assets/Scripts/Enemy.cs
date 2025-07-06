using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _speed;
    [SerializeField] private DOTweenAnimation _deathAnimation;

    [SerializeField] private GameObject _deathEffect;

    private void Update()
    {
        transform.Translate(Vector2.left * _speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(_deathEffect,transform.position,Quaternion.identity);
            Player.Instance.GetDamage(_damage);
            DestroyEnemy();
        }
        
        if (other.CompareTag("ScoreManager"))
        {
            _deathAnimation.DOPlayForward();
        }   
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}

