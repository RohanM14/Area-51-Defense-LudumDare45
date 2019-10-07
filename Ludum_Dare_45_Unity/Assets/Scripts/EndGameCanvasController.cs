using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCanvasController : MonoBehaviour
{
    public IEnumerator endGame(bool won)
    {
        if (won)
        {
            StartCoroutine(GlideIn(transform.Find("WinScreen").gameObject, 1));
            yield return null;
        }
        else
        {
            StartCoroutine(GlideIn(transform.Find("LoseScreen").gameObject, -1));
            yield return null;
        }
    }
    private IEnumerator GlideIn(GameObject screen, int direction)
    {
        RectTransform rectT = screen.GetComponent<RectTransform>();
        while (rectT.localPosition.y != 0f)
        {
            rectT.localPosition = Vector3.Lerp(rectT.localPosition, new Vector3(0, 0, 0),0.1f);
            if(direction ==1)
            {
                if (rectT.localPosition.y >= -10) rectT.localPosition = new Vector3(0, 0, 0);
            }
            else
            {
                if (rectT.localPosition.y <= 10) rectT.localPosition = new Vector3(0, 0, 0);
            }
            yield return null;
        }
    }
}
