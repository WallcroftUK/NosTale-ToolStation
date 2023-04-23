local EventName = require('EventName')
local Position = require('Position')
local inspect = require("inspect")

local Event = {}

local function Create(name, parameters)
    return {Name = name, Parameters = parameters}
end

function Event.IncreaseObjective(objectiveType)
    return Create(EventName.RaidIncreaseObjective, {ObjectiveType = objectiveType})
end

function Event.MonsterSummon(monsters)
    return Create(EventName.MonsterSummon, {Monsters = monsters})
end

function Event.OpenPortal(portal)
    return Create(EventName.OpenPortal, {Portal = portal})
end

function Event.ClosePortal(portal)
    return Create(EventName.ClosePortal, {Portal = portal})
end

function Event.FinishRaid(finishType)
    return Create(EventName.FinishRaid, {FinishType = finishType})
end

function Event.ThrowRaidDrops(raidDrop)
    return Create(EventName.ThrowRaidDrops, raidDrop)
end

function Event.Teleport(map, sourceX, sourceY, destX, destY, range)
    local teleport = {
        MapInstanceId = map.Id,
        SourcePosition = Position.At(sourceX, sourceY),
        DestinationPosition = Position.At(destX, destY),
        Range = range
    }
    
    return Create(EventName.Teleport, teleport)
end

function Event.RemovePortal(portal)
    return Create(EventName.RemovePortal, {Portal = portal})
end

function Event.DungeonRewardEvent()
    return Create(EventName.DungeonRewardEvent, {})
end

function Event.FinishTimeSpace(type)
    return Create(EventName.FinishTimeSpace, {TimeSpaceFinishType = type})
end

function Event.TryStartTaskForMap(map)
    return Create(EventName.TryStartTaskForMap, {MapId = map.Id})
end

function Event.AddTime(time)
    return Create(EventName.AddTime, {Time = time})
end

function Event.RemoveTime(time)
    return Create(EventName.AddTime, {Time = -time})
end

function Event.SetTime(time)
    return Create(EventName.SetTime, {Time = time})
end

function Event.DespawnAllMobsInRoom(map) -- despawns them like $butcher, not $killtarget, so it wont spawn mobs that spawn after x mobs are killed
    return Create(EventName.DespawnAllMobsInRoom, {Map = map.Id})
end

function Event.RemoveItems(mapObjects)
    local ids = {}
    for k,v in pairs(mapObjects) do
        table.insert(ids, v.Parameters.Id)
    end
    
    return Create(EventName.RemoveItems, {Items = ids})
end

function Event.TogglePortal(portal)
    return Create(EventName.TogglePortal, {Portal = portal})
end

function Event.CheckForTasksCompleted(maps, events)
    local ids = {}
    for k,v in pairs(maps) do
        table.insert(ids, v.Id)
    end
    
    return Create(EventName.CheckForTasksCompleted, {Maps = ids, Events = events})
end

return Event;
