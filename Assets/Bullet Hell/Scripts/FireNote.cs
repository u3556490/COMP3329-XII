using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireNote : MonoBehaviour
{
    private float angle = 0f;

    private Vector2 noteMoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 0.1f);
    }

    private void Fire()
    {
        for (int i = 0; i <= 1; i++)
        {
            float noteDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float noteDirY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

            Vector3 noteMoveVector = new Vector3(noteDirX, noteDirY, 0f);
            Vector2 noteDir = (noteMoveVector - transform.position).normalized;

            GameObject n = NotePool.notePoolInstanse.GetNote();
            n.transform.position = transform.position;
            n.transform.rotation = transform.rotation;
            n.SetActive(true);
            n.GetComponent<Note>().SetMoveDirection(noteDir);
        }

        angle += 20f;

        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
}
