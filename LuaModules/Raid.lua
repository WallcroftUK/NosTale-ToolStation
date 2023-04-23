local UUID = require('UUID')

local Raid = {}

function Raid.Create(raidType)
    local raid = 
    {
        Id = UUID.Generate(),
        RaidType = raidType,
        Maps = nil,
        Spawn = nil,
        Requirement = nil,
        Reward = nil,
        DurationInSeconds = 900 -- Default: 15 minutes
    }
    
    function raid.WithMaps(maps) 
        raid.Maps = maps
        return raid
    end
    
    function raid.WithSpawn(spawn) 
        raid.Spawn = spawn
        return raid
    end
    
    function raid.WithRequirement(requirement) 
        raid.Requirement = requirement
        return raid
    end
    
    function raid.WithReward(reward) 
        raid.Reward = reward
        return raid
    end
    
    function raid.WithDuration(duration)
        raid.DurationInSeconds = duration
        return raid
    end
    
    return raid
end 

return Raid;
