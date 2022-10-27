<#
    下面是一个通过outlook发送邮件的函数，函数并不完善，但是是一个思路。
#>
function MySend-OutlookMail() {
    param(
        [Parameter(Mandatory = $true)] $To,
        [Parameter(Mandatory = $true)] $Subject,
        [Parameter(Mandatory = $true)] $BodyText,
        [Parameter(Mandatory = $true)] $AttachmentPath
    )

    $outlook = New-Object -ComObject Outlook.Application
    $mail = $outlook.CreateItem(0)
    $mail.Subject = $Subject
    $mail.to = $To

    $mail.BodyFormat = 1  # use 2 for HTML mails
    $mail.Attachments.Add([object]$AttachmentPath, 1)
    $mail.building = $BodyText
    $mail.Display($false)
}
