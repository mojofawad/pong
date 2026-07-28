using Godot;

namespace Pong;

public partial class Ball : Area2D
{
	[Export]
	private int Speed { get; set; } = 300;
	
	private Vector2 _velocity = Vector2.Zero;

	public Vector2 ScreenSize;
	
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		Position = ScreenSize / 2;
		
		StartMoving();
	}

	public override void _Process(double delta)
	{
		_velocity *= Speed;

		Position += _velocity * (float)delta;
		Position = new Vector2(
			x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
			y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
		);
	}

	public void OnHit()
	{
		
	}

	private void StartMoving()
	{
		var direction = GD.RandRange(1, 2);

		if (direction == 1)
		{
			_velocity.X -= 1;
		}
		else
		{
			_velocity.X += 1;
		}
	}
}