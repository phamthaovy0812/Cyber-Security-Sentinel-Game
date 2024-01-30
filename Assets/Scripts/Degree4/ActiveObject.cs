using System.Collections;
using UnityEngine;
public class ActiveObject : MonoBehaviour
{
    public GameObject npc;
    public GameObject npc1;
    public GameObject player;
    public void PlayerActive()
    {
        npc.SetActive(false);
        player.SetActive(true);

    }
    public void NPCActive()
    {
        npc1.SetActive(true);
        player.SetActive(false);

    }
}