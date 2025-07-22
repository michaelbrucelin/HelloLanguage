# 比较两个文件夹是否一致
# 1. 比较文件的大小
# 2. 文件大小相同
#     2.1. 随机抽样字节对比
#     2.2. 比较文件头尾是否一致
#     2.3. 比较文件的MD5

function MyCompare-Files {
    param([string]$file1, [string]$file2)

    try {
        $info1 = Get-Item $file1
        $info2 = Get-Item $file2

        # 比较文件的大小
        if ($info1.Length -ne $info2.Length) {
            return [PSCustomObject]@{
                Success = $false
                Message = "文件大小不同"
            }
        }

        $length = $info1.Length
        # 文件如果小于等于1MB，直接比较MD5
        if ($length -gt 1024 * 1024) {
            # 比较5个抽样字节
            $positions = @(
                0,
                [int]($length / 3),
                [int]($length * 2 / 3),
                $(Get-Random -Minimum 1 -Maximum ([int]($length / 2))),
                $(Get-Random -Minimum ([int]($length / 2)) -Maximum ($length - 2))
            )

            $fs1 = [System.IO.File]::OpenRead($file1)
            $fs2 = [System.IO.File]::OpenRead($file2)

            foreach ($pos in $positions) {
                $fs1.Seek($pos, 'Begin') | Out-Null
                $fs2.Seek($pos, 'Begin') | Out-Null
                if ($fs1.ReadByte() -ne $fs2.ReadByte()) {
                    $fs1.Close(); $fs2.Close();
                    return [PSCustomObject]@{
                        Success = $false
                        Message = "抽样字节不同"
                    }
                }
            }

            # 比较文件的头部
            $headSize = [Math]::Min(512, [int]($length / 2))
            $buf1 = New-Object byte[] $headSize
            $buf2 = New-Object byte[] $headSize

            $fs1.Seek(0, 'Begin') | Out-Null
            $fs2.Seek(0, 'Begin') | Out-Null
            $fs1.Read($buf1, 0, $headSize) | Out-Null
            $fs2.Read($buf2, 0, $headSize) | Out-Null
            if (-not ($buf1 -ceq $buf2)) {
                $fs1.Close(); $fs2.Close();
                return [PSCustomObject]@{
                    Success = $false
                    Message = "文件头不同"
                }
            }

            # 比较文件的尾部
            $fs1.Seek(-1 * $headSize, 'End') | Out-Null
            $fs2.Seek(-1 * $headSize, 'End') | Out-Null
            $fs1.Read($buf1, 0, $headSize) | Out-Null
            $fs2.Read($buf2, 0, $headSize) | Out-Null
            $fs1.Close(); $fs2.Close();
            if (-not ($buf1 -ceq $buf2)) {
                return [PSCustomObject]@{
                    Success = $false
                    Message = "文件尾不同"
                }
            }
        }

        # 比较文件的MD5
        $hash1 = Get-FileHash -Path $file1 -Algorithm MD5
        $hash2 = Get-FileHash -Path $file2 -Algorithm MD5
        if ($hash1.Hash -ne $hash2.Hash) {
            return [PSCustomObject]@{
                Success = $false
                Message = "文件哈希不同"
            }
        }

        return $null
    }
    catch {
        return "读取失败: $_"
    }
}

function MyCompare-Folders {
    param([string]$folder1, [string]$folder2)

    Write-Host "`n"
    Write-Host "----------------------------------------------------------------"
    Write-Host "Start to compare folders: " -ForegroundColor Cyan
    Write-Host "source folder: $folder1"
    Write-Host "target folder: $folder2"
    Write-Host "----------------------------------------------------------------"

    $differences = @()

    # 1. 遍历 folder1，检查内容 + 缺失
    $files1 = Get-ChildItem -Path $folder1 -Recurse -File -Force
    foreach ($f1 in $files1) {
        $rel = $f1.FullName.Substring($folder1.Length).TrimStart('\')
        $f2 = Join-Path $folder2 $rel

        if (-not (Test-Path $f2)) {
            $differences += "❌ 缺失: $rel"
        }
        else {
            $result = MyCompare-Files $f1.FullName $f2
            if (!$result.Success) {
                $differences += "❌ 差异: $rel, $result"
            }
        }
    }

    # 2. 遍历 folder2，查找“多余”的文件
    $files2 = Get-ChildItem -Path $folder2 -Recurse -File -Force
    foreach ($f2 in $files2) {
        $rel = $f2.FullName.Substring($folder2.Length).TrimStart('\')
        $f1 = Join-Path $folder1 $rel

        if (-not (Test-Path $f1)) {
            $differences += "❌ 多余: $rel"
        }
    }

    # 结果输出
    if ($differences.Count -eq 0) {
        Write-Host "`n✅ 文件夹完全一致" -ForegroundColor Green
    }
    else {
        Write-Host "`n❌ 差异文件如下：" -ForegroundColor Red
        $differences | ForEach-Object { Write-Host $_ }
    }
}
