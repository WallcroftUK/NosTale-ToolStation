local UUID = require ('UUID')
local Position = require ('Position')
local Event = require ('Event')
local ObjectiveType = require('ObjectiveType')

local Monster = {}

function Monster.CreateWithVnum(vnum)
    local monster =
    {
        Id = UUID.Generate(),
        Vnum = vnum,
        Position = Position.At(0, 0),
        CanMove = true,
        IsBoss = false,
        IsTarget = false,
        IsRandomPosition = false,
        SpawnAfterTask = false,
        SpawnAfterMobs = 0,
        GoToBossPosition = Position.At(0, 0),
        Drop = {},
        Events = {},
        Direction = 2,
        CustomLevel = nil,
        AtAroundMobId = nil,
        AtAroundMobRange = nil,
        Waypoints = {}
    }
    
    function monster.At(x, y)
        monster.Position = Position.At(x, y)
        return monster
    end
    
    function monster.Facing(dir)
        monster.Direction = dir
        return monster
    end
    
    function monster.FacingRandom()
        monster.Direction = math.random(0, 7)   -- semi-random, will reroll on script reload
        return monster
    end
    
    function monster.WithCustomLevel(level)
        monster.CustomLevel = level
        return monster
    end
    
    function monster.AtRandomPosition()
        monster.IsRandomPosition = true
        return monster
    end
    
    local function AddEvent(trigger, event)
        local events = monster.Events[trigger];
        if (events == nil) then
            events = {}
            monster.Events[trigger] = events
        end

        table.insert(events, event)

        return monster
    end
    
    function monster.OnDeath(events)    -- "0"%
        for k,v in pairs(events) do
            AddEvent("OnDeath", v)
        end
        return monster
    end
    
    function monster.OnQuarterHp(events)    -- 25%
        for k,v in pairs(events) do
            AddEvent("OnQuarterHp", v)
        end
        return monster
    end
    
    function monster.OnHalfHp(events)   -- 50%
        for k,v in pairs(events) do
            AddEvent("OnHalfHp", v)
        end
        return monster
    end
    
    function monster.OnThreeFourthsHp(events)    -- 75%
        for k,v in pairs(events) do
            AddEvent("OnThreeFourthsHp", v)
        end
        return monster
    end
    
    function monster.AsBoss()
        monster.IsBoss = true
        monster.IsTarget = true
        monster.OnDeath({Event.IncreaseObjective(ObjectiveType.Monster)});
        return monster
    end
    
    function monster.WithHpMultiplier(hpMultiplier)
        monster.HpMultiplier = hpMultiplier
        return monster
    end
    
    function monster.WithMpMultiplier(mpMultiplier)
        monster.MpMultiplier = mpMultiplier
        return monster
    end
    
    function monster.WithHpMpMultiplier(multiplier)
        monster.HpMultiplier = multiplier
        monster.MpMultiplier = multiplier
        return monster
    end
    
    function monster.AsDungeonBoss()
        monster.IsBoss = true
        return monster
    end
    
    function monster.SpawnAfterTaskStart()
        monster.SpawnAfterTask = true
        return monster
    end
    
    function monster.SpawnAfterMobsKilled(amount)
        monster.SpawnAfterMobs = amount
        return monster
    end
    
    function monster.AsObjective()
        monster.IsTarget = true
        monster.OnDeath({Event.IncreaseObjective(ObjectiveType.Monster)});
        return monster
    end
    
    function monster.AsTarget()
        monster.IsTarget = true
        return monster
    end
    
    function monster.WithMoveToPosition(x, y)
        monster.GoToBossPosition = Position.At(x, y)
        return monster
    end
    
    function monster.AddDrop(drop)
        for k,v in pairs(drop) do
            table.insert(monster.Drop, v)
        end
        
        return monster
    end
    
    function monster.AtAroundMob(mob, range)
        monster.AtAroundMobId = mob.Id
        monster.AtAroundMobRange = range
        return monster
    end
    
    function monster.WithWaypoints(waypoints)
        for k,v in pairs(waypoints) do
            table.insert(monster.Waypoints, v)
        end
        return monster
    end
    
    return monster
end

return Monster;
