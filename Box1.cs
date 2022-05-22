using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box1 : MonoBehaviour
{
//переменные
	private float PreviousTime;
	public float FallTime = 0.8f;
	public static int Height = 20;
	public static int Width = 10;
	public Vector3 RotationPoint;
	private static Transform[,] Grid = new Transform[Width, Height];
	public static int Score = 0;
	public static int Check = 0;

    void Update()
	{
			if (Input.GetKeyDown(KeyCode.A))
			{
				transform.position += new Vector3(-1, 0, 0);
				if (!ValidMove())
				{
					transform.position -= new Vector3(-1, 0, 0);
				}
			}
			else if (Input.GetKeyDown(KeyCode.D))
			{
				transform.position += new Vector3(1, 0, 0);
				if (!ValidMove())
				{
					transform.position -= new Vector3(1, 0, 0);
				}
			}
			else if (Input.GetKeyDown(KeyCode.W))
			{
				transform.RotateAround(transform.TransformPoint(RotationPoint), new Vector3(0, 0, 1), 90);
				if (!ValidMove())
				{
					transform.RotateAround(transform.TransformPoint(RotationPoint), new Vector3(0, 0, 1), -90);
				}
			}

			if (Check == 0)
			{
				if (Time.time - PreviousTime > (Input.GetKey(KeyCode.S) ? FallTime / 10 : FallTime))
				{
					transform.position += new Vector3(0, -1, 0);
					if (!ValidMove())
					{
						transform.position -= new Vector3(0, -1, 0);
						AddGrid();
						CheckLines();
						this.enabled = false;
						FindObjectOfType<Spawn1>().SpawnNewBox();
					}
					PreviousTime = Time.time;
				}
		}
	}

//добавляет в массив местоположение тетрамино, то есть если тетрамино палочка ебанная и она ложится на координаты [0,0] [0,1] [0,2] [0,3] то эта хуйня как раз заполнит массив
	void AddGrid()
	{
		foreach (Transform children in transform)
		{
			int RoundedX = Mathf.RoundToInt(children.transform.position.x);
			int RoundedY = Mathf.RoundToInt(children.transform.position.y);

			Grid[RoundedX, RoundedY] = children;
		}
		++Score; //это моя хуйня, не трогай, но если че просто плюс одно очко когда поставилось тетрамино ебанное
	}

//функция которая чекает линию и если ее можно удалить то удаляет и то что ниже сдвигает вниз
	void CheckLines()
    {
        for (int i = Height - 1; i >= 0; --i)
        {
			if (HasLine(i))
            {
				DeleteLine(i);
				RowDown(i);
            }
        }
    }

//булевая функция проверяющая есть ли линия которую надо удалить
	bool HasLine(int i)
    {
        for (int j = 0; j < Width; ++j)
        {
			if (Grid[j,i] == null)
            {
				return false;
            }
        }
		return true;
    }

	void DeleteLine(int i)
    {
		for (int j = 0; j < Width; ++j)
        {
			Destroy(Grid[j, i].gameObject);
			Grid[j, i] = null;
        }
		Score += 10;
    }
//функция двигающая все тетрамино стоящие выше удаленной линии
	void RowDown(int i)
    {
        for (int y = i; y < Height; ++y)
        {
            for (int j = 0; j < Width; ++j)
            {
				if (Grid[j,y] != null)
                {
					Grid[j, y - 1] = Grid[j, y];
					Grid[j, y] = null;
					Grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);

				}
            }
        }
    }

//булевая функция проверяющая можно ли двигаться ниже или правее или левее
	bool ValidMove()
    {
		foreach (Transform children in transform)
        {
			int RoundedX = Mathf.RoundToInt(children.transform.position.x);
			int RoundedY = Mathf.RoundToInt(children.transform.position.y);

			if (RoundedX < 0 || RoundedX >= Width || RoundedY < 0 || RoundedY >= Height)
            {
				return false;
			}

			if (Grid[RoundedX, RoundedY] != null)
            {
				return false;
			}
		}
		return true;
    }

}
