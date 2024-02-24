using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private bool fired = false;
    private Vector2 direction;

    public void ShootAt(Transform heliTransform)
    {
        direction = (heliTransform.position - transform.position).normalized;
        fired = true;
    }

    private void Update()
    {
        if (fired) transform.Translate(direction * speed * Time.deltaTime);
        if (!IsVisibleFromCamera())
        {
            Destroy(gameObject);
        }
    }

    private bool IsVisibleFromCamera()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }
}
