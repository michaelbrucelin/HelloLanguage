<#
    # 使用
    MyAdd-ScheduleTrigger -scheFolder '\' -scheName 'WorkAtHomeTriggerWorkflow' -scheTime '2020-01-31T17:59:00'
#>
function MyAdd-ScheduleTrigger() {
    param(
        [Parameter(Mandatory = $true)]
        [string]$scheFolder,
        [Parameter(Mandatory = $true)]
        [string]$scheName,
        [Parameter(Mandatory = $true, HelpMessage = 'format："2020-01-31T15:35:40"')]
        [string]$scheTime
    )

    Try {
        # 首先连接到任务计划程序
        $service = New-Object -ComObject("Schedule.Service")
        $service.Connect($env:COMPUTERNAME)

        # 选择指定目录下的某个任务
        $folder = $service.GetFolder($scheFolder)
        $task = $folder.GetTask($scheName)

        # 获取任务的“定义”
        $definition = $task.Definition
        # $def.triggers | Where-Object { $_.ID -eq 'RACTimeTrigger' } | ForEach-Object { $_.Enabled = $true }

        #Triggers
        $triggers = $definition.Triggers
        $trigger = $triggers.Create(1) # Creates a "One time" trigger
        $trigger.StartBoundary = $scheTime
        $trigger.Enabled = $True

        # 将更新写回到任务计划程序
        # 参数中的4表示Update。而RegisterTaskDefinition() 函数的返回值是$task这个任务的Definition。
        $folder.RegisterTaskDefinition($scheName, $definition, 4, $null, $null, $null)
    }
    Catch [System.Exception] {
        Write-Host "Schedule Trigger Add Failed" -ForegroundColor Red
        Write-Host $Error[0] -ForegroundColor Red
    }
}
