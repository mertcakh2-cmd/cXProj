using MyMAUI.Game;
using MyMAUI.Game.World;

namespace MyMAUI;

public partial class MainPage : ContentPage
{
    private GameSession _session =
        new(LevelCatalog.All[0]);

    private double _lastLookX;
    private double _lastLookY;

    public MainPage()
    {
        InitializeComponent();

        VulkanSurface.StatusChanged += OnVulkanStatusChanged;

        UpdateHud();
    }

    private void OnVulkanStatusChanged(string message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            VulkanStatusLabel.Text = message;
        });
    }

    private void OnSelectLevel(object sender, EventArgs e)
    {
        if (sender is not Button button)
            return;

        string id =
            button.CommandParameter?.ToString() ?? "0-1";

        LevelDefinition level = LevelCatalog.Find(id);

        _session = new GameSession(level);

        LevelTitleLabel.Text =
            $"{level.Id} {level.Name}";

        EnemyLabel.Text = level.EnemyName;

        CombatLogLabel.Text = level.IntroText;

        WelcomePanel.IsVisible = false;

        GamePanel.IsVisible = true;

        UpdateHud();
    }

    private void UpdateHud()
    {
        HealthLabel.Text =
            $"{_session.Player.Health:0} / {_session.Player.MaxHealth:0}";

        HealthBar.Progress =
            _session.Player.Health / _session.Player.MaxHealth;

        StyleLabel.Text = _session.Style.Rank;

        StyleBar.Progress =
            _session.Style.Progress;

        EnemyHealthBar.Progress =
            _session.Enemy.Health /
            _session.Enemy.MaxHealth;

        EnemyLabel.Text = _session.Enemy.IsAlive
            ? _session.Enemy.Name
            : "TARGET DESTROYED";

        KatanaLabel.Text =
            _session.Katana.DisplayName;
    }

    private void OnAttack(object sender, EventArgs e)
    {
        CombatLogLabel.Text =
            _session.Attack(false);

        UpdateHud();
    }

    private void OnHeavyAttack(object sender, EventArgs e)
    {
        CombatLogLabel.Text =
            _session.Attack(true);

        UpdateHud();
    }

    private void OnParry(object sender, EventArgs e)
    {
        CombatLogLabel.Text =
            _session.Parry();

        UpdateHud();
    }

    private void OnDash(object sender, EventArgs e)
    {
        CombatLogLabel.Text =
            _session.Dash();

        UpdateHud();
    }

    private void OnJump(object sender, EventArgs e)
    {
        CombatLogLabel.Text = "JUMP!";
    }

    private void OnChangeVariant(object sender, EventArgs e)
    {
        _session.Katana.NextVariant();

        KatanaLabel.Text =
            _session.Katana.DisplayName;

        CombatLogLabel.Text =
            "KATANA VARIANT CHANGED";

        UpdateHud();
    }

    private void OnMenu(object sender, EventArgs e)
    {
        GamePanel.IsVisible = false;

        WelcomePanel.IsVisible = true;
    }

    private void OnMovePanUpdated(
        object sender,
        PanUpdatedEventArgs e)
    {
        if (e.StatusType == GestureStatus.Running)
        {
            float x = Math.Clamp(
                (float)e.TotalX / 60f,
                -1f,
                1f
            );

            float y = Math.Clamp(
                -(float)e.TotalY / 60f,
                -1f,
                1f
            );

            _session.Motor.SetMovement(x, y);
        }
        else if (
            e.StatusType == GestureStatus.Completed ||
            e.StatusType == GestureStatus.Canceled)
        {
            _session.Motor.SetMovement(0, 0);
        }
    }

    private void OnLookPanUpdated(
        object sender,
        PanUpdatedEventArgs e)
    {
        if (e.StatusType == GestureStatus.Started)
        {
            _lastLookX = 0;
            _lastLookY = 0;
        }
        else if (e.StatusType == GestureStatus.Running)
        {
            double dx = e.TotalX - _lastLookX;
            double dy = e.TotalY - _lastLookY;

            _lastLookX = e.TotalX;
            _lastLookY = e.TotalY;

            _session.Motor.Look(
                (float)dx,
                (float)dy
            );
        }
    }
}
