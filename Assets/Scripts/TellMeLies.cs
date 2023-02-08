using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TellMeLies : MonoBehaviour
{
    [SerializeField] GameObject nose;
    public int liesTold = 0;

    float xzNoseSize = 0.017f;
    float yNoseSizeScale = 0.02f;
    public float noseCenterCoef = 1.03f;
    public float noseLength = 0;
    float newNoseLength;
    Vector3 nosePosition;
    int noseExtensionClips = 50;

    public void TellLies()
    {
        liesTold++;
        newNoseLength = yNoseSizeScale * liesTold;
        noseLength += yNoseSizeScale / noseExtensionClips;
        UpdateNose();

        //for (int i = 0; i < noseExtensionClips; i++)
        //{
        //    noseLength += yNoseSizeScale / noseExtensionClips;
        //    UpdateNose();
        //}

        //noseLength = newNoseLength;
        //UpdateNose();
    }

    void UpdateNose()
    {
        nose.gameObject.transform.localScale = new Vector3(xzNoseSize, noseLength, xzNoseSize);
        nosePosition = nose.transform.position;
        nosePosition -= new Vector3(0, 0, yNoseSizeScale / noseExtensionClips / noseCenterCoef);
        nose.transform.position = nosePosition;
        StartCoroutine(ExtendNose());
    }

    IEnumerator ExtendNose()
    {
        Debug.Log("tu jestem");
        yield return new WaitForSeconds(2 / noseExtensionClips);
        Debug.Log("tu jestem2");
        if (noseLength < newNoseLength)
        {
            noseLength += yNoseSizeScale / noseExtensionClips;
            UpdateNose();
            Debug.Log("tu jestem3");
        }
    }
}
