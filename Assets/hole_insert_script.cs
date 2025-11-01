using UnityEngine;

public class hole_insert_script : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        // Called when collision starts
        Debug.Log("Collided with: " + collision.gameObject.name);
        BallShrinker bs = collision.gameObject.GetComponent<BallShrinker>();
        bs.StartShrinking();
    }
}
