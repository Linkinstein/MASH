
using UnityEngine;

public class ChopperMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.005f;
    [SerializeField] private float x = 0;
    [SerializeField] private float y = 0;
    [SerializeField] private int maxSpeed = 0;

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, y, 0);
        move = Vector3.ClampMagnitude(move, 1f);

        gameObject.transform.position += (move * speed);
    }
}
