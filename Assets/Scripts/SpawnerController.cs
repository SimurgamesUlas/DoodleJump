
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject prefab;
    public float speed;
    public float minX;
    public float MaxX;
    public float İnterval;
    void Start()
    {
        InvokeRepeating("spawn",İnterval,İnterval);
    }

   
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

    }
    private void spawn(){
        GameObject newPlat = Instantiate(prefab);
        newPlat.transform.position = new Vector2(
            Random.Range(minX,MaxX),
            transform.position.y + (Random.Range(0.5f,1f))
        );
    }
}
