    using UnityEngine;

public class ParamedicCatcher : MonoBehaviour
{   
    public int Speed { get; set; }

    public Movement movement { get; private set; }

    public Joystick joystick;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || joystick.Vertical >= .2f)
        {
            movement.SetDirection(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || joystick.Vertical <= -.2f)
        {
            movement.SetDirection(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || joystick.Horizontal <= -.2f)
        {
            movement.SetDirection(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || joystick.Horizontal >= .2f)
        {
            movement.SetDirection(Vector2.right);
        }

        float angle = Mathf.Atan2(movement.direction.x, movement.direction.y);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    public void ResetState()
    {
        gameObject.SetActive(true);
        movement.ResetState();
    }
}
