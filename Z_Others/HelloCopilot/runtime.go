package main

type Run struct {
	Time    int // in milliseconds
	Results string
	Failed  bool
}

// Get average runtime of successful runs in seconds
func averageRuntimeInSeconds(runs []Run) float64 {
	var totalTime int
	var totalRuns int
	for _, run := range runs {
		if !run.Failed {
			totalTime += run.Time
			totalRuns++
		}
	}
	return float64(totalTime) / float64(totalRuns) / 1000.0
}
