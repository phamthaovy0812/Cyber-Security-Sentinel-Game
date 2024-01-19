using UnityEngine;

public class RandomizeCards : MonoBehaviour
{
    [SerializeField] private float offsetV;
    [SerializeField] private float offsetH;
    [SerializeField] private GameObject[] cardsTop;
    [SerializeField] private GameObject[] cardsBottom;

    void Start()
    {
        ShuffleCards(cardsTop);
        ShuffleCards(cardsBottom);

        ArrangeCards(cardsTop, offsetV);
        ArrangeCards(cardsBottom, -offsetV);
    }

    void ShuffleCards(GameObject[] cards)
    {
        int numCards = cards.Length;

        for (int i = numCards - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            GameObject temp = cards[i];
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }

    // can chinh lai position
    void ArrangeCards(GameObject[] cards, float offsetX)
    {
        int numCards = cards.Length;
        float cardHeight = cards[0].GetComponent<Renderer>().bounds.size.y + offsetH;
        float totalHeight = cardHeight * numCards;
        float firstCardY = transform.position.y - (totalHeight / 2) + (cardHeight / 2);

        for (int i = 0; i < numCards; i++)
        {
            float offsetY = firstCardY + i * cardHeight;
            Vector3 cardPosition = new Vector3(transform.position.x + offsetX, offsetY, transform.position.z);
            cards[i].transform.position = cardPosition;
        }
    }
}
