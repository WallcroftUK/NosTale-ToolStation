local Mission = {}

function Mission.Create()
    local mission = {
        ObjectiveAmount = 0,
        FirstArgument = nil,
        SecondArgument = nil,
        ThirdArgument = nil,
        FourthArgument = nil,
        FifthArgument = nil,
        Rewards = {}
    }
    
    function mission.WithObjectiveAmount(x)
        mission.ObjectiveAmount = x
        return mission
    end
    function mission.WithRandomObjectiveAmountBetween(min, max)
        mission.ObjectiveAmount = math.random(min, max)
        return mission
    end
    
    function mission.WithFirstArgument(x)
        mission.FirstArgument = x
        return mission
    end
    
    function mission.WithSecondArgument(x)
        mission.SecondArgument = x
        return mission
    end
    
    function mission.WithThirdArgument(x)
        mission.ThirdArgument = x
        return mission
    end
    
    function mission.WithFourthArgument(x)
        mission.FourthArgument = x
        return mission
    end
    
    function mission.WithFifthArgument(x)
        mission.FifthArgument = x
        return mission
    end
    
    function mission.WithRewards(rewards)
        mission.Rewards = rewards
        return mission
    end
    
    return mission
end

return Mission;
