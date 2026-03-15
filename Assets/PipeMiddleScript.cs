using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        const int BIRD_LAYER = 3;

        if (collision.gameObject.layer == BIRD_LAYER)
        {
            logic.AddScore(1);
        }
    }
}
