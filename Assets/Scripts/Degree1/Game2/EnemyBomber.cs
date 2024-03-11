using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomber : MonoBehaviour
{
    private List<Vector2> PathToBomberMan = new List<Vector2>();
    private List<Vector2> RandomPath = new List<Vector2>();
    private List<Vector2> CurrentPath = new List<Vector2>();
    private PathFinderBomberman PathFinder;
    private bool isMoving;
    private bool SeeBomber;

    private GameObject BomberMan;
    public GameObject DeathEffect;
    public GameObject AddScoreEffect;

    public float MoveSpeed;
    Vector3 positionChest;
    AudioBomberman audioBomberman;

    // Start is called before the first frame update
    void Start()
    {
        BomberMan = GameObject.FindGameObjectWithTag("Player");
        PathFinder = GetComponent<PathFinderBomberman>();
        ReCalculatePath();
        isMoving = true;

    }
    void Awake()
    {
        audioBomberman = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioBomberman>();
    }

    public void ReCalculatePath()
    {
        PathToBomberMan = PathFinder.GetPath(BomberMan.transform.position);

        if (PathToBomberMan.Count == 0)
        {
            SeeBomber = false;
            if (!SeeBomber && CurrentPath.Count == 0)
            {
                var r = Random.Range(0, PathFinder.FreeNodes.Count);
                RandomPath = PathFinder.GetPath(PathFinder.FreeNodes[r].Position);
                CurrentPath = RandomPath;
            }

        }
        else
        {
            CurrentPath = PathToBomberMan;
            SeeBomber = true;
        }
    }

    public void Damage(int source)
    {
        if (source == 1)
        {

            Instantiate(DeathEffect, transform.position, transform.rotation);

            // Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            audioBomberman.PlaySFX(audioBomberman.correctAudio);
            GameObject add = Instantiate(AddScoreEffect, positionChest, Quaternion.identity);
            GameObject game = Instantiate(DeathEffect, positionChest, Quaternion.identity);
            FindObjectOfType<BBCountDownGamePlay>().AddTimer(1);
            Destroy(gameObject);


        }
    }
    IEnumerator DestroyGameObject(GameObject game)
    {

        yield return new WaitForSeconds(3f);

        Destroy(game);
    }

    // Update is called once per frame
    public void Update()
    {
        positionChest = transform.position;
        if (BomberMan == null) return;

        if (CurrentPath.Count == 0 && Vector2.Distance(transform.position, BomberMan.transform.position) > 0.5f)
        {
            ReCalculatePath();
            isMoving = true;
        }
        if (CurrentPath.Count == 0)
        {
            return;
        }


        if (isMoving)
        {
            if (Vector2.Distance(transform.position, CurrentPath[CurrentPath.Count - 1]) > 0.1f)
            {

                transform.position = Vector2.MoveTowards(transform.position, CurrentPath[CurrentPath.Count - 1], MoveSpeed * Time.deltaTime);

            }
            if (Vector2.Distance(transform.position, CurrentPath[CurrentPath.Count - 1]) <= 0.1f)
            {
                isMoving = false;
            }
        }
        else
        {

            ReCalculatePath();
            isMoving = true;
        }
    }
}
