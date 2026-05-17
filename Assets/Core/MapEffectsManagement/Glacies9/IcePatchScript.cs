using UnityEngine;

public class IcePatchScript : MonoBehaviour, IEffectApplier<EnemyScript>
{

    public MovementSpeedBuffEffect icePatchBuff;

    public void SendEffect(Effect<EnemyScript> effect, EnemyScript receiver)
    {
        receiver.ApplyEffect(effect);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        IceCrawlerEnemyScript enemy = collision.GetComponent<IceCrawlerEnemyScript>();

        if (enemy != null)
        {
            Debug.Log("Sending Effect");
            SendEffect(icePatchBuff, enemy);
        }
    }
}
