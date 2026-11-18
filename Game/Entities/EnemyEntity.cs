namespace MyMAUI.Game.Entities;

public sealed class EnemyEntity
{
    public string Name { get; }

    public float MaxHealth { get; }

    public float Health { get; private set; }

    public bool IsAlive => Health > 0;

    public EnemyEntity(string name, float health)
    {
        Name = name;

        MaxHealth = health;

        Health = health;
    }

    public bool TakeDamage(float amount)
    {
        Health = Math.Max(
            0,
            Health - Math.Max(0, amount)
        );

        return !IsAlive;
    }

    public void Reset()
    {
        Health = MaxHealth;
    }
}
