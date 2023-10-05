using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager sharedInstance;

    [SerializeField] private List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>();
    [SerializeField] private List<LevelBlock> currentlevelBlocks = new List<LevelBlock>();

    [SerializeField] private Transform levelStartPosition; //almacena 1er bloque

    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
    }

    private void Start()
    {
        GenerateInitialBlocks();
    }

    private void Update()
    {
        
    }

    public void AddLevelBlock()
    {
        int randomIndex = Random.Range(0, allTheLevelBlocks.Count);
        LevelBlock block;
        Vector3 spawnPosition = Vector3.zero;

        if(currentlevelBlocks.Count == 0)
        {
            block = Instantiate(allTheLevelBlocks[0]);
            spawnPosition = levelStartPosition.position;
        }
        else
        {
            block = Instantiate(allTheLevelBlocks[randomIndex]);
            spawnPosition = currentlevelBlocks[currentlevelBlocks.Count - 1].exitPoint.position;
        }
        block.transform.SetParent(this.transform, false);
        Vector3 correction = new Vector3(spawnPosition.x - block.startPoint.position.x, spawnPosition.y - block.startPoint.position.y, 0);
        block.transform.position = correction;
        currentlevelBlocks.Add(block);

    }
    public void RemoveLevelBlock()
    {
        LevelBlock oldBlock = currentlevelBlocks[0];
        currentlevelBlocks.Remove(oldBlock);
        Destroy(oldBlock.gameObject);
    }
    public void RemoveAllLevelBlock()
    {
        while (currentlevelBlocks.Count > 0)
        {
            RemoveLevelBlock();
        }
    }
    public void GenerateInitialBlocks()
    {
        for(int i=0; i < 2; i++)
        {
            AddLevelBlock();
        }

    }


}
