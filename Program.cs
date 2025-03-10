namespace Arrays_Ps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");

            //int result = MaxSubArray(new[]{1, -2, 1, -3, 4, -1, 2, 1, -10, 4 , 5}); // here 1st index should be 9 not 4

            // Console.WriteLine(result);


            //RemoveElement([3,2,2,3] , 3);
            MoveZeroes2([0, 1, 0, 3, 12]);

            Rotate([1, 2, 3, 4, 5, 6, 7] , 3);
        }


        // leetcode 53
        public static int MaxSubArray(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }

            int tempFirstIndex = 0;
            int tempLastIndex = nums.Length - 1;

            int tempSumPositives = 0;
            int tempSumNegatives = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[tempFirstIndex] <= 0)
                {
                    tempFirstIndex++;
                }
                else
                {
                    // here i have number greater than 0 
                    // check if all following +ve nums sum is greater than all following -ve nums sum
                    // if true , consider it as first index in subArray

                   

                    if (nums[i] >= 0)
                    {
                        if(tempSumNegatives < 0 && tempSumPositives > tempSumNegatives * -1)
                        {
                            break;
                        }
                        else if (tempSumNegatives < 0 && tempSumPositives <= tempSumNegatives * -1)
                        {
                            tempFirstIndex = i;
                            tempSumPositives = 0 + nums[i];
                            tempSumNegatives = 0;
                            continue;
                        }

                        tempSumPositives += nums[i];
                    }
                    else
                    {
                        tempSumNegatives += nums[i];
                    }

                }
            }

            return tempFirstIndex;



        }






        // leetcode 27
        public static int RemoveElement(int[] nums, int val)
        {
            int result = nums.Length;

            Stack<int> stack = new Stack<int>();

            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    result--;
                }
                else
                {
                    stack.Push(nums[i]);
                }
            }

            for(int i = 0; i < result; i++)
            {
                nums[i] = stack.Pop();
            }

            return result;
        }



        // other solution
        public static int RemoveElement2(int[] nums, int val)
        {
            int result = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                if(nums[i] != val)
                {
                    nums[result++] = nums[i];
                }
            }

            return result;
        }





        /// leetcode 283
        public static void MoveZeroes(int[] nums)
        {
            int zeroCount = 0;
            int lastIndex = nums.Length - 1;

            for(int i = 0; i < nums.Length - zeroCount; i++)
            {
                if (nums[i] == 0)
                {
                    while (nums[lastIndex - zeroCount] == 0 && lastIndex >= zeroCount)
                    {
                        zeroCount++;
                    }
                    if(i < nums.Length - zeroCount)
                    {
                        swap(nums, i, lastIndex - zeroCount);
                    }

                }
            }
        }

        // better solution
        public static void MoveZeroes2(int[] nums)
        {
           for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    int tempNextIndex = i + 1;
                    while(tempNextIndex < nums.Length && nums[tempNextIndex] == 0)
                    {
                        tempNextIndex++;
                    }
                    if(tempNextIndex < nums.Length)
                    {
                        swap(nums, i, tempNextIndex);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        public static void swap(int[] nums, int firstIndex , int secondIndex)
        {
            int temp = nums[firstIndex];
            nums[firstIndex] = nums[secondIndex];
            nums[secondIndex] = temp;
        }


        public static void Rotate(int[] nums, int k)
        {
            int[] tempNums = new int[nums.Length];

            for(int i = 0; i < nums.Length; i++)
            {
                tempNums[i] = nums[i];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if(i + k < nums.Length)
                {
                    nums[i + k] = tempNums[i];
                }

                else
                {

                    int newIndex = i + k - nums.Length;

                    while(newIndex >= nums.Length)
                    {
                        newIndex -= nums.Length;
                    }
                    nums[newIndex] = tempNums[i];
                }
            }
        }
    }
}
