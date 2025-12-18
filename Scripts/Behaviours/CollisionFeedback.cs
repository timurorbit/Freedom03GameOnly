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
        [SerializeField]
        [Tooltip("The MMF Player feedback to play on collision")]
        private MMF_Player collisionFeedback;

        [SerializeField]
        [Tooltip("Optional tag filter - only trigger on objects with this tag. Leave empty to trigger on any collision.")]
        private string filterTag = "";

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
                
                // Play the feedback at the collision position
                collisionFeedback.transform.position = collisionPosition;
                collisionFeedback.PlayFeedbacks();
            }
        }
    }
}
