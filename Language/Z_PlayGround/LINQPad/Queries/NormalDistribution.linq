<Query Kind="Program" />

void Main()
{
	Random random = new Random();
	double mean = 100, stddev = 10;
	double[] arr = new double[10000];
	for (int i = 0; i < 10000; i++)
		arr[i] = GetNotmalNum(random, mean, stddev);
	
	arr.Average().Dump();
	arr.OrderBy(i => i).Dump();
}

/// <summary>随机产生一个符合正态分布的数 mean均数，stddev为方差</summary>
public static double GetNotmalNum(Random random, double mean, double stddev)
{
	// The method requires sampling from a uniform random of (0,1]
	// but Random.NextDouble() returns a sample of [0,1).
	double x1 = 1 - random.NextDouble();
	double x2 = 1 - random.NextDouble();
	double y1 = Math.Sqrt(-2.0 * Math.Log(x1)) * Math.Cos(2.0 * Math.PI * x2);

	return y1 * stddev + mean;
}

