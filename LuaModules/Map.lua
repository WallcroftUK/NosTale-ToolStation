local UUID = require('UUID')
local MapType = require('MapType')
local Event = require ('Event')

local Map = {}

function Map.Create()
    local map =
    {
        Id = UUID.Generate(),
        MapType = MapType.MapId,
        MapIdVnum = 0,
        MapIndexX = 0,
        MapIndexY = 0,
        Flags = {},
        NameId = 0,
        MusicId = 0,
        Portals = {},
        Monsters = {},
        Objects = {},
        Events = {},
        Npcs = {},
        MonsterWaves = {},
        TimeSpaceTask = nil
    }
    
    function map.WithMapVnum(mapVnum, flags, nameId, musicId)
        map.MapType = MapType.MapVNum;
        map.MapIdVnum = mapVnum;

        for _, v in pairs(flags) do
            table.insert(map.Flags, v)
        end

        map.NameId = nameId;
        map.MusicId = musicId;

        return map
    end
    
    function map.WithMapId(mapId)
        map.MapType = MapType.MapId;
        map.MapIdVnum = mapId;

        return map
    end
    
    function map.SetMapCoordinates(x, y)
        map.MapIndexX = x;
        map.MapIndexY = y;

        return map
    end
    
    function map.AtRightOfMap(leftMap)
        map.MapIndexX = leftMap.MapIndexX + 1;
        map.MapIndexY = leftMap.MapIndexY;
        return map
    end
    
    function map.AtLeftOfMap(rightMap)
        map.MapIndexX = rightMap.MapIndexX - 1;
        map.MapIndexY = rightMap.MapIndexY;
        return map
    end
    
    function map.AtTopOfMap(bottomMap)
        map.MapIndexX = bottomMap.MapIndexX;
        map.MapIndexY = bottomMap.MapIndexY - 1;
        return map
    end
    
    function map.AtBottomOfMap(topMap)
        map.MapIndexX = topMap.MapIndexX;
        map.MapIndexY = topMap.MapIndexY + 1;
        return map
    end
    
    function map.AddPortal(portal) 
        table.insert(map.Portals, portal)
        return map
    end
    
    function map.AddNpc(npc) 
        table.insert(map.Npcs, npc)
        return map
    end
    
    function map.AddMonster(monster) 
        table.insert(map.Monsters, monster)
        return map
    end
    
    function map.AddObject(object) 
        table.insert(map.Objects, object)
        return map
    end
    
    function map.AddObjects(objects)
        for k,v in pairs(objects) do
            table.insert(map.Objects, v)
        end
        return map
    end
    
    function map.AddMonsters(monsters)
        for k,v in pairs(monsters) do
            table.insert(map.Monsters, v)
        end
        return map
    end
    
    function map.AddPortals(portals)
        for k,v in pairs(portals) do
            table.insert(map.Portals, v)
        end
        return map
    end
    
    function map.AddButtons(buttons)
        for k,v in pairs(buttons) do
            table.insert(map.Buttons, v)
        end
        return map
    end
    
    function map.AddNpcs(npcs)
        for k,v in pairs(npcs) do
            table.insert(map.Npcs, v)
        end
        return map
    end
    
    function map.AddMonsterWaves(monsterWaves)
        for k,v in pairs(monsterWaves) do
            table.insert(map.MonsterWaves, v)
        end
        return map
    end
    
    function map.WithTask(task) 
        map.TimeSpaceTask = task
        return map
    end
    
    local function AddEvent(trigger, event)
        local events = map.Events[trigger];
        if (events == nil) then
            events = {}
            map.Events[trigger] = events
        end
        
        table.insert(events, event)
        
        return map
    end
    
    function map.OnObjectivesCompleted(events)
        for k,v in pairs(events) do
            AddEvent("ObjectivesCompleted", v)
        end
        return map
    end
    
    function map.AfterSlowMotion(events)
        for k,v in pairs(events) do
            AddEvent("AfterSlowMo", v)
        end
        return map
    end
    
    function map.OnMapJoin(events)
        for k,v in pairs(events) do
            AddEvent("OnMapJoin", v)
        end
        return map
    end
    
    function map.OnTaskFinish(events)
        for k,v in pairs(events) do
            AddEvent("OnTaskFinish", v)
        end
        return map
    end
    
    function map.OnTaskFail(events)
        for k,v in pairs(events) do
            AddEvent("OnTaskFail", v)
        end
        return map
    end
    
    function map.OnAllTargetMobsDead(events)
        for k,v in pairs(events) do
            AddEvent("OnAllTargetMobsDead", v)
        end
        return map
    end
    
    return map
end

return Map;
