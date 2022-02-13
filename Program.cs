using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 1, 7, 10, 13 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = {"hit"};
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is :{0}", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 2, 3, 3 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is: {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1123";
            string guess = "0111";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + " ");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 4, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "bbbcccdddaaa";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "{}()";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }

/// <summary>
/// The SearhInsert takes in two argumnets nums where an array of sorted intergers is passed and a target integer, the number which is to be inserted in the array.
/// The index of the num is to be found out if it were to be inserted in the given number list. I have implemented binary search since all the numbers are sorted in the array.
/// Since the first index element is always less than the last I used a while loop for the same and found out the middle index if the middle is less than the target then the number has to be there in the left of the tree
/// else the number has to be in the right of the array. 
/// </summary>
/// <param name="nums">The array of sorted intergers</param>
/// <param name="target">The target number for the which the index has to be found out if inserted in an array</param>
/// <returns>ans which is the index of the number that is given in input if it were to be inserted in the aray</returns>

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int first = 0; //Inniatilizing first number with zero.
                int res = -1; //Result is initialized with -1
                int last = nums.Length - 1;
                while (first <= last)
                {
                    int middle = (first + last) / 2; //Finiding the middle number in the array.
                    if (nums[middle] == target) //If the target number is in the middle the it returns the middle index
                    {
                        return middle;

                    }
                    if (nums[middle] < target)//searches in the left of the array.
                    {
                        first = middle + 1;//middle is incremented by 1 and is stored in the first variable
                        res = middle + 1;//res is incremented by 1
                    }
                    else
                    {
                        res = middle;//if targer is greather than the res then it searches in the right of the array.
                        last = middle - 1;//middle is decremented by 1 and is stored in the last variable.


                    }

                }
                return res;//returns the index of the inserted target variable
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
                
            }
        }

       /// <summary>
       /// The MostCommonWord takes in two arguments paragrah a string and array of banned words that are to be removed from the list. The string should not contain the characters and should not have any spaces.
       /// A stringbuilder is used to replace all the punctuations and then is converted to a string and is split which is stored in an array.
       /// A Dictionary is used to count the no of times a word is counted in a string. If the banned word loop is true then it is exited from the if loop and if it false then the if becomes true. 
       /// The the occurences of the word is counted. If the word is not present then the word is counted zero and then incremented if the word is found.
       /// A key value pair is used to count and retrive the maximum times a word is repeated after removing the banned word.
       /// </summary>
       /// <param name="paragraph">It contains the string which has the punctuation.</param>
       /// <param name="banned">The word that has to be removed from the string</param>
       /// <returns>count of the maximum repeated element</returns>

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {

                string s = paragraph.ToLower().Trim();//Converts the string into lower case letters and removes the spaces in the string.
                StringBuilder sb = new StringBuilder(s);//Replaces all the punctuation with the empty string.
                sb.Replace(",", "");
                sb.Replace(".", "");
                sb.Replace("!", "");
                sb.Replace("?", "");
                sb.Replace("'", "");
                sb.Replace(";", "");
                sb.Replace(",", "");
                string[] s1 = sb.ToString().Split(' ');//Converts the string builder to string and the splits the string and stores in the array.

                Dictionary<string, int> dict = new Dictionary<string, int>();//Initialize an dictionary to map the number of times a word is repeated
                for (int i = 0; i < s1.Length; i++)
                {
                    string s2 = s1[i];               //store the incoming string of the stringbuilder in to a string.
                    if (string.IsNullOrEmpty(s2))
                    {
                        continue;
                    }
                    if (!banned.Contains(s2))//if the string(word) is not present in the list of banned words then this loop is executed
                    {
                        if (dict.ContainsKey(s2)) dict[s2] += 1; //If the key is present is then the value is incremented by 1

                        else dict.Add(s2, 0); //If the key is absent then the intial value of the key is zero then the if the loop is executed the value is incremented by 1
                       
                    }
                }

                KeyValuePair<string, int> max_value = new KeyValuePair<string, int>();//Key value pair is used to retrieve the count of the maximum repeated element.
                int c = 0;
                foreach (var kvp in dict)
                {
                    if (c == 0) max_value = kvp;//if the count is zero then the max value is initialized with the kry value pair.

                    if (kvp.Value > max_value.Value) max_value = kvp;// if the current key value pair value is greater than the maximum key value key then the count is incremented

                    c++;
                }
                return max_value.Key;//The value of the key which is the maximum repeated value is returned.

            }
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

      /// <summary>
      /// The FindLucky method takes in array of numbers as an input and returns the number that is repeated according to its number. The result array stores the count of the elements that are repeated.
      /// The result array is incremented by number of times the number is repeated.
      /// If the number are repeated the same times as their integer value then tha largest of the two is returned. If none of the condition is satisfied then -1 is returned.
      /// </summary>
      /// <param name="arr">Contains the numbers that is passed an in input</param>
      /// <returns>the lucky number i</returns>

        public static int FindLucky(int[] arr)
        {
            try
            {

                int[] res = new int[501];//array is intialized with its size.
                foreach (int num in arr) res[num]++;//the count of the numbers is which are in the array is incremented.
                
                for (int i = 500; i > 0; i--)
                {
                    if (res[i] == i) return i; //if the no of times the number is repeated is equal to the number itself then the number is returned.
                   
                }
                return -1;//else the code returns -1

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

      /// <summary>
      /// The GetHint method takes in two strings secret and guess which are integers. The core of the code depends upon find the ascii code and then take the difference of the interger ascii code and the ascii code of 0
      /// Then increment the secret count and decrementing the guess count to find the size of no.of guess and no.of secret arrays which has the no .of times a a guess is given for the secret number.
      /// </summary>
      /// <param name="secret">The string that has the integers</param>
      /// <param name="guess">The string that has the integers</param>
      /// <returns>string in the form of xAyB where x is bulls_count and y is cows_Count</returns>

        public static string GetHint(string secret, string guess)
        {
            try
            {
                int bc= 0; //Intializing bulls count with 0
                int[] arr = new int[100]; //Intializing the size of an array
                //int asci_code = (int)'0';
                for (int i = 0; i < secret.Length; i++)// looping the secret string length
                    if (secret[i] == guess[i]) bc++; //If the index of the secret is equal to the index of the guess then the count of the bulls is incremented.                                   
                    else
                    {
                        int sc = (int)secret[i] - '0';//The ascii value of the number at the index i is found for secret count
                        int gc = (int)guess[i] - '0';//The ascii value of the number at the index i is found for guess count
                        arr[sc] += 1;
                        arr[gc] -= 1;
                    } 

                var cc = guess.Length - bc; //Innitializing the variale cc which has the difference value of the guess word length annd bullscount

                foreach (var n in arr) //For going through the each element in the list of the array.
                {
                    if (n < 0) cc += n; //The cows count is increments by the value of n which is obtained by looping through the array(arr).
                        
                }
                return $"{bc}A{cc}B";//Since the optput is in the format of xAyB where A is bulls count and B is cows count, the particular string is returned.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


     /// <summary>
     /// The partitionLabels methods takes in string as an input and returns the length of the strings after partition where each of the string has the letters that are not repeated in the other partition.
     /// The last occurence of the first letter has to be found out and then inside the first and last occurence find the last of the element present in between the two letters.
     /// In the list add the elements after the partition is done and find out the size of the each partition. Return the length of each partition.
     /// </summary>
     /// <param name="s">The that has to be partitioned</param>
     /// <returns>Length of the each partioned string</returns>
        public static List<int> PartitionLabels(string s)
        {
            try
            {
                //write your code here.

                int[] arr = new int[128]; //Initialize the array with the size
                char[] chars = s.ToCharArray(); //Convert the entire string to character array.
                for (int i = 0; i < chars.Length; i++) arr[chars[i]] = i;//Then the array arr has the characters at the specifies index 
                int left = 0, right = 0;//for finding the first and last occurence of the character
                List<int> res = new List<int>();//for adding the partition strings and find their length
                while (left < chars.Length)//Since left is '0' and the character lenght is the size of the chars array the loop is executed
                 {
                    right = arr[chars[left]];//The right element has to the last occurence of the character that we are trying to find out.
                    for (int i = left; i < right; i++) right = Math.Max(right, arr[chars[i]]);//The right element where the partiton has to take place is out found by using max function. This is used to to get the maxposition of the element we are looking for and the that is not repeatd in other partitions.

                    res.Add(right - left + 1); //Add the strings into the list.
                    left = right + 1;// left is incremented by value of right and +1. This makes left start at the second partition.
                }
                return res;//It returns the lengths of the partioned strings
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

      /// <summary>
      /// NumberOfLines takes in an array of widths i.e the pixel lenght of each character. The core logic is to identify the width of each character present in the string add sum it up untill it reaches 100.
      /// The output should be the total sum of the left out characters length referencing to pixels(width array) and the number of lines it to complete the total sum of the characters present in the string.
      /// </summary>
      /// <param name="widths">The pixel length for each character</param>
      /// <param name="s">The string that is passed</param>
      /// <returns>The sum of the lefout characters and the number of lines it to achieve it</returns>
        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                int tp = 0; //Initializing the total pixles variable
                int tl = 1; //Intializing the total lines variable
                foreach (char c in s.ToCharArray()) //For iterating the each characters in the string
                {
                    tp = tp + widths[c - 'a']; //add the pixel length of each character present in the widhts array
                    if (tp > 100) //If total sum of the pixel is greater than 100 then increment the total lines variable
                    {
                        tp = widths[c - 'a']; //add the pixel length of each character present in the widhts array
                        tl++; //incrementing the total lines variable
                    }
                }


                return new List<int>() { tp, tl }; //Returns the list of total lines and total sum of the leftout pixels
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }


 /// <summary>
 /// To find if the string is valid or not first check the string has an length of even number. Using stacks and its methods pop and push conjugated with dictionary methods we can find the given is valid or not.
 /// Push into the stack if the string contains the key in the characters. Else if the character is present in the value the use pop untill all the elements are removed and the count is zero then it is a valid
 /// string else it is not a valid string.
 /// </summary>
 /// <param name="bulls_string10">Contains the all the paranthesis character such as {}{}()</param>
 /// <returns>If the given paranthesis string is valid or not i.e the fuction returns a boolean value</returns>

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                Dictionary<char, char> dict = new Dictionary<char, char>();//dict represents a dictionary where the given opening characters are mapped with the same closing characters.
                dict['{'] = '}';
                dict['['] = ']';
                dict['('] = ')';
                if (bulls_string10.Length % 2 != 0) return false;//Since to make the string with characters complete the length of the string should be an even number.
                Stack<Char> st = new Stack<char>();// Intialize a stack which has push and pop operations.
                foreach (char c in bulls_string10)//loop through each charcters in the string input
                {
                    if (dict.ContainsKey(c))//If the dictionary contain the key in the input then the corresponding value is pushed into the stack
                    {
                        st.Push(dict[c]);
                    }
                    else if (dict.ContainsValue(c))//If the input string has the value that is present as the value in the dictionary then this satement is executed
                    {
                        if (st.Count == 0) return false;//If the stack count is zero then false is returned
                        if (st.Pop() != c) return false;//If the current value we are is not equal to the character we are trying to pop(remove) then the method returns false
                    }
                    else return false;
                }
                return (st.Count == 0);//After sucessfully removing all the elements from the stack, if the count of the stack is zero then true is returned.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }



        /// <summary>
        /// The UniqueMorseRepresentations takes in array of words as an input it computes the concatination of the morse codes for the specific characters.
        /// If after concatination the two words has the same morse codes the hashset is used to remove the repeating morse code words.
        /// </summary>
        /// <param name="words">Array of words which are string</param>
        /// <returns>The no of elements in the hashset</returns>

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                //Morse codes for all the english alphabets.
                string[] morse = new String[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                //char[] morsearray = morse.ToCharArray();
                //List<String> li = new List<string>();
                var hs = new HashSet<string>();//For removing the common morse code for a specific word
                foreach (string word in words)
                {
                    string s = "";//Intializing empty string
                    foreach (char c in word.ToCharArray())
                    {
                        s += morse[c - 'a'];//It access the index of the morse array for the specific character in the string present in the words array
                    }
                    hs.Add(s);//add the resultant string to the hashset
                }
                return hs.Count;//count the no of elements in the hashset
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }




        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).
        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.
        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
                //write your code here.
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:
        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.
        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')
        */

        public static int MinDistance(string word1, string word2)
        {
            int m = word1.Length, n = word2.Length;
            char[] s = word1.ToCharArray();
            char[] s1 = word2.ToCharArray();
            int[] dp = new int[n + 1];

            for (int j = 0; j <= n; j++)
            {
                dp[j] = j;
            }

            for (int i = 1; i <= m; i++)
            {
                int[] newDp = new int[n + 1];
                newDp[0] = i;
                for (int j = 1; j <= n; j++)
                {
                    if (s[i - 1] == s1[j - 1])
                        newDp[j] = dp[j - 1];
                    else
                        newDp[j] = Math.Min(dp[j - 1] + 1,Math.Min( dp[j] + 1, newDp[j - 1] + 1));
                }
                dp = newDp;
            }
            return dp[n];
        }
        private int min(int a, int b, int c)
        {
            if (a <= b && a <= c) return a;
            else if (b <= a && b <= c) return b;
            else return c;
        }
    }
}
