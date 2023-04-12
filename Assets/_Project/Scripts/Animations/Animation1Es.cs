using System.Collections;
using UnityEngine;

public class Animation1Es : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    public float animationSpeed = 1.0f;

    private bool isAnimating = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAnimating)
        {
            StartCoroutine(AnimateCharacter());
        }
    }

    private IEnumerator AnimateCharacter()
    {
        isAnimating = true;

        // ¡Bienvenidos!
        yield return StartCoroutine(TiltHead(20.0f, -20.0f, 1.0f / animationSpeed));
        yield return StartCoroutine(TiltHead(-20.0f, 20.0f, 1.0f / animationSpeed));

        // ¡Soy Frida y te invito a este mágico paseo por Coyoacán!
        yield return StartCoroutine(RaiseHand(leftHand, 0.5f / animationSpeed));
        yield return StartCoroutine(LowerHand(leftHand, 0.5f / animationSpeed));

        // ¿Sabías que su nombre viene del náhuatl y significa "Lugar de Coyotes"?
        yield return StartCoroutine(TiltHead(20.0f, -20.0f, 1.0f / animationSpeed));
        yield return StartCoroutine(TiltHead(-20.0f, 20.0f, 1.0f / animationSpeed));

        // Te invito a descubrir la historia, la cultura y la belleza de este maravilloso lugar.
        yield return StartCoroutine(RaiseHand(rightHand, 0.5f / animationSpeed));
        yield return StartCoroutine(LowerHand(rightHand, 0.5f / animationSpeed));

        // Las fotos de dos páginas contienen Realidad Aumentada para una experiencia más interactiva.
        yield return StartCoroutine(TiltHead(20.0f, -20.0f, 1.0f / animationSpeed));
        yield return StartCoroutine(TiltHead(-20.0f, 20.0f, 1.0f / animationSpeed));

        // ¡Comencemos!
        yield return StartCoroutine(RaiseHand(leftHand, 0.5f / animationSpeed));
        yield return StartCoroutine(RaiseHand(rightHand, 0.5f / animationSpeed));
        yield return StartCoroutine(LowerHand(leftHand, 0.5f / animationSpeed));
        yield return StartCoroutine(LowerHand(rightHand, 0.5f / animationSpeed));

        isAnimating = false;
    }

    private IEnumerator TiltHead(float fromAngle, float toAngle, float duration)
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float angle = Mathf.Lerp(fromAngle, toAngle, elapsedTime / duration);
            head.localRotation = Quaternion.Euler(head.localRotation.eulerAngles.x, head.localRotation.eulerAngles.y, angle);
            yield return null;
        }
    }

    private IEnumerator RaiseHand(Transform hand, float duration)
    {
        float elapsedTime = 0.0f;
        float initialAngle = hand.localRotation.eulerAngles.z;
        float targetAngle = initialAngle - 45.0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float angle = Mathf.Lerp(initialAngle, targetAngle, elapsedTime / duration);
            hand.localRotation = Quaternion.Euler(hand.localRotation.eulerAngles.x, hand.localRotation.eulerAngles.y, angle);
            yield return null;
        }
    }

    private IEnumerator LowerHand(Transform hand, float duration)
    {
        float elapsedTime = 0.0f;
        float initialAngle = hand.localRotation.eulerAngles.z;
        float targetAngle = initialAngle + 45.0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float angle = Mathf.Lerp(initialAngle, targetAngle, elapsedTime / duration);
            hand.localRotation = Quaternion.Euler(hand.localRotation.eulerAngles.x, hand.localRotation.eulerAngles.y, angle);
            yield return null;
        }
    }
}