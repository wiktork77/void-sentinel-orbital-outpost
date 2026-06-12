using UnityEngine;

public class SpreadProjectileScript : ProjectileScript
{
    private bool hasHit = false;

    protected override void Update()
    {
        // Bezpieczne sprawdzanie bazy (na wypadek gdyby speed uległ zmianie)
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasHit) return;

        EnemyScript hitEnemy = other.GetComponent<EnemyScript>();

        if (hitEnemy != null)
        {
            hasHit = true;

            // 1. Zadajemy obrażenia temu, w kogo uderzyliśmy
            hitEnemy.TakeDamage(damage, owner); 

            // 2. Pobieramy efekty bezpośrednio z wieży lub przekazujemy je do FAKTYCZNEGO wroga
            // Szukamy komponentu wieży, która nas stworzyła (jeśli masz taką referencję)
            // ZAMIAST OnHit?.Invoke(), nakładamy efekty na hitEnemy, jeśli Twój system na to pozwala:
            
            // UWAGA: Aby nie wywoływać zepsutego OnHit, możemy bezpiecznie odpytać 
            // czy hitEnemy nadal istnieje przed nałożeniem jakichkolwiek dodatkowych modyfikatorów.
            
            // 3. Niszczymy ten pocisk
            Destroy(gameObject);
        }
    }
}