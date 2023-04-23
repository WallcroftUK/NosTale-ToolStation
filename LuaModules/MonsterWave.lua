local MonsterWave = {}

function MonsterWave.CreateWithDelay(time)
    local monsterWave =
    {
        TimeInSeconds = time,
        Monsters = {},
        Loop = false,
        LoopTick = nil,
        IsScaledWithPlayerAmount = false
    }
    
    function monsterWave.WithMonsters(monsters)
        for k,v in pairs(monsters) do
            table.insert(monsterWave.Monsters, v)
        end
        return monsterWave
    end
    
    function monsterWave.AsLoop(time)
        monsterWave.Loop = true
        monsterWave.LoopTick = time
        return monsterWave
    end
    
    function monsterWave.ScaledWithPlayerAmount()
        -- spawn the wave that many times how many players there is in boss room, 5 players = 5 times the wave (with mob positions being rolled separately of course)
        monsterWave.IsScaledWithPlayerAmount = true
        return monsterWave
    end
    
    return monsterWave
end

return MonsterWave;
