local TimeSpaceObjective = {}

function TimeSpaceObjective.Create()
    local objectives = {
        KillAllMonsters = false,
        GoToExit = false,
        KillMonsterVnum = nil,
        KillMonsterAmount = nil,
        CollectItemVnum = nil,
        CollectItemAmount = nil,
        Conversation = nil,
        InteractObjectsVnum = nil,
        InteractObjectsAmount = nil,
        ProtectNPC = false
    }
    
    function objectives.WithKillAllMonsters()
        objectives.KillAllMonsters = true
        return objectives
    end
    
    function objectives.WithGoToExit()
        objectives.GoToExit = true
        return objectives
    end
    
    function objectives.WithKillMob(vnum, amount)
        objectives.KillMonsterVnum = vnum
        objectives.KillMonsterAmount = amount
        return objectives
    end
    
    function objectives.WithCollectItem(vnum, amount)
        objectives.CollectItemVnum = vnum
        objectives.CollectItemAmount = amount
        return objectives
    end
    
    function objectives.WithConversations(amount)
        objectives.Conversation = amount
        return objectives
    end
    
    function objectives.WithInteractObjects(vnum, amount)
        objectives.InteractObjectsVnum = vnum
        objectives.InteractObjectsAmount = amount
        return objectives
    end
    
    function objectives.WithProtectNPC()
        objectives.ProtectNPC = true
        return objectives
    end
    
    return objectives
end

return TimeSpaceObjective;
