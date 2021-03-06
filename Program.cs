
/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK
*/
//Anusha Kamath

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
//using System.Linq;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //2
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is: {0}", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 2, 3, 3 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
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
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();



            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();



            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "(]";
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


        }
        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

     
     //self reflection: learning to implement search algorithm and compute complexity
              public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                //Write your Code here.
                int low = 0;
                int high = nums.Length - 1; 
                int mid;
                int pos=0;
                while (low <= high)
                {
                    mid = low + (high - low) / 2; //compute mid

                    if (nums[mid] == target) //if target is at the mid return mid
                    {
                        return mid;
                    }
                    else if (nums[mid] > target) //if target>mid, check in the first half. 
                    {
                        high = mid - 1;
                        pos = mid;
                    }
                    else //else check for target in the second half
                    {
                        low = mid + 1;
                        pos = mid + 1; //if target is higher than the mid, position of the target will always be greater than the number below it. the process will go on until low is less than high.
                    }
                }

                return pos;
            
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* /*

         //Question 2

         //Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
         //The words in paragraph are case-insensitive and the answer should be returned in lowercase.
         //Example 1:
         //Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
         //Output: "ball"
         //Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
         //Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.
         //Example 2:
         //Input: paragraph = "a.", banned = []
         //Output: "a"
         //*/

     
     //self reflection: learning to work with dictionaries and regex
        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {

                //write your code here.

                string small = paragraph.ToLower(); //convert string to lowercase
                string[] words = new string[paragraph.Length];
                Regex reg = new Regex("[*'\".,_&#^@]");
                small = reg.Replace(small, ""); //replace all special characters with null character
                
                

                //Console.WriteLine(small);
                words = small.Split(' '); //convert string into an array
                Dictionary<String, int> dictionary = new Dictionary<string, int>(); 

                foreach (string word in words) // loop over the words
                {
                    if(!banned.Contains(word))//if word is not in the array of banned words
                    {
                        if (dictionary.ContainsKey(word)) //if it's in the dictionary
                            dictionary[word] = dictionary[word] + 1; //Increment the count
                        else
                            dictionary[word] = 1; //if its not, put it in the dictionary with a count 1
                    }
                      
                 
                }
                //Console.WriteLine(dictionary.Max()); //iterate over the dictionary and compare value(count) of each word against the maxcount
             //every time a highest count is found, its assigned to max count
                int maxcount = 0;

                foreach(string word in dictionary.Keys)
                {
                    if(dictionary[word]>maxcount)
                    {
                        maxcount = dictionary[word];
                       
                        
                    }
                }

                return dictionary.FirstOrDefault(x => x.Value == maxcount).Key; //returns the key of the highest count value
            }
            catch (Exception)
            {

                throw;
            }
        }

        ///*
        //Question 3:
        //Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        //Return the largest lucky integer in the array. If there is no lucky integer return -1.

        //Example 1:
        //Input: arr = [2,2,3,4]
        //Output: 2
        //Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        //Example 2:
        //Input: arr = [1,2,2,3,3,3]
        //Output: 3
        //Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
        //Example 3:
        //Input: arr = [2,2,2,3,3]
        //Output: -1
        //Explanation: There are no lucky numbers in the array.
        // */

     
     //self reflection: understnading arrays
        public static int FindLucky(int[] arr)
        {
            try
            {
             
             //sort the array
                Array.Sort(arr);
                int res = 0; //count
#pragma warning disable CS0162 // Unreachable code detected //warnings given in visual studio
                for (int i = arr.Length - 1; i >= 0; i--)  
#pragma warning restore CS0162 // Unreachable code detected
                {
                    res++;
                    if (i == 0 || arr[i] != arr[i - 1]) //check that i does not have similar value at i-1 position
                    {
                        if (res == arr[i]) //check if count is equal to i
                        {
                            return res; //return the lucky number (count)
                        }
                        res = 0;
                    }

                    
                }
                return -1; //if lucky number is not present
            }
            catch (Exception)
            {

                throw;
            }

         }

        ///*

        //Question 4:
        //You are playing the Bulls and Cows game with your friend.
        //You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        //•	The number of "bulls", which are digits in the guess that are in the correct position.
        //•	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        //Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        //The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.

        //Example 1:
        //Input: secret = "1807", guess = "7810"
        //Output: "1A3B"
        //Explanation: Bulls relate to a '|' and cows are underlined:
        //"1807"
        //  |
        //"7810"
        //*/


       //self reflection: learning on string comparison
        public static string GetHint(string secret, string guess)
        {
            try
            {
                char[] sec = secret.ToArray(); //convert both strings to char array
                char[] gs = guess.ToArray();
                int i=sec.Length-1;
                int count = 0;
                int count2 = 0;
                while(i>=0)
                {
                    if(sec[i]==gs[i]) //compare characters of secret and guess at ith position
                    {
                        i--; //decrement i
                        count++; //increase count if they are same
                    }
                    else if(gs.Contains(sec[i])) //if guess contains the ith value in char array, increment count2
                    {
                        i--;
                        count2++;
                    }
                    else
                    {
                        continue;
                    }
                }

                return count+"A"+count2+"B";

            }
            catch (Exception)
            {

                throw;
            }
        }


        ///*
        //Question 5:
        //You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        //Return a list of integers representing the size of these parts.
        //Example 1:
        //Input: s = "ababcbacadefegdehijhklij"
        //Output: [9,7,8]
        //Explanation:
        //The partition is "ababcbaca", "defegde", "hijhklij".
        //This is a partition so that each letter appears in at most one part.
        //A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
        //*/

     
     //learning the functioning of hash sets
        public static List<int> PartitionLabels(string s)
        {
            try
            {
                List<int> arrayList = new List<int>();
                if (s.Length == 0)
                {
                    return arrayList;
                }
                char[] arr = s.ToCharArray(); //convert to char array
                HashSet<Char> seen = new HashSet<Char>();
                int[] right = new int[26];
                foreach (char c in arr)
                {
                    right[c - 'a']++; //get the position of the character
                }
                int count = 0;

                foreach (char c in arr)
                {
                    count++;
                    seen.Add(c); //add seen elements to hashset
                    if (--right[c - 'a'] == 0)
                    {
                        seen.Remove(c);
                        if (seen.Count==0)
                        {
                            arrayList.Add(count);
                            count = 0;
                        }
                    }
                }
                return arrayList;

            }
            catch (Exception)
            {
                throw;
            }
        }

        ///*
        //Question 6
        //You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        //You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        //Return an array result of length 2 where:
        //     •	result[0] is the total number of lines.
        //     •	result[1] is the width of the last line in pixels.

        //Example 1:
        //Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        //Output: [3,60]
        //Explanation: You can write s as follows:
        //             abcdefghij  	 // 100 pixels wide
        //             klmnopqrst  	 // 100 pixels wide
        //             uvwxyz      	 // 60 pixels wide
        //             There are a total of 3 lines, and the last line is 60 pixels wide.
        // Example 2:
        // Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
        // s = "bbbcccdddaaa"
        // Output: [2,4]
        // Explanation: You can write s as follows:
        //              bbbcccdddaa  	  // 98 pixels wide
        //              a           	 // 4 pixels wide
        //              There are a total of 2 lines, and the last line is 4 pixels wide.
        // */

     //learning to work with lists and its functions
        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                //write your code here.
                List<int> res = new List<int>();
                
                int lines = 1, width = 0;
                foreach (char character in s.ToCharArray())
                {
                    int w = widths[character - 'a']; //get array value for each character
                    if(w+width>100) //if total width of the characters exceed 100, increment the count of lines
                    {
                        lines++;
                        width = 0; //for a new line, set the width to 0 again
                    }
                    width += w; //add characters to the same line
                }
                res.Add(lines); //create a list to return
                res.Add(width);


                return res;//return a list of lines and width of each line
            }
            catch (Exception)
            {
                throw;
            }

        }


        /*

        //Question 7:
        //Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        //An input string is valid if:
        //    1.	Open brackets must be closed by the same type of brackets.
        //    2.	Open brackets must be closed in the correct order.

        //Example 1:
        //Input: bulls_string = "()"
        //Output: true
        //Example 2:
        //Input: bulls_string  = "()[]{}"
        //Output: true
        //Example 3:
        //Input: bulls_string  = "(]"
        //Output: false
        //*/

     //Understnding the working of stacks and its functions
     //An intro about data types like this (methods and implementation) in class will be helpful.
        public static bool IsValid(string bulls_string10)
        {
            try
            {
                //write your code here.
                Boolean flag = true;

                Stack myStack = new Stack(); //Declare a stack

                for (int i = 0; i < bulls_string10.Length; i++) //check if i is equal to one of the paranthesis types
                {

                    if (bulls_string10[i].ToString() == "{" 
                       || bulls_string10[i].ToString() == "("
                       || bulls_string10[i].ToString() == "[")
                    {

                        myStack.Push(bulls_string10[i].ToString()); //if they are equal, push the items to the stack
                    }
                    else if (myStack.Count > 0) //when there are elements in the stack
                    {

                        if (bulls_string10[i].ToString() == "}") //when the open paranthesis has a matching closed paranthesis, pop it from the stack
                        {

                            if (myStack.Peek().ToString() == "{")
                            {
                                myStack.Pop();
                            }
                            else
                            {
                                flag = false; //if there is no matching paranthesis, set flag to false
                            }
                        }
                        else if (bulls_string10[i].ToString() == "]") //repeat the process for all kinds of paranthesis
                        {

                            if (myStack.Peek().ToString() == "[")
                            {
                                myStack.Pop();
                            }
                            else
                            {
                                flag = false;
                            }
                        }
                        else if (bulls_string10[i].ToString() == ")")
                        {

                            if (myStack.Peek().ToString() == "(")
                            {

                                myStack.Pop();
                            }
                            else
                            {
                                flag = false;
                            }
                        }
                    }
                    else
                    {
                        //Console.WriteLine(count + " " + s[i].ToString());
                        flag = false; //there are any other elements in the tsring, set flag to not valid
                    }
                }

                if (myStack.Count > 0)
                {
                    flag = false;
                }



                return flag; //if all the conditions meet, flag will return true which was initially set
            }
            catch (Exception)
            {
                throw;
            }


        }



        ///*
        // Question 8
        //International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        //•	'a' maps to ".-",
        //•	'b' maps to "-...",
        //•	'c' maps to "-.-.", and so on.
        //For convenience, the full table for the 26 letters of the English alphabet is given below:
        //[".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        //Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
        //    •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        //Return the number of different transformations among all words we have.

        //Example 1:
        //Input: words = ["gin","zen","gig","msg"]
        //Output: 2
        //Explanation: The transformation of each word is:
        //"gin" -> "--...-."
        //"zen" -> "--...-."
        //"gig" -> "--...--."
        //"msg" -> "--...--."
        //There are 2 different transformations: "--...-." and "--...--.".
        //*/

     //self reflection: learning to work with dictionaries and strings a little more
        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                //write your code here.
                // Stores Morse code of all
                // lowercase characters
                String[] morseCode = {".-", "-...", "-.-.",
                        "-..", ".", "..-.", "--.",
                        "....", "..", ".---", "-.-",
                        ".-..", "--", "-.", "---",
                        ".--.", "--.-", ".-.", "...",
                        "-", "..-", "...-", ".--",
                        "-..-", "-.--", "--.."};

                // Stores distinct elements of
                // String by replacing each
                // character by Morse code
                HashSet<String> st = new HashSet<String>();

                // Stores length of []arr array
                int N = words.Length;

                
                for (int i = 0; i < N; i++)
                {
                    // Store the Morse code of the array
                    
                    String temp = "";

                    // Stores length of
                    // current String
                    int m = words[i].Length;

                    for (int j = 0; j < m; j++)
                    {
                        // Update temp
                        temp += morseCode[words[i][j] - 'a'];
                    }

                    // Insert temp into st
                    st.Add(temp);
                }

                // Return count of elements
                // in the set
                return st.Count;
            }
            catch (Exception)
            {
                throw;
            }

        }




        /////*

        ////Question 9:
        ////You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        ////The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        ////Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).
        ////Example 1:
        ////Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        ////Output: 16
        ////Explanation: The final route is shown.
        ////We need to wait until time 16 so that (0, 0) and (4, 4) are connected.
        ////*/

        //public static int swiminwater(int[,] grid)
        //{
        //    try
        //    {
        //        //write your code here.
        //        return 0;
        //    }
        //    catch (exception)
        //    {

        //        throw;
        //    }
        //}

        /////*

        ////Question 10:
        ////Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        ////You have the following three operations permitted on a word:
        ////•	Insert a character
        ////•	Delete a character
        ////•	Replace a character
        //// Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.
        ////Example 1:
        ////Input: word1 = "horse", word2 = "ros"
        ////Output: 3
        ////Explanation: 
        ////horse -> rorse (replace 'h' with 'r')
        ////rorse -> rose (remove 'r')
        ////rose -> ros (remove 'e')
        ////*/

        ////public static int MinDistance(string word1, string word2)
        ////{
        ////    try
        ////    {
        ////        //write your code here.
        ////        return 0;

        ////    }
        ////    catch (Exception)
        ////    {

        ////        throw;
        ////    } 
        ////}
    }
}

