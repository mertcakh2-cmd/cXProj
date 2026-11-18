namespace MyMAUI.Game.World;

public sealed record LevelDefinition(
    string Id,
    string Name,
    string Description,
    string IntroText,
    string EnemyName,
    float EnemyHealth
);
