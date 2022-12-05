using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs
{
    private Player _player;

    private float _verAxis;
    private float _horAxis;
    private string _runButton = "Run";
    private string _jumpButton = "Jump";
    private string _dashButton = "Dash";

    public Inputs(Player player)
    {
        _player = player;
    }

    public void ArtificialUpdate()
    {
        _verAxis = Input.GetAxisRaw("Vertical");
        _horAxis = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown(_jumpButton))
        {
            _player.Jump();
        }

        if (Input.GetButtonDown(_dashButton))
        {
            _player.Dash(_verAxis, _horAxis);
        }

        _player.MoveMe (_verAxis, _horAxis);

        if (Input.GetButton(_runButton))
        {
            _player.Run();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _player.Scream();
        }

    }

    public void ArtificialFixedUpdate()
    {
        _player.FixedMove();
    }
}
