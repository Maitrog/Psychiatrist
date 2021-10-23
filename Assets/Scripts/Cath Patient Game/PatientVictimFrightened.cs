using UnityEngine;

public class PatientVictimFrightened : PatientVictimBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        Node node = collision.GetComponent<Node>();
        if (node != null && enabled)
        {
            Vector2 direction = Vector2.zero;
            float maxDistance = float.MinValue;

            foreach(Vector2 availableDirection in node.availableDirections)
            {
                Vector3 newPosition = this.transform.position + new Vector3(availableDirection.x, availableDirection.y);
                float distance = (patientVictim.target.position - newPosition).sqrMagnitude;

                if(distance > maxDistance)
                {
                    direction = availableDirection;
                    maxDistance = distance;
                }
            }
            patientVictim.movement.SetDirection(direction);
        }
    }
}
