local TimeSpaceTask = {}

function TimeSpaceTask.Create(type, time)
    local timeSpaceTask =
    {
        TimeSpaceTaskType = type,
        GameDialogKey = nil,
        DurationInSeconds = time,
        StartDialog = nil,
        EndDialog = nil,
        StartDialogShout = nil,
        EndDialogShout = nil,
        DialogStartTask = true,
        StartDialogIsObjective = false,
        EndDialogIsObjective = false
    }
    
    function timeSpaceTask.WithTaskText(text)
        timeSpaceTask.GameDialogKey = text
        return timeSpaceTask
    end
    
    function timeSpaceTask.WithOnStartDialog(dialog, isObjective)
        timeSpaceTask.StartDialog = dialog
        if (isObjective == true) then
            timeSpaceTask.StartDialogIsObjective = true
        end
        return timeSpaceTask
    end
    
    function timeSpaceTask.WithOnFinishDialog(dialog, isObjective)
        timeSpaceTask.EndDialog = dialog
        if (isObjective == true) then
            timeSpaceTask.EndDialogIsObjective = true
        end
        return timeSpaceTask
    end
    
    function timeSpaceTask.WithOnStartShout(text)
        timeSpaceTask.StartDialogShout = text
        return timeSpaceTask
    end
    
    function timeSpaceTask.WithOnFinishShout(text)
        timeSpaceTask.EndDialogShout = text
        return timeSpaceTask
    end
    
    function timeSpaceTask.WithNoDialogTaskStart()
        timeSpaceTask.DialogStartTask = false
        return timeSpaceTask
    end
    
    return timeSpaceTask
end

return TimeSpaceTask;
