using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{

    int time;
    public int count = 0;
    public int width;
    public int height;
    public GameObject tilescript_g;
    public GameObject tilescript_0;
    public GameObject tilescript_1;
    public GameObject tilescript_2;
    public GameObject tilescript_3;
    public GameObject tilescript_4;
    public GameObject tilescript_5;
    public GameObject tilescript_6;

    public List<GameObject> tilesL;

    public GameObject[] waterTiles;
    /*********************************
     물 타일
     [0] ~ [6] : 매우 좋음 ~ 매우 나쁨
    **********************************/

    public GameObject[] dirArrows; //화살표
    public GameObject groundTile; //땅(흰색 타일)
    public GameObject purifier; //정화 시설 : pos6
    public GameObject corrupter;
    public int[,] pos;
    /*******************s
     물or땅
     0 : 땅
     1이상 : 물
     *******************/
    public bool firstTime = true;
    public float[,] BOD;
    public float[,] DO;
    public float[,] COD;

    public float delBOD, delCOD;

    public int[,] dir;
    public bool[,] Cor;
    public bool[,] Pur;
    /********************************
     물이 흐르는 방향
     1 : 위
     2 : 아래
     3 : 왼쪽
     4 : 오른쪽
    *********************************/
    public bool isWater = false, isUp = false, isDown = false, isLeft = false, isRight = false, isPurifier = false, isCor = false;
    public bool viewBOD = true, viewCOD = false, viewDO = false;

    public static Script instance = null;

    public float BODvar, DOvar, CODvar;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        Input();
        CreateTiles();
    }
    

    public void Input()
    {
        pos = new int[width, height];
        BOD = new float[width, height];
        DO = new float[width, height];
        COD = new float[width, height];
        dir = new int[width, height];     //물이 흐르는 방향
        Cor = new bool[width, height];
        Pur = new bool[width, height];

        for (int i=0;i <width;i++)
        {
            for(int j = 0; j < height; j++)
            {
                pos[i, j] = 0;
                BOD[i, j] = Random.Range(BODvar - 2f, BODvar + 2f);
                COD[i, j] = Random.Range(CODvar - 2f, BODvar + 2f);
                DO[i, j]  = Random.Range(DOvar - 2f, DOvar + 2f);
                Cor[i, j] = false;
            }
        }
    }

    public void CreateTiles()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3 tilePos = new Vector3(i, j, 0f);
                Instantiate(groundTile, tilePos, Quaternion.identity);

            }   
        }
    }

    public void CreateTiles(bool first, int i, int j)
    {
                Vector3 tilePos = new Vector3(i, j, 0f);
                
                    if (BOD[i, j] <= 1 && viewBOD) 
                        Instantiate(waterTiles[0], tilePos, Quaternion.identity);
                    else if (BOD[i, j] <= 2)
                        Instantiate(waterTiles[1], tilePos, Quaternion.identity);
                    else if (BOD[i, j] <= 3)
                        Instantiate(waterTiles[2], tilePos, Quaternion.identity);
                    else if (BOD[i, j] <= 5)
                        Instantiate(waterTiles[3], tilePos, Quaternion.identity);
                    else if (BOD[i, j] <= 8)
                        Instantiate(waterTiles[4], tilePos, Quaternion.identity);
                    else if (BOD[i, j] <= 10)
                        Instantiate(waterTiles[5], tilePos, Quaternion.identity);
                    else if (BOD[i, j] > 10)
                    {
                        Instantiate(waterTiles[6], tilePos, Quaternion.identity);
                        Debug.Log("물이 정말 X박음");
                    }


    }

    public void CreateTiles(int a, int b)
    {
        
            Vector3 tilePos = new Vector3(a, b, 0f);
            if (BOD[a, b] <= 1)
                Instantiate(waterTiles[0], tilePos, Quaternion.identity);
            else if (BOD[a, b] <= 2)
                Instantiate(waterTiles[1], tilePos, Quaternion.identity);
            else if (BOD[a, b] <= 3)
                Instantiate(waterTiles[2], tilePos, Quaternion.identity);
            else if (BOD[a, b] <= 5)
                Instantiate(waterTiles[3], tilePos, Quaternion.identity);
            else if (BOD[a, b] <= 8)
                Instantiate(waterTiles[4], tilePos, Quaternion.identity);
            else if (BOD[a, b] <= 10)
                Instantiate(waterTiles[5], tilePos, Quaternion.identity);
            else if (BOD[a, b] > 10)
            {
                Instantiate(waterTiles[6], tilePos, Quaternion.identity);
                Debug.Log("물이 정말 X박음");
            }
        
    }

    public void CreateTiles_BOD(int a, int b)
    {

        Vector3 tilePos = new Vector3(a, b, 0f);

        if (pos[a, b] != 0)
        {
            if (BOD[a, b] <= 1)
                Instantiate(waterTiles[0], tilePos, Quaternion.identity);
            else if (BOD[a, b] <= 2)
                Instantiate(waterTiles[1], tilePos, Quaternion.identity);
            else if (BOD[a, b] <= 3)
                Instantiate(waterTiles[2], tilePos, Quaternion.identity);
            else if (BOD[a, b] <= 5)
                Instantiate(waterTiles[3], tilePos, Quaternion.identity);
            else if (BOD[a, b] <= 8)
                Instantiate(waterTiles[4], tilePos, Quaternion.identity);
            else if (BOD[a, b] <= 10)
                Instantiate(waterTiles[5], tilePos, Quaternion.identity);
            else if (BOD[a, b] > 10)
            {
                Instantiate(waterTiles[6], tilePos, Quaternion.identity);
                Debug.Log("물이 정말 X박음");
            }
        }
    }

    public void CreateTiles_COD(int a, int b)
    {

        Vector3 tilePos = new Vector3(a, b, 0f);
        if(pos[a,b] != 0)
        if (COD[a, b] <= 2)
            Instantiate(waterTiles[0], tilePos, Quaternion.identity);
        else if (COD[a, b] <= 4)
            Instantiate(waterTiles[1], tilePos, Quaternion.identity);
        else if (COD[a, b] <= 5)
            Instantiate(waterTiles[2], tilePos, Quaternion.identity);
        else if (COD[a, b] <= 7)
            Instantiate(waterTiles[3], tilePos, Quaternion.identity);
        else if (COD[a, b] <= 9)
            Instantiate(waterTiles[4], tilePos, Quaternion.identity);
        else if (COD[a, b] <= 11)
            Instantiate(waterTiles[5], tilePos, Quaternion.identity);
        else if (COD[a, b] > 11)
        {
            Instantiate(waterTiles[6], tilePos, Quaternion.identity);
            Debug.Log("물이 정말 X박음");
        }

    }

    public void CreateTiles_DO(int a, int b)
    {

        Vector3 tilePos = new Vector3(a, b, 0f);
        if (pos[a, b] != 0)
            if (DO[a, b] >= 7.5)
                Instantiate(waterTiles[0], tilePos, Quaternion.identity);
            else if (DO[a, b] >= 5.0)
                Instantiate(waterTiles[3], tilePos, Quaternion.identity);
            else if (DO[a, b] >= 2.0)
                Instantiate(waterTiles[5], tilePos, Quaternion.identity);
            else if (DO[a, b] < 2.0)
            {
                Instantiate(waterTiles[6], tilePos, Quaternion.identity);
                Debug.Log("물이 정말 X박음");
            }

    }

    public void DirectionBut_up()
    {
        isUp = true;
        isDown = false;
        isLeft = false;
        isRight = false;
        isWater = false;
        isPurifier = false;
        Debug.Log("up");
    }

    public void DirectionBut_left()
    {
        isUp = false;
        isDown = false;
        isLeft = true;
        isRight = false;
        isWater = false;
        isPurifier = false;
        Debug.Log("left");
    }

    public void DirectionBut_down()
    {
        isUp = false;
        isDown = true;  
        isLeft = false;
        isRight = false;
        isWater = false;
        isPurifier = false;
        Debug.Log("down");
    }

    public void DirectionBut_right()
    {
        isUp = false;
        isDown = false;
        isLeft = false;
        isRight = true;
        isWater = false;
        isPurifier = false;
        Debug.Log("right");
    }

    public void But_none()
    {
        isUp = false;
        isDown = false;
        isLeft = false;
        isRight = false;
        isWater = false;
        isPurifier = false;
        isCor = false;
        Debug.Log("none");
    }

    public void WaterModOn()
    {
        But_none();
        isWater = true;
        Debug.Log("on");
    }

    public void WaterModOff()
    {
        But_none();
        isWater = false;
        Debug.Log("off");
    }

    public void BODbut()
    {
        viewBOD = true;
        viewCOD = false;
        viewDO = false;
        Debug.Log("BOD");

        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
                if(pos[i,j]!=0)
                CreateTiles(i, j);
    }

    public void CODbut()
    {
        viewBOD = false;
        viewCOD = true;
        viewDO = false;
        Debug.Log("COD");
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
                CreateTiles_COD(i,j);
    }

    public void DObut()
    {
        viewBOD = false;
        viewCOD = false;
        viewDO = true;
        Debug.Log("DO");

        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
                CreateTiles_DO(i, j);   
    }

    public void PURbut()
    {
        But_none();
        isPurifier = true;
    }

    public void Corbut()
    {
        But_none();
        isCor = true;
    }

    public void Proceed()
    {
        GameObject[] tempobj;
        tempobj = GameObject.FindGameObjectsWithTag("Water");

        for (int i = 0; i < tempobj.Length; i++) {
                Destroy(tempobj[i]);    
        }
        
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)        
            {
                if (pos[i, j] != 0)
                {
                    if (dir[i, j] == 2) //방향이 아래
                    {
                        if (pos[i, j] == 5 || pos[i, j] == 2 || pos[i, j] == 3 || pos[i, j] == 4)
                        {

                            BOD[i, j] = BOD[i, j + 1]; //일반적으로는...
                            COD[i, j] = COD[i, j + 1];
                            DO[i, j] = DO[i, j + 1];
                        }

                        else if (pos[i, j] == 1 )  //예외 : 맨 윗줄
                        {
                            BOD[i, j] = Random.Range(BODvar - 2f, BODvar + 2f);
                            COD[i, j] = Random.Range(BODvar - 2f, BODvar + 2f);
                            DO[i, j] = Random.Range(BODvar - 2f, BODvar + 2f);
                        }

                    }

                    if (dir[i, j] == 3) //방향이 왼쪽
                    {

                        if (pos[i, j] == 5 || pos[i, j] == 3)
                        {
                            BOD[i, j] = BOD[i + 1, j]; //일반적으로는...
                            COD[i, j] = COD[i + 1, j];
                            DO[i, j] = DO[i + 1, j];
                        }
                        else if (pos[i, j] == 4 || pos[i, j] == 11) //예외 : 오른쪽 줄
                        {
                            BOD[i, j] = Random.Range(BODvar - 2f, BODvar + 2f);
                            COD[i, j] = Random.Range(BODvar - 2f, BODvar + 2f);
                            DO[i, j] = Random.Range(BODvar - 2f, BODvar + 2f);
                        }


                    }

  
                }
                if(pos[width - 1 - i, j] != 0)
                if (dir[width - 1 - i, j] == 4) //방향이 오른쪽
                {
                    if (pos[width - 1 - i, j] == 3) //예외 : 맨 왼쪽줄
                    {
                        BOD[width - 1 - i, j] = Random.Range(BODvar - 2f, BODvar + 2f);
                        COD[width - 1 - i, j] = Random.Range(BODvar - 2f, BODvar + 2f);
                        DO[width - 1 - i, j] = Random.Range(BODvar - 2f, BODvar + 2f);
                    }
                    else if (pos[width - 1 - i, j] == 5 || pos[width - 1 - i, j] == 4 || pos[width - 1 - i, j] == 2 || pos[width - 1 - i, j] == 1)
                    {
                        BOD[width - 1 - i, j] = BOD[width - 2 - i, j]; //일반적으로는...
                        COD[width - 1 - i, j] = BOD[width - 2 - i, j];
                        DO[width - 1 - i, j] = BOD[width - 2 - i, j];
                    }
                }

                if(pos[i, height - 1 - j] != 0)
                    if(dir[i, height - 1 - j]==1)//위쪽
                        if(pos[i, height - 1 - j] == 2 )
                        {
                            BOD[i, height - 1 - j] = Random.Range(BODvar - 2f, BODvar + 2f);
                            COD[i, height - 1 - j] = Random.Range(BODvar - 2f, BODvar + 2f);
                            DO[i, height - 1 - j] = Random.Range(BODvar - 2f, BODvar + 2f);
                        }
                        else if (pos[i, height - 1 - j] == 1 || pos[i, height - 1 -j] == 4 || pos[i, height - 1- j] == 3 || pos[i, height - 1- j] == 5)
                        {
                            BOD[i, height - 1 - j] = BOD[i, height - 2- j]; //일반적으로는...
                            COD[i, height - 1 - j] = BOD[i, height - 2 - j];
                            DO[i, height - 1 - j] = BOD[i, height  - 2- j];
                        }

                
            }
        }

        


        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
                if (Cor[i, j] && count % 3 == 0)
                {
                    BOD[i, j + 1] += delBOD;
                    BOD[i, j - 1] += delBOD;
                    BOD[i - 1, j] += delBOD;
                    BOD[i + 1, j] += delBOD;

                    COD[i, j + 1] += delCOD;
                    COD[i, j - 1] += delCOD;
                    COD[i - 1, j] += delCOD;
                    COD[i + 1, j] += delCOD;

                    DO[i, j + 1] -= 0.5f;
                    DO[i, j - 1] -= 0.5f;
                    DO[i - 1, j] -= 0.5f;
                    DO[i + 1, j] -= 0.5f;
                }

        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
                if (Pur[i, j] && count % 3 == 0)
                {
                    BOD[i, j] *= 0.3f;
                    COD[i, j] *= 0.3f;  
                    DO[i, j] *= 1.4f;
                }

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (pos[i, j] != 0)
                {
                    if (viewBOD && !viewCOD && !viewDO)
                        CreateTiles(i, j);
                    else if (!viewBOD && viewCOD && !viewDO)
                        CreateTiles_COD(i, j);
                    else if (!viewBOD && !viewCOD && viewDO)
                        CreateTiles_DO(i, j);
                }
            }
        }

        count++;
    }



}