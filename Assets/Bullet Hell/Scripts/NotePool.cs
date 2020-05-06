using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePool : MonoBehaviour
{
    public static NotePool notePoolInstanse;

    [SerializeField]
    private GameObject pooledNote;
    private bool notEnoughNotesInPool = true;

    private List<GameObject> notes;

    private void Awake()
    {
        notePoolInstanse = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        notes = new List<GameObject>();
    }

    public GameObject GetNote()
    {
        if (notes.Count > 0)
        {
            for (int i = 0; i < notes.Count; i++)
            {
                if (!notes[i].activeInHierarchy)
                {
                    return notes[i];
                }
            }
        }

        if (notEnoughNotesInPool)
        {
            GameObject n = Instantiate(pooledNote);
            n.SetActive(false);
            notes.Add(n);
            return n;
        }

        return null;
    }
}
