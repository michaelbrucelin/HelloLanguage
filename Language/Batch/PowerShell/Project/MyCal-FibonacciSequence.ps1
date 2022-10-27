function MyCal-FibonacciSequence([Int]$Index) {
    $lastValue = 1
    $currentValue = 1
    For ($iteration = 2; $iteration -le $Index; $iteration++) {
        $newValue = $lastValue + $currentValue
        $lastValue = $currentValue
        $currentValue = $newValue

        write-host $currentValue
    }
}
