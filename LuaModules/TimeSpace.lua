local UUID = require('UUID')
local TimeSpace = {}

function TimeSpace.Create(id)
    local timespace = {
        Id = UUID.Generate(),
        TimeSpaceId = id,
        Maps = nil,
        Spawn = nil,
        Lives = 0,
        DurationInSeconds = 900, -- Default: 15 minutes,
        InfiniteDuration = false,   -- no timer shown, player can stay "infinitely" long in the time-space
        Objectives = nil,
        BonusPointItemDropChance = 5000,
        PreFinishDialog = nil,
        PreFinishDialogIsObjective = false,
        ObtainablePartnerVnum = nil
    }
    
    function timespace.SetMaps(maps)
        timespace.Maps = maps
        return timespace
    end
    
    function timespace.SetSpawn(spawn)
        timespace.Spawn = spawn
        return timespace
    end
    
    function timespace.SetDurationInSeconds(duration)
        timespace.DurationInSeconds = duration
        return timespace
    end
    
    function timespace.SetInfiniteDuration()
        timespace.InfiniteDuration = true
        return timespace
    end
    
    function timespace.SetLives(lives)
        timespace.Lives = lives
        return timespace
    end
    
    function timespace.SetObtainablePartner(vnum)
        timespace.ObtainablePartnerVnum = vnum
        return timespace
    end
    
    function timespace.SetObjectives(objectives)
        timespace.Objectives = objectives
        return timespace
    end
    
    function timespace.SetBonusPointItemDropChance(chance)
        timespace.BonusPointItemDropChance = chance
        return timespace
    end
    
    function timespace.SetPreFinishDialog(dialog, isObjective)
        timespace.PreFinishDialog = dialog
        if (isObjective == true) then
            timespace.PreFinishDialogIsObjective = true
        end
        return timespace
    end
    
    return timespace
end

return TimeSpace;
