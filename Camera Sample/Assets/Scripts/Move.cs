using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed;
    Vector3 camToPos;
    Quaternion camToRot;

    private IFollowTarget _move;
    [SerializeField] private Transform target;

    private void Awake()
    {
        _move = GetComponent<IFollowTarget>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (speed == 0)
            speed = 0.005f;

        camToRot.eulerAngles = new Vector3(10, 0, 0);
        camToPos = new Vector3(0, 0.2f, -0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            KeyPress();
        }
        else
        {
            _move.Follow(target);
        }

        CameraControl.Follow(Camera.main.transform, transform, camToRot, camToPos);
    }

    private void KeyPress()
    {
        //Key control
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(transform.up, -speed * 100, Space.Self);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(transform.up, speed * 100, Space.Self);
        }

    }

}
