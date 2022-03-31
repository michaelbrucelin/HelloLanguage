function myrun-csharp() {
    pwsh -Command "(Add-Type -Path '${1}' -PassThru)::Main()"
}
