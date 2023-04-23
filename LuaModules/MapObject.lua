local UUID = require('UUID')
local Position = require('Position')
local Event = require('Event')
local ObjectiveType = require('ObjectiveType')
local ObjectType = require('ObjectType')

local MapObject = {}

local function Create(objectType)
    local object =
    {
        ObjectType = objectType,
        Parameters = 
        {
            Id = UUID.Generate(),
            Vnum = 0,
            Position = Position.At(0, 0),
            IsRandomPosition = false,
            IsRandomUniquePosition = false,
            IsObjective = false,
            Events = {}
        }
    }
    
    function object.At(x, y)
        object.Parameters.Position = Position.At(x, y)
        return object
    end
    
    function object.AtRandomPosition(isUnique)
        isUnique = isUnique or false
        if (isUnique == true) then
            -- should it also make IsRandomPosition true?
            object.Parameters.IsRandomUniquePosition = true
        else
            object.Parameters.IsRandomPosition = true
        end
        return object
    end
    
    return object
    
end

function MapObject.CreateButton(deactivatedVnum, activatedVnum, onlyOnce)
    onlyOnce = onlyOnce or false
    
    local button = Create(ObjectType.Button)
    
    button.Parameters.ActivatedVnum = activatedVnum
    button.Parameters.DeactivatedVnum = deactivatedVnum
    button.Parameters.OnlyOnce = onlyOnce   -- if it's been used once, it can't be used again
    
    local function AddEvent(trigger, event)
        local events = button.Parameters.Events[trigger]
        if (events == nil) then
            events = {}
            button.Parameters.Events[trigger] = events
        end
        
        table.insert(events, event)
        
        return button
    end
    
    function button.OnTrigger(events)
        for k,v in pairs(events) do
            AddEvent("Triggered", v)
        end
        return button
    end
    
    function button.AsObjective()
        button.Parameters.IsObjective = true
        return button
    end
    
    function button.WithCustomDancing(duration) -- milliseconds, 1000 = 1s
        button.Parameters.CustomDanceDuration = duration
        return button
    end
    
    function button.AsRaidObjective()
        button.OnTrigger({Event.IncreaseObjective(ObjectiveType.Button)})
        return button.AsObjective()
    end
    
    function button.OnSwitch(events)
        for k,v in pairs(events) do
            AddEvent("Switched", v)
        end
        return button
    end
    
    return button
    
end

function MapObject.CreateItem(vnum)
    local item = Create(ObjectType.Item)
    
    item.Parameters.Vnum = vnum
    
    local function AddEvent(trigger, event)
        local events = item.Parameters.Events[trigger]
        if (events == nil) then
            events = {}
            item.Parameters.Events[trigger] = events
        end

        table.insert(events, event)

        return item
    end
    
    function item.OnPickup(events)
        for k,v in pairs(events) do
            AddEvent("PickedUp", v)
        end
        return item
    end
    
    function item.AsObjective()
        item.Parameters.IsObjective = true
        return item
    end
    
    function item.WithDancing(duration) -- milliseconds, 1000 = 1s
        item.Parameters.DanceDuration = duration
        return item
    end
    
    return item
end

function MapObject.CreateLever()
    return MapObject.CreateButton(1000, 1045)
end

function MapObject.CreateRedButton() 
    return MapObject.CreateButton(1051, 1052)
end

function MapObject.CreateWoodenLever() 
    return MapObject.CreateButton(1053, 1054)
end

function MapObject.CreateDevilSculpture() 
    return MapObject.CreateButton(1055, 1056, true)
end

function MapObject.CreateTrigger() 
    return MapObject.CreateButton(1135, 1136, true)
end

function MapObject.CreateBlockButton() 
    return MapObject.CreateButton(1182, 1183, true)
end

function MapObject.CreateTeleportLever() 
    return MapObject.CreateButton(1137, 1138)
end

function MapObject.CreateTeleportBone() 
    return MapObject.CreateButton(1139, 1140)
end

function MapObject.CreateCrystalBall() 
    return MapObject.CreateButton(1048, 1049, true)
end

function MapObject.CreateSealedKey(danceDuration)
    return MapObject.CreateItem(1057).WithDancing(danceDuration)
end

function MapObject.CreateOldBox()
    return MapObject.CreateItem(1001).WithDancing(3000)
end

function MapObject.CreateRegularBox()
    return MapObject.CreateItem(1042).WithDancing(4000)
end

function MapObject.CreateLuxuriousBox()
    return MapObject.CreateItem(1043).WithDancing(5000)
end

function MapObject.CreateRandomEffectBox()
    return MapObject.CreateItem(1068).WithDancing(3000)
end

return MapObject;
