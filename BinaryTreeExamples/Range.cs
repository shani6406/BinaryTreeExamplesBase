using System;

public class Range
{
	public Range()
	{
		private int low;
	    private int high;

	public Range(int low, int high)
	{
		this.low = low;
		this.high = high;
	}
	public int GetLow()	{ return low; }
	public int GetHigh() { return high; }
	public void SetLow(int low) { this.low = low; }
	public void SetHigh(int high) { this.high = high; }

	}
}
