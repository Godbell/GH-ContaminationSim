using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public GameObject MAin;
    public Vector3 arrowPos;
    public static Tile instances = null;


    void OnMouseEnter()
    {
        if (Script.instance.isWater)
        {
            Destroy(gameObject);
            Script.instance.CreateTiles((int)transform.position.x, (int)transform.position.y);
                
            if (transform.position.x == 0) //왼쪽 끝
                Script.instance.pos[0, (int)transform.position.y] = 3;

            else if (transform.position.x == Script.instance.width - 1) // 오른쪽 끝
                Script.instance.pos[(int)transform.position.x, (int)transform.position.y] = 4;

            else if (transform.position.y == Script.instance.height - 1) //위쪽 끝
                Script.instance.pos[(int)transform.position.x, (int)transform.position.y] = 1;

            else if (transform.position.y == 0) // 아래쪽 끝
                Script.instance.pos[(int)transform.position.x, 0] = 2;

            else
                Script.instance.pos[(int)transform.position.x, (int)transform.position.y] = 5;
        }
    }

    void OnMouseDown()
    {
        if (Script.instance.isUp)
        {
            arrowPos = new Vector3(transform.position.x, transform.position.y, -0.1f);
            Instantiate(Script.instance.dirArrows[0], arrowPos, Quaternion.identity);
            Script.instance.dir[(int)transform.position.x, (int)transform.position.y] = 1;
        }
        if (Script.instance.isDown)
        {
            arrowPos = new Vector3(transform.position.x, transform.position.y,-0.1f);
            Instantiate(Script.instance.dirArrows[1], arrowPos, Quaternion.identity);
            Script.instance.dir[(int)transform.position.x, (int)transform.position.y] = 2;
        }
        if (Script.instance.isLeft)
        {
            arrowPos = new Vector3(transform.position.x, transform.position.y,-0.1f);
            Instantiate(Script.instance.dirArrows[2], arrowPos, Quaternion.identity);
            Script.instance.dir[(int)transform.position.x, (int)transform.position.y] = 3;
        }
        if (Script.instance.isRight)
        {
            arrowPos = new Vector3(transform.position.x, transform.position.y,-0.1f);
            Instantiate(Script.instance.dirArrows[3], arrowPos, Quaternion.identity);
            Script.instance.dir[(int)transform.position.x, (int)transform.position.y] = 4;
        }
        if (Script.instance.isPurifier)
        {
            arrowPos = new Vector3(transform.position.x, transform.position.y,-0.1f);
            Instantiate(Script.instance.purifier, arrowPos, Quaternion.identity);
            Script.instance.Pur[(int)transform.position.x, (int)transform.position.y] = true;

        }
        if (Script.instance.isCor)
        {
            arrowPos = new Vector3(transform.position.x, transform.position.y, -0.1f);
            Instantiate(Script.instance.corrupter, arrowPos, Quaternion.identity);
            Script.instance.Cor[(int)transform.position.x, (int)transform.position.y] = true;
        }
        

    }
    
    public void Destroythis()
    {
        Destroy(gameObject);
    }
    
}
