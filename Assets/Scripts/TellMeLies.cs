using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TellMeLies : MonoBehaviour
{
    public int liesTold = 0;

    [SerializeField] GameObject nose;
    [SerializeField] Button button;
    
    float xzNoseSize = 0.017f;
    float yNoseSizeScale = 0.02f;
    public float noseCenterCoef = 1.03f;
    public float noseLength = 0;
    float newNoseLength;
    Vector3 nosePosition;
    int noseExtensionClips = 50;

    private void Start()
    {
        nose = gameObject;
        button = GameObject.Find("Button").GetComponent<Button>();
        button.onClick.AddListener(TellLies);
    }

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
