using System;

public class Test
{
    static int lps(string s1) {
        int[,] dp = new int[s1.Length, s1.Length];
        for(int i=0;i<s1.Length;i++) {
            dp[i,i] = 1;
        }
        for(int len=2;len<=s1.Length;len++) {
            for(int i=0;i<=s1.Length-len;i++) {
                int j = i+len-1;
                if(s1[i] == s1[j]) {
                    dp[i,j] = 2+dp[i+1,j-1];
                } else {
                    dp[i,j] = Math.Max(dp[i+1,j], dp[i,j-1]);
                }
            }
        }
        return dp[0,s1.Length-1];
        
    }
    
	public static void Main()
	{
		int result = lps("nagarro");
		Console.WriteLine(result);
	}
}
