using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wait : MonoBehaviour
{
    public float waitTime = 26f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForIntro());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForIntro() {
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(sceneBuildIndex:0);
    }
}
