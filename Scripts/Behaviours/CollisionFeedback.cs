using MoreMountains.Feedbacks;
using UnityEngine;

namespace _Game.Scripts.Behaviours
{
    /// <summary>
    /// Plays MMF Feedback when a collision occurs at the collision position
    /// </summary>
    public class CollisionFeedback : MonoBehaviour
    {
        [Header("Feedback Settings")]
        [SerializeField] private MMF_Player collisionFeedback;
        
        [SerializeField] private string filterTag = "";
        
        [SerializeField] 
        [Tooltip("Time in seconds before cleaning up the instantiated feedback")]
        private float cleanupDelay = 5f;

        /// <summary>
        /// Called when a collision occurs
        /// </summary>
        /// <param name="collision">Collision data</param>
        private void OnCollisionEnter(Collision collision)
        {
            // Check if we should filter by tag
            if (!string.IsNullOrEmpty(filterTag) && !collision.gameObject.CompareTag(filterTag))
            {
                return;
            }

            // Play feedback if assigned
            if (collisionFeedback != null && collision.contactCount > 0)
            {
                // Get the first contact point position
                Vector3 collisionPosition = collision.GetContact(0).point;
                
                // Create a temporary GameObject at the collision position to hold the feedback
                GameObject tempFeedbackHolder = new GameObject($"CollisionFeedback_{GetInstanceID()}");
                tempFeedbackHolder.transform.position = collisionPosition;
                
                // Instantiate the feedback at the collision position
                MMF_Player feedbackInstance = Instantiate(collisionFeedback, tempFeedbackHolder.transform);
                feedbackInstance.PlayFeedbacks();
                
                // Destroy the temporary holder after the specified cleanup delay
                Destroy(tempFeedbackHolder, cleanupDelay);
            }
        }
    }
}
