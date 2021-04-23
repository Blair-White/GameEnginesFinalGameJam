using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//This Script is copied directly from character.move on unity website.
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField]
    private bool groundedPlayer;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    private InputManager inputManager;
    private Transform cameraTransform;
    public bool zip, isZipping;
    public GameObject endZip;
    private Vector3 endZipPos;

    //talent bools
    private void Start()
    {

        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
        endZipPos = endZip.transform.position; 
    }


    void Update()
    {

        if (isZipping)
        {
            transform.position = Vector3.MoveTowards(transform.position, endZipPos, 0.05f);

            return;
        }

        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        controller.Move(move * Time.deltaTime * playerSpeed);
        if (inputManager.PlayerJumped() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


    }

 
    private void pickupjump()
    {
        jumpHeight = 8;
    }

    private void pickupzip()
    {
        zip = true;
    }

    private void usezip()
    {
        isZipping = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "EndGamePortal")
        {
            other.SendMessage("Entered");
        }
    }
}
