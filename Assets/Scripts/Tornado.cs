using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado: MonoBehaviour
{
	public AudioClip hitSound;
	[SerializeField]
	Transform rotationCenter;
	AudioSource audioSource;

	[SerializeField]
	float rotationRadius = 2f, angularSpeed = 2f;

	float posX, posY, angle = 0f;

	void Start()
    {
		audioSource = GetComponent<AudioSource>();
	}
	void Update () {
	posX = rotationCenter.position.x + Mathf.Cos (angle) * rotationRadius;
	posY = rotationCenter.position.y + Mathf.Sin (angle) * rotationRadius;
	transform.position = new Vector2 (posX, posY);
	angle = angle + Time.deltaTime * angularSpeed;

	if (angle>= 360f)
		angle = 0f;

	}
    void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController >();

        if (controller != null)
        {
            controller.ChangeHealth(-1);
		PlaySound(hitSound);

        }
    }
	 public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}

