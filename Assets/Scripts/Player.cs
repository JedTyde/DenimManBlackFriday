using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;

    public float gravity = 9.81f * 2f;
    public float jumpForce = 8f;

    public Camera cam;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        
        direction += Vector3.down * gravity * Time.deltaTime;

        if (character.isGrounded) 
        {
            direction = Vector3.down;

            if (Input.GetButton("Jump")) 
            {
                direction = Vector3.up * jumpForce;
            }
        }

        character.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
    }

    private void LateUpdate()
    {
        float posy = transform.position.y;
        //character.enabled = false;
        transform.position = new Vector3(cam.ScreenToWorldPoint(new Vector3(Screen.width / 3, 0, 0)).x, posy, 0);
        //character.enabled = true;
    }
}