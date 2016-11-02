$invocation = (Get-Variable MyInvocation).Value
$path = Split-Path $invocation.MyCommand.Path

cd $Path;

.\GeckoPet.exe "http://localhost:8000/echo.php" "GeckoPet"