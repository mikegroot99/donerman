using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

	[SerializeField] private string MouseX, MouseY;
	[SerializeField] private float mouseSensitivity;

	[SerializeField] private Transform playerBody;

	private float xAxisClamp;

		private void Awake()
		{
			lockCursor();
			xAxisClamp = 0.0f;
		}

		private void lockCursor()
		{
				Cursor.lockState = CursorLockMode.Locked;
		}

		private void Update()
		{
			CameraRotation();
		}

		private void CameraRotation()
		{
			float mouseX = Input.GetAxis(MouseX) * mouseSensitivity * Time.deltaTime;
			float mouseY = Input.GetAxis(MouseY) * mouseSensitivity * Time.deltaTime;

			xAxisClamp += mouseY;

			if (xAxisClamp > 90.0f)
			{
				xAxisClamp = 90.0f;
				mouseY = 0.0f;
				ClampXAxisRotToVal(270.0f);
			}

			else if (xAxisClamp < -90.0f)
			{
				xAxisClamp = -90.0f;
				mouseY = 0.0f;
			  ClampXAxisRotToVal(90.0f);
			}
			transform.Rotate(Vector3.left * mouseY);
			playerBody.Rotate(Vector3.up * mouseX);
		}
			private void ClampXAxisRotToVal(float value)
			{
				Vector3 eulerRotation = transform.eulerAngles;
				eulerRotation.x = value;
				transform.eulerAngles = eulerRotation;
			}
}
