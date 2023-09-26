using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Inputs
{
    public class SwerveMovement : MonoBehaviour
    {
        private SwerveInput _input;
        [SerializeField]
        private float swerveSpeed = 0.5f;
        [SerializeField]
        private float maxSwerveAmount = 1f;
        private Vector3 leftWall;
        private Vector3 rightWall;
        private void Awake()
        {
            _input = GetComponent<SwerveInput>();
        }
        private void Start()
        {
            leftWall = new Vector3(-2f, 0, 0);
            rightWall = new Vector3(2f, 0, 0);
        }
        private void Update()
        {
            if (transform.position.x <= -2f)
            {
                transform.position = leftWall;
            }

            if (transform.position.x >= 2f)
            {
                transform.position = rightWall;
            }

            float swerveAmount = Time.deltaTime * swerveSpeed *  _input.MoveFactorX;
            swerveAmount = Mathf.Clamp(swerveAmount,-maxSwerveAmount, maxSwerveAmount);
            transform.Translate(swerveAmount, 0, 0);


        }
    }
}
