using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Shooter))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Shooter shooter;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");
        bool isJumpBtnPressed = Input.GetButtonDown("Jump");

        playerMovement.MovePlayer(horizontalDirection, isJumpBtnPressed);

        if(Input.GetButtonDown("Fire1"))
            shooter.Shoot(horizontalDirection);
    }
}
