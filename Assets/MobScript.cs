using UnityEngine;

public class MobScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform[] points;
    public float speed = 0.00001f;
    
    private int pointIndex = 0; 

    void Start()
    {
        if (points != null && points.Length > 0)
        {
            transform.position = points[0].position;
        }
    }

    void Update()
    {
        if (this == null) return;
        if (points == null || points.Length == 0) return;

        if (pointIndex >= points.Length)
        {
            Destroy(gameObject);
            return; 
        }

        transform.position = Vector2.MoveTowards(
            transform.position, 
            points[pointIndex].position, 
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, points[pointIndex].position) < 0.1f)
        {
            pointIndex++;
        }
    }
}