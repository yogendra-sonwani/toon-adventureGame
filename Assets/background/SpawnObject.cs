using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject boulderPreFab;
    public float respawnTime = 0.01f;
    private Vector2 screenBounds;
    public static bool spawn = false;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(boulders());
    }

    private void spawnEnemy(){
        GameObject a = Instantiate(boulderPreFab) as GameObject;
        a.transform.position = new Vector2(0.0f, 71.1f);
        // a.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator boulders(){
        while(spawn)
        {
            // spawn = false;
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
