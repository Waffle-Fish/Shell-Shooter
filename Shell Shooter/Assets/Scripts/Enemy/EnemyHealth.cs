using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    float MaxHp;
    float currentHp;

    private void Start() {
        currentHp = MaxHp;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("GameObject2 collided with " + col.name);
    }
    
    // private void Collider2D.OnTriggerEnter2D(Collider2D other) {
    //     Debug.Log(other.name);
    //     if (other.CompareTag("PlayerProjectiles")) {
    //         TakeDamage(other.GetComponent<BasicProjectileBehavior>().DamageVal);
    //     }
    // }

    public void TakeDamage(float val) {
        currentHp -= val;
        if (currentHp < 0) {
            ProcessDeath();
        }
    }

    private void ProcessDeath()
    {
        Debug.Log(gameObject.name + " has died!");
        gameObject.SetActive(false);
    }
}
