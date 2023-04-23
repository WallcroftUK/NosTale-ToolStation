local UUID = require ('UUID')
local Position = require ('Position')

local MapNpc = {}

function MapNpc.CreateNpcWithVnum(vnum)
    local mapNpc =
    {
        Id = UUID.Generate(),
        Vnum = vnum,
        Position = Position.At(0, 0),
        CanMove = true,
        IsProtectedNpc = false,
        FollowPlayer = false,
        Events = {},
        Direction = 2,
        HpMultiplier = nil,
        MpMultiplier = nil,
        CustomLevel = nil
    }
    
    function mapNpc.At(x, y)
        mapNpc.Position = Position.At(x, y)
        return mapNpc
    end
    
    function mapNpc.Facing(dir)
        mapNpc.Direction = dir
        return mapNpc
    end
    
    function mapNpc.WithCustomLevel(level)
        mapNpc.CustomLevel = level
        return mapNpc
    end
    
    function mapNpc.WithDisabledMovement()
        mapNpc.CanMove = false
        return mapNpc
    end
    
    function mapNpc.WithMustProtectAura()
        mapNpc.IsProtectedNpc = true
        return mapNpc
    end
    
    function mapNpc.WithFollowPlayer()
        mapNpc.FollowPlayer = true
        return mapNpc
    end
    
    function mapNpc.WithHpMultiplier(hpMultiplier)
        mapNpc.HpMultiplier = hpMultiplier
        return mapNpc
    end
    
    function mapNpc.WithMpMultiplier(mpMultiplier)
        mapNpc.MpMultiplier = mpMultiplier
        return mapNpc
    end
    
    function mapNpc.WithHpMpMultiplier(multiplier)
        mapNpc.HpMultiplier = multiplier
        mapNpc.MpMultiplier = multiplier
        return mapNpc
    end
    
    local function AddEvent(trigger, event)
        local events = mapNpc.Events[trigger];
        if (events == nil) then
            events = {}
            mapNpc.Events[trigger] = events
        end
        
        table.insert(events, event)
        
        return mapNpc
    end
    
    return mapNpc
end

return MapNpc;
