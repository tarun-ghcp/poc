namespace DocumentManagement.Common
{
    public class Match
    {
        // add a method to validate an email address
        public static bool IsValidEmail(string email)
        {
            // use simple regular expression to check
            // that the supplied email address string is valid
            return System.Text.RegularExpressions.Regex.IsMatch(email,
                               @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        }

        // add a method to validate a phone number with length as 10
        public static bool IsValidPhone(string phone)
        {
            // use simple regular expression to check
            // that the supplied phone number string is valid
            return System.Text.RegularExpressions.Regex.IsMatch(phone,
                                              @"^[0-9\-\(\)\s]*$");
        }

        // add a method to count no of words in a string
        public static int CountWords(string s)
        {
            // count words using regular expression
            System.Text.RegularExpressions.MatchCollection collection =
                System.Text.RegularExpressions.Regex.Matches(s, @"[\S]+");
            return collection.Count;
        }

        // add a method to find the tax payable based on the income
        public static double TaxPayable(double income)
        {
            // calculate tax payable based on income
            if (income <= 200000)
                return 0;
            else if (income <= 500000)
                return (income - 200000) * 0.1;
            else if (income <= 1000000)
                return 30000 + (income - 500000) * 0.2;
            else
                return 130000 + (income - 1000000) * 0.3;
        }

        // add a method to find the factorial of a number
        public static int Factorial(int n)
        {
            // calculate factorial of a number
            if (n == 0)
                return 1;
            else
                return n * Factorial(n - 1);
        }

        // check if the given number is prime
        public static bool IsPrime(int n)
        {
            // check if the given number is prime
            if (n <= 1)
                return false;
            else if (n <= 3)
                return true;
            else if (n % 2 == 0 || n % 3 == 0)
                return false;
            int i = 5;
            while (i * i <= n)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
                i = i + 6;
            }
            return true;
        }

        // find out how much memory is used by the current process
        public static long MemoryUsed()
        {
            // get the current process
            System.Diagnostics.Process currentProcess =
                System.Diagnostics.Process.GetCurrentProcess();
            // get the memory used by the current process
            return currentProcess.WorkingSet64;
        }

        // find out the active network connections on the machine
        public static string ActiveNetworkConnections()
        {
            // get the active network connections
            System.Net.NetworkInformation.IPGlobalProperties properties =
                System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties();
            System.Net.NetworkInformation.TcpConnectionInformation[] connections =
                properties.GetActiveTcpConnections();
            // return the active network connections
            string result = "";
            foreach (System.Net.NetworkInformation.TcpConnectionInformation connection in connections)
            {
                result += connection.LocalEndPoint.ToString() + " --> " +
                          connection.RemoteEndPoint.ToString() + "\n";
            }
            return result;
        }



    }       
    
}
