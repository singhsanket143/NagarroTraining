using System;

public class Test
{
    static int lcs(string s1, string s2) {
        int[,] dp = new int[s1.Length+1, s2.Length+1];
        for(int i=0;i<=s1.Length;i++) {
            dp[i,0] = 0;
        }
        for(int i=0;i<=s2.Length;i++) {
            dp[0,i] = 0;
        }
        for(int i=1;i<=s1.Length;i++) {
            for(int j=1;j<=s2.Length;j++) {
                if(s1[i-1] == s2[j-1]) {
                    dp[i,j] = 1+dp[i-1,j-1];
                } else {
                    dp[i,j] = Math.Max(dp[i-1,j], dp[i,j-1]);
                }
            }
        }
        return dp[s1.Length,s2.Length];
        
    }
    
	public static void Main()
	{
		int result = lcs("abcdgh", "aedfhr");
		Console.WriteLine(result);
	}
}
