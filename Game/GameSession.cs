using MyMAUI.Game.Combat;
using MyMAUI.Game.Entities;
using MyMAUI.Game.World;
using MyMAUI.Engine.Input;

namespace MyMAUI.Game;

public sealed class GameSession
{
    public PlayerStats Player { get; } = new();

    public StyleMeter Style { get; } = new();

    public KatanaController Katana { get; } = new();

    public PlayerMotor Motor { get; } = new();

    public LevelDefinition CurrentLevel { get; }

    public EnemyEntity Enemy { get; }

    public GameSession(LevelDefinition level)
    {
        CurrentLevel = level;

        Enemy = new EnemyEntity(
            level.EnemyName,
            level.EnemyHealth
        );
    }

    public string Attack(bool heavy)
    {
        if (!Enemy.IsAlive)
            return "TARGET ELIMINATED";

        float damage = Katana.Damage(heavy);

        bool killed = Enemy.TakeDamage(damage);

        Player.Heal(
            Katana.BloodHealing(heavy)
        );

        Style.AddPoints(heavy ? 110 : 55);

        if (killed)
            Style.AddPoints(180);

        return killed
            ? $"{Enemy.Name} DESTROYED!"
            : $"{(heavy ? "HEAVY SLASH" : "KATANA HIT")} - {damage} DAMAGE";
    }

    public string Parry()
    {
        Style.AddPoints(110);

        Player.Heal(2);

        return "PARRY! +110 STYLE";
    }

    public string Dash()
    {
        Motor.Dash();

        Style.AddPoints(30);

        return "DASH!";
    }
}
