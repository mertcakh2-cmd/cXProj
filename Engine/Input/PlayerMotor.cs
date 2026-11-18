using System.Numerics;

namespace MyMAUI.Engine.Input;

public sealed class PlayerMotor
{
    public Vector3 Position { get; private set; }

    public float YawDegrees { get; private set; }

    public float PitchDegrees { get; private set; }

    public Vector2 MovementInput { get; private set; }

    public float MoveSpeed { get; set; } = 6.5f;

    public void SetMovement(float x, float y)
    {
        MovementInput = new Vector2(
            Math.Clamp(x, -1f, 1f),
            Math.Clamp(y, -1f, 1f)
        );

        if (MovementInput.LengthSquared() > 1)
            MovementInput = Vector2.Normalize(MovementInput);
    }

    public void Look(float deltaX, float deltaY)
    {
        YawDegrees += deltaX * 0.18f;

        PitchDegrees = Math.Clamp(
            PitchDegrees + deltaY * 0.18f,
            -85,
            85
        );
    }

    public void Simulate(float deltaTime)
    {
        float yaw = YawDegrees *
            (MathF.PI / 180f);

        Vector3 forward = new(
            MathF.Sin(yaw),
            0,
            MathF.Cos(yaw)
        );

        Vector3 right = new(
            forward.Z,
            0,
            -forward.X
        );

        Vector3 direction =
            forward * MovementInput.Y +
            right * MovementInput.X;

        Position += direction *
            MoveSpeed *
            deltaTime;
    }

    public void Dash()
    {
        float yaw = YawDegrees *
            (MathF.PI / 180f);

        Position += new Vector3(
            MathF.Sin(yaw),
            0,
            MathF.Cos(yaw)
        ) * 2.5f;
    }
}
