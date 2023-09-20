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
        private void Awake()
        {
            _input = GetComponent<SwerveInput>();
        }
        private void Update()
        {
            if (transform.position.x <= -2f)
            {
                transform.position = new Vector3(-2f, 0, 0);
            }

            if (transform.position.x >= 2f)
            {
                transform.position = new Vector3(2f, 0, 0);
            }

            float swerveAmount = Time.deltaTime * swerveSpeed *  _input.MoveFactorX;
            swerveAmount = Mathf.Clamp(swerveAmount,-maxSwerveAmount, maxSwerveAmount);
            transform.Translate(swerveAmount, 0, 0);
        }
    }
}
