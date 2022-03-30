function MyGet-FangDai() {
    param(
        [int]$total,
        [decimal]$rate,
        [decimal]$rateDiscount = 1,
        [int]$years,
        [ValidateSet('summary','detail')]
        [string]$type = 'summary'
    )
    
    $total = $total*10000
    $rate = $rate*$rateDiscount/100
    [decimal]$rateMonth = $rate/12
    [int]$months = $years*12

    # 计算等额本金
    # 计算每月偿还的本金
    $debj1 = $total/$months
    # 计算首月偿还的利息
    $debj2 = $total*$rateMonth
    # 计算每月偿还利息递减金额
    $debj3 = $debj1*$rateMonth
    # 计算偿还利息总额
    $debj4 = $debj2*$years*12-($months-1)/2.0*$months*$debj3

    # 计算等额本息
    # 计算每月偿还金额
    $debxrate = 0
    for($i=1; $i -le $months; $i++){
        $debxrate = $debxrate + 1/([System.Math]::Pow((1+$rateMonth), $i))
    }
    $debx1 = $total/$debxrate
    # 计算偿还利息总额
    $debx2 = $debx1*$months-$total

    # 计算等额本息与等额本金利息差额
    $interestDiff = $debx2 - $debj4

    if($type -eq 'summary'){
        # 将结果取整并转为字符串
        $debj0 = [System.Convert]::ToString([System.Convert]::ToInt32($debj1+$debj2))
        $debj3 = [System.Convert]::ToString([System.Convert]::ToInt32($debj3))
        $debj4 = [System.Convert]::ToString([System.Convert]::ToInt32($debj4))
        $debx1 = [System.Convert]::ToString([System.Convert]::ToInt32($debx1))
        $debx2 = [System.Convert]::ToString([System.Convert]::ToInt32($debx2))
        $interestDiff = [System.Convert]::ToString([System.Convert]::ToInt32($interestDiff))

        $debjResult = "等额本金:`n首月偿还：${debj0}元；`n每月递减：${debj3}元；`n偿还利息总额：${debj4}元；"
        $debxResult = "等额本息:`n每月偿还：${debx1}元；`n偿还利息总额：${debx2}元；"
        $interestResult = "等额本息需要比等额本金多付利息${interestDiff}元；"

        Write-Output "`n$debjResult`n`n$debxResult`n`n$interestResult`n"
    }
    else{
        $result = @()
        $debxBJDone = 0
        for($i=1; $i -le $months; $i++){
            $yearOrder = [System.Convert]::ToString([System.Math]::Ceiling($i/12))
            $monthOrder = ($i%12)
            if($monthOrder -eq 0){
                $monthOrder = "12"
            }
            elseif($monthOrder -lt 10){
                $monthOrder = "0"+[System.Convert]::ToString($monthOrder)
            }else{
                $monthOrder = [System.Convert]::ToString($monthOrder)
            }

            # 等额本金明细计算
            $debjBJ = $debj1
            $debjLX = ($total - $debj1 * ($i-1)) * $rateMonth
            $debjTotal = $debjBJ + $debjLX
            # 等额本息明细计算
            $debxLX = ($total - $debxBJDone) * $rateMonth
            $debxBJ = $debx1 - $debxLX
            $debxTotal = $debxBJ + $debxLX
            $debxBJDone = $debxBJDone + $debxBJ

            $monthDetail = $null
            $monthDetail = [PSCustomObject]@{
                "月份" = $i
                "年份" = $yearOrder+"-"+$monthOrder
                "等额本金" = [System.Convert]::ToInt32($debjTotal)
                "本金1" = [System.Convert]::ToInt32($debjBJ)
                "利息1" = [System.Convert]::ToInt32($debjLX)
                "等额本息" = [System.Convert]::ToInt32($debxTotal)
                "本金2" = [System.Convert]::ToInt32($debxBJ)
                "利息2" = [System.Convert]::ToInt32($debxLX)
            }
            $result += $monthDetail
        }
        Write-Output $result | Format-Table
    }
}