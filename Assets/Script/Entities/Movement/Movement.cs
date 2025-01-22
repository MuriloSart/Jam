using UnityEngine;


namespace Entities.Movement
{
    public enum Direction
    {
        Right,
        Left
    }

    public class Movement : MonoBehaviour
    {
        private Vector2 _currentDirection = Vector2.right;

        public void GetDirectionVector(Direction direction)
        {
            _currentDirection = direction switch
            {
                Direction.Right => Vector2.right,
                Direction.Left => Vector2.left,
                _ => Vector2.zero
            };
        }
    }
}