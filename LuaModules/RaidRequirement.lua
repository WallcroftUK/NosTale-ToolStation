local RaidRequirement = {}

function RaidRequirement.Create() 
    local requirement = 
    {
        MinimumLevel = 0,
        MaximumLevel = 0,
        MinimumHeroLevel = 0,
        MaximumHeroLevel = 0,
        MinimumParticipant = 0,
        MaximumParticipant = 0
    }
    
    function requirement.WithMinimumLevel(level)
        requirement.MinimumLevel = level
        return requirement
    end
    
    function requirement.WithMaximumLevel(level) 
        requirement.MaximumLevel = level
        return requirement
    end
    
    function requirement.WithMinimumHeroLevel(level) 
        requirement.MinimumHeroLevel = level
        return requirement
    end
    
    function requirement.WithMaximumHeroLevel(level) 
        requirement.MaximumHeroLevel = level
        return requirement
    end
    
    function requirement.WithMinimumParticipant(level) 
        requirement.MinimumParticipant = level
        return requirement
    end
    
    function requirement.WithMaximumParticipant(level) 
        requirement.MaximumParticipant = level
        return requirement
    end
    
    return requirement
end

return RaidRequirement;
