using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombController : MonoBehaviour
{
    [Header("Bomb")]
    public KeyCode inputKey = KeyCode.Z;
    public GameObject bombPrefab;
    public float bombFuseTime = 2f;
    public int bombAmount;
    private int bombsRemaining;
    public TextMeshProUGUI txtCountBomb;

    [Header("Explosion")]
    public Explosion explosionPrefab;
    public LayerMask explosionLayerMask;
    public float explosionDuration = 1f;
    public int explosionRadius = 1;

    [Header("Destructible")]
    public Tilemap destructibleTiles;
    public Destructible destructiblePrefab;
    // public Answer answer;
    // public TilemapCollider2D tilemapCollider;
    [Header("Text")]
    public TextMeshProUGUI txtBomb;

    public TextMeshProUGUI txtLengthFire;

    AudioBomberman audioBomberman;

    public void Awake()
    {
        audioBomberman = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioBomberman>();

    }

    public void Start()
    {
        explosionRadius = 1;
        bombAmount = 1;
        txtBomb.text = bombsRemaining.ToString();
        txtLengthFire.text = explosionRadius.ToString();
    }
    private void OnEnable()
    {
        bombsRemaining = bombAmount;
    }

    private void Update()
    {
        if (bombsRemaining > 0 && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(PlaceBomb());
        }

    }

    private IEnumerator PlaceBomb()
    {
        Vector2 position = transform.position;
        // position.x = Mathf.Round(position.x);
        // position.y = Mathf.Round(position.y);
        // position.x += 0.2f;
        // position.y -= 0.1f;
        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);
        bombsRemaining--;

        yield return new WaitForSeconds(bombFuseTime);

        position = bomb.transform.position;
        // position.x = Mathf.Round(position.x);
        // position.y = Mathf.Round(position.y);

        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveRenderer(explosion.start);
        explosion.DestroyAfter(explosionDuration);
        audioBomberman.PlayExplode(audioBomberman.explodedAudio);

        Explode(position, Vector2.up, explosionRadius);
        Explode(position, Vector2.down, explosionRadius);
        Explode(position, Vector2.left, explosionRadius);
        Explode(position, Vector2.right, explosionRadius);
        txtCountBomb.text = bombsRemaining.ToString();

        Destroy(bomb);
        // audioBomberman.StopSFX(audioBomberman.explodedAudio);

        bombsRemaining++;


    }

    private void Explode(Vector2 position, Vector2 direction, int length)
    {
        if (length <= 0)
        {
            return;
        }

        position += direction;

        if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, explosionLayerMask))
        {
            ClearDestructible(position);

            return;
        }

        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveRenderer(length > 1 ? explosion.middle : explosion.end);
        explosion.SetDirection(direction);
        explosion.DestroyAfter(explosionDuration);

        Explode(position, direction, length - 1);
    }

    private void ClearDestructible(Vector2 position)
    {
        Vector3Int cell = destructibleTiles.WorldToCell(position);
        TileBase tile = destructibleTiles.GetTile(cell);

        if (tile != null)
        {
            Instantiate(destructiblePrefab, position, Quaternion.identity);
            destructibleTiles.SetTile(cell, null);
            destructibleTiles.gameObject.GetComponent<TilemapCollider2D>().enabled = false;
            destructibleTiles.gameObject.GetComponent<TilemapCollider2D>().enabled = true;

        }
        // tilemapCollider.OverrideTilemapColliderGeometry(destructibleTiles);
    }


    public void AddBomb()
    {
        bombAmount++;
        bombsRemaining++;
        txtBomb.text = bombsRemaining.ToString();
    }

    public void AddRadius()
    {
        explosionRadius++;
        txtLengthFire.text = explosionRadius.ToString();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            other.isTrigger = false;
        }
    }

}
