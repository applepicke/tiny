using UnityEngine;
using System.Collections;

public class TerrainGenerator : MonoBehaviour {

	public GameObject tile;
	public Sprite corner, oneSidedVertical, oneSidedHorizontal, threeSided, middle;

	private int rows, columns;
	private int[,] tileData;
	private int scaleSize;

	// Use this for initialization
	void Start () {

		// Here we build the terrain
		// first we will determite the rows/columns needed based on
		// the size of the terrain generator. This will dictate the size of
		// tileData.

		scaleSize = 3; // try lowering this or raising it for smaller or bigger tiles. Looks good at 3
		rows = ((int)transform.localScale.x/ scaleSize);
		columns = ((int)transform.localScale.y/ scaleSize);
		tileData = new int[rows, columns];

		// Once this is done, we'll fill it with 1s and 0s representing blocks and non-blocks,
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < columns; j++)
			{
				tileData[i,j] = 1;
			}
		}

		// finally, iterate over the tileData creating instances of the Tile prefab, setting the sprite
		// and flipping it according to what tiles are surrounding the current tile.
		for (int i=0; i<rows; i++)
		{
			for (int j = 0; j < columns; j++)
			{
				
				GameObject newTile = (GameObject)Instantiate(tile, new Vector3((i * scaleSize) - ((rows*scaleSize) / 2) + transform.position.x, (j * scaleSize) - ((columns*scaleSize) / 2) + transform.position.y, 0), Quaternion.identity);
				SpriteRenderer tileRenderer = ((SpriteRenderer)newTile.GetComponent("SpriteRenderer"));

				newTile.transform.localScale = new Vector3(scaleSize, scaleSize, 1);

				if (isSolid(i - 1, j) && isSolid(i + 1, j) && isSolid(i, j - 1) && isSolid(i, j + 1))   // surrounded by solid?
					tileRenderer.sprite = middle;
				else if (isSolid(i - 1, j) && isSolid(i + 1, j) && isSolid(i, j + 1)) // empty top
				{
					tileRenderer.sprite = oneSidedVertical;
					tileRenderer.flipY = true;
				}
				else if (isSolid(i - 1, j) && isSolid(i + 1, j) && isSolid(i, j - 1)) // empty bottom
				{
					tileRenderer.sprite = oneSidedVertical;
				}
				else if (isSolid(i + 1, j) && isSolid(i, j + 1) && isSolid(i, j - 1)) // empty left
				{
					tileRenderer.sprite = oneSidedHorizontal;
				}
				else if (isSolid(i - 1, j) && isSolid(i, j + 1) && isSolid(i, j - 1)) // empty right
				{
					tileRenderer.sprite = oneSidedHorizontal;
					tileRenderer.flipX = true;
				}
				else if (isSolid(i + 1, j) && isSolid(i, j - 1)) // top left corner
				{
					tileRenderer.sprite = corner;
				}
				else if (isSolid(i - 1, j) && isSolid(i, j - 1)) // top right corner
				{
					tileRenderer.sprite = corner;
					tileRenderer.flipX = true;
				}
				else if (isSolid(i + 1, j) && isSolid(i, j + 1)) // bottom left corner
				{
					tileRenderer.sprite = corner;
					tileRenderer.flipY = true;
				}
				else if (isSolid(i - 1, j) && isSolid(i, j + 1)) // bottom right corner
				{
					tileRenderer.sprite = corner;
					tileRenderer.flipX = true;
					tileRenderer.flipY = true;
				}
				else
					tileRenderer.sprite = oneSidedVertical;

				newTile.transform.parent = transform;
			}
		}

	}

	bool isSolid(int row, int column)
	{
		if (row < 0 || row > rows - 1 || column < 0 || column > columns - 1 || tileData[row,column] == 0)
			return false;

		return true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
