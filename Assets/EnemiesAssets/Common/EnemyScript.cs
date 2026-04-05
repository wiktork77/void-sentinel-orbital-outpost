using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    protected Animator animator;
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("move");
    }

    protected virtual void Update()
    {
        
    }
}
