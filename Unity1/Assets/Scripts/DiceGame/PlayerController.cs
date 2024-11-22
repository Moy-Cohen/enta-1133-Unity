using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Dictionary<Direction, int> _rotationByDirection = new()
    {
        {Direction.North, 0},
        {Direction.East, 90 },
        {Direction.South, 180 },
        {Direction.West, 270 }
    };
    private Direction _facingDirection;
    private bool _isRotating = false;

    // Smooth rotation
    [SerializeField] private float RotationTime = 0.5f;
    private float _rotationTimer = 0.0f;
    private Quaternion _previousRotation;

    private RoomBase _currentRoom = null;

    // Smooth movement
    [SerializeField] private float MovementTime = 0.5f;
    private bool _isMoving = false;
    private float _movementTimer = 0.0f;
    private Vector3 _previousPosition;
    private Vector3 _moveToPosition;

    public void Setup()
    {
        // Array of all directions
        Direction[] directions = new Direction[] {Direction.North, Direction.East, Direction.South, Direction.West};
        // Get random direction
        _facingDirection = directions[UnityEngine.Random.Range(0, directions.Length)];
        // Update transform value
        SetFacingDirection();
    }

    private void SetFacingDirection()
    {
        // Get the transfor rotation in Euler angles for easier calculation
        Vector3 facing = transform.rotation.eulerAngles;
        // Set the y rotation value
        facing.y = _rotationByDirection[_facingDirection];
        // Save the rotation and convert it back tu quaternions
        transform.rotation = Quaternion.Euler(facing);

    }

    // Update is called once per frame
    void Update()
    {
        if (_isMoving)
        {
            Vector3 currentPosition = Vector3.Slerp(_previousPosition, _moveToPosition, _movementTimer / MovementTime);
            transform.position = currentPosition;
            _movementTimer += Time.deltaTime;

            if (_movementTimer > MovementTime)
            {
                _isMoving = false;
                _movementTimer = 0.0f;
                transform.position = _moveToPosition; // Snap to finish position
            }

        }

        if (_isRotating)
        {
            // Continue movement until it ends
            //Quaternion.Lerp is linear movement, Quaternion.Slerp is smooth movement
            Quaternion currentRotation = Quaternion.Slerp(_previousRotation, Quaternion.Euler(new Vector3(0, _rotationByDirection[_facingDirection])), _rotationTimer / RotationTime);

            transform.rotation = currentRotation;

            _rotationTimer += Time.deltaTime;

            if ( _rotationTimer > RotationTime)
            {
                _isRotating = false;
                _rotationTimer = 0.0f;
                SetFacingDirection();
            }
        }
        else
        {
            // GetKeyDown detects if the key was pressed in that frame
            bool rotateLeft = Input.GetKeyDown(KeyCode.A);
            bool rotateRight = Input.GetKeyDown(KeyCode.D);

            // make sure that only one is true, never both
            if (rotateLeft && !rotateRight)
            {
                TurnLeft();
            }
            else if (rotateRight && !rotateLeft)
            {
                TurnRight();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_currentRoom != null)
                {
                    _currentRoom.OnRoomSearched();
                }
            }
            else if(Input.GetKeyDown(KeyCode.W))
            {
                RoomBase roomInFacingDirection = NextRoomInDirection();
                if (roomInFacingDirection != null)
                {
                    StartMovement(roomInFacingDirection);
                }
            }
            Debug.Log(_facingDirection);
        }
    }

    private void StartMovement(RoomBase targetRoom)
    {
        _previousPosition = transform.position;
        _moveToPosition = new Vector3(targetRoom.transform.position.x, transform.position.y, targetRoom.transform.position.z);
        _isMoving = true;
    }

    private RoomBase NextRoomInDirection()
    {
        
        if (_currentRoom == null)
        {
            return null;
        }
        switch (_facingDirection)
        {
            case Direction.North:
                return _currentRoom.North;

            case Direction.East:
                return _currentRoom.East;

            case Direction.South:
                return _currentRoom.South;

            case Direction.West:
                return _currentRoom.West;
            default:
                Debug.LogError("Error: Unkown Direction");
                return null;
        }
    }

    private void TurnLeft()
    {
        switch (_facingDirection)
        {
            case Direction.North:
                _facingDirection = Direction.West;
                break;
            case Direction.East:
                _facingDirection = Direction.North;
                break;
            case Direction.South:
                _facingDirection = Direction.East;
                break;
            case Direction.West:
                _facingDirection = Direction.South;
                break;
        }

        StartRotating();
    }

    private void TurnRight()
    {
        switch (_facingDirection)
        {
            case Direction.North:
                _facingDirection = Direction.East;
                break;
            case Direction.East:
                _facingDirection = Direction.South;
                break;
            case Direction.South:
                _facingDirection = Direction.West;
                break;
            case Direction.West:
                _facingDirection = Direction.North;
                break;
        }

        StartRotating();
    }

    private void StartRotating()
    {
        _previousRotation = transform.rotation;
        _isRotating = true;
    }

    private void OnTriggerEnter(Collider otherObject)
    {
        _currentRoom = otherObject.GetComponent<RoomBase>();
        _currentRoom.OnRoomEntered();
    }

    private void OnTriggerExit(Collider otherObject)
    {
        RoomBase exitingRoom = otherObject.GetComponent<RoomBase>();
        exitingRoom.OnRoomExited();
    }

}
