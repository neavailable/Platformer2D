using UnityEngine;


namespace Background
{
    public class MoveBackground : MonoBehaviour
    {
        private Transform _backgroundLeft, _backgroundRight, _playerTransform;
        private float _leftBorder, _rightBorder;
        private float _bottomRightX, _bottomLeftX, _size;
        

        public void Constructor
        (
            Transform backgroundLeft, 
            Transform backgroundRight,
            Transform playerTransform
        )
        {
            _backgroundLeft = backgroundLeft;
            _backgroundRight = backgroundRight;
            _playerTransform = playerTransform;
            
            _leftBorder = 2.5f;
            _rightBorder = 5f;
            _size = _backgroundRight.GetComponent<SpriteRenderer>().bounds.size.x;
        }

        private void ChangeBackgroundPosition()
        {
            _backgroundLeft.position = new Vector2
            (
                _leftBorder,
                _backgroundRight.position.y
            );
            _backgroundRight.position = new Vector2
            (
                _rightBorder,
                _backgroundRight.position.y
            );
        }

        // left_border and right_border are like box where player are locating
        // when player across left_border or right_border two images relocate by their size
        // borders relocate by size also
        private void Move()
        {
            if (_playerTransform.position.x > _rightBorder)
            {
                _rightBorder += _size;
                _leftBorder = _rightBorder - _size;

                ChangeBackgroundPosition();
            }

            else if (_playerTransform.position.x <= _leftBorder)
            {
                _leftBorder -= _size;
                _rightBorder = _leftBorder + _size;

                ChangeBackgroundPosition();
            }
        }

        private void Update()
        {
            Move();
        }
    }
} 