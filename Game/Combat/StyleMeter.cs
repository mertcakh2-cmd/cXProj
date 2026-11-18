namespace MyMAUI.Game.Combat;

public sealed class StyleMeter
{
    public int Score { get; private set; }

    public double Progress => Score / 1000.0;

    public string Rank
    {
        get
        {
            if (Score >= 850) return "SSADISTIC";
            if (Score >= 700) return "SUPREME";
            if (Score >= 520) return "ANARCHIC";
            if (Score >= 350) return "BRUTAL";
            if (Score >= 180) return "CHAOTIC";

            return "DESTRUCTIVE";
        }
    }

    public void AddPoints(int points)
    {
        Score = Math.Clamp(Score + Math.Max(0, points), 0, 1000);
    }

    public void Reset()
    {
        Score = 0;
    }
}
