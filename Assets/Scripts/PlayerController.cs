using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public Vector2 dirVector;
    private Vector2 movement;
    private Rigidbody2D rd2d;
    public static PlayerController instance;

    public int speed;
    public float maxSpeed;

    bool isUnBeatTime = false;
    public bool isCollide = false;

    public int CoinNum = 0;
    public int PotionNum = 0;
    public int CharmNum = 0;

    void Start()
	{
		rd2d = GetComponent<Rigidbody2D> ();
		movement = Vector2.zero;

	}
		
	void FixedUpdate()
	{
        float h = joystick.GetHorizontalValue();
        float v = joystick.GetVerticalValue();

        movement.x = Mathf.Clamp(h, -maxSpeed, maxSpeed);
        movement.y = Mathf.Clamp(v, -maxSpeed, maxSpeed);

        if(movement.x != 0 && movement.y != 0)
        {
            dirVector = movement;
        }

        transform.eulerAngles = new Vector3(0, 0, -(Mathf.Atan2(dirVector.x, dirVector.y) * Mathf.Rad2Deg));
        

        rd2d.AddForce (movement * speed);
	}
}