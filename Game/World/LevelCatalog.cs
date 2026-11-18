namespace MyMAUI.Game.World;

public static class LevelCatalog
{
    public static readonly IReadOnlyList<LevelDefinition> All =
        new List<LevelDefinition>
        {
            new(
                "0-1",
                "SACRED KNIGHT",
                "Your journey begins.",
                "You emerge from the darkness. A Katana awaits.",
                "SACRED SENTINEL",
                160
            ),

            new(
                "0-2",
                "BLOODYHELL",
                "A world consumed by blood.",
                "The ground is soaked. Something is watching.",
                "BLOOD HOST",
                220
            ),

            new(
                "0-3",
                "ESCAPE",
                "The false escape.",
                "You thought it was over. Hell disagrees.",
                "HOLLOW PURSUER",
                260
            ),

            new(
                "0-4",
                "PATHGRINDER",
                "The entrance to Hell.",
                "Something enormous guards the entrance.",
                "PATHGRINDER GUARDIAN",
                1000
            ),

            new(
                "1-1",
                "MY OWN MY KIND",
                "Another machine stands before you.",
                "You are not the only one.",
                "US - MIRROR MACHINE",
                800
            )
        };

    public static LevelDefinition Find(string id)
    {
        return All.FirstOrDefault(
            level => level.Id == id
        ) ?? All[0];
    }
}
