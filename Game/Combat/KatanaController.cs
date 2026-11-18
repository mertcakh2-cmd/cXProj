namespace MyMAUI.Game.Combat;

public sealed class KatanaController
{
    private readonly KatanaVariant[] _variants =
        Enum.GetValues<KatanaVariant>();

    public KatanaVariant ActiveVariant { get; private set; }
        = KatanaVariant.Standard;

    public string DisplayName => ActiveVariant switch
    {
        KatanaVariant.Standard => "STANDARD KATANA",
        KatanaVariant.Blood => "BLOOD KATANA",
        KatanaVariant.Heavy => "HEAVY KATANA",
        KatanaVariant.Phantom => "PHANTOM KATANA",
        KatanaVariant.Sacred => "SACRED KATANA",
        _ => "UNKNOWN"
    };

    public float Damage(bool heavy)
    {
        return (ActiveVariant, heavy) switch
        {
            (KatanaVariant.Standard, false) => 25,
            (KatanaVariant.Standard, true) => 45,

            (KatanaVariant.Blood, false) => 20,
            (KatanaVariant.Blood, true) => 38,

            (KatanaVariant.Heavy, false) => 40,
            (KatanaVariant.Heavy, true) => 75,

            (KatanaVariant.Phantom, false) => 18,
            (KatanaVariant.Phantom, true) => 32,

            (KatanaVariant.Sacred, false) => 35,
            (KatanaVariant.Sacred, true) => 65,

            _ => 20
        };
    }

    public float BloodHealing(bool heavy)
    {
        if (ActiveVariant != KatanaVariant.Blood)
            return 0;

        return heavy ? 9 : 4;
    }

    public void NextVariant()
    {
        int index = Array.IndexOf(
            _variants,
            ActiveVariant
        );

        index = (index + 1) % _variants.Length;

        ActiveVariant = _variants[index];
    }
}
