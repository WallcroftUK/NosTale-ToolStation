local Dungeon = {}

function Dungeon.Create(dungeonType)
    local dungeon = 
    {
        DungeonType = dungeonType,
        Maps = nil,
        Spawn = nil,
        Reward = nil
    }
    
    function dungeon.WithMaps(maps) 
        dungeon.Maps = maps
        return dungeon
    end
    
    function dungeon.WithSpawn(spawn) 
        dungeon.Spawn = spawn
        return dungeon
    end
    
    function dungeon.WithReward(reward) 
        dungeon.Reward = reward
        return dungeon
    end
    
    return dungeon
end

return Dungeon;
