namespace BTTuan3;

public class Sort
{
    public static EDGE[] MergeSortEdges(EDGE[] array)
    {
        EDGE[] left;
        EDGE[] right;
        var result = new EDGE[array.Length];
        //As this is a recursive algorithm, we need to have a base case to 
        //avoid an infinite recursion and therfore a stackoverflow
        if (array.Length <= 1)
            return array;
        // The exact midpoint of our array  
        var midPoint = array.Length / 2;
        //Will represent our 'left' array
        left = new EDGE[midPoint];

        //if array has an even number of elements, the left and right array will have the same number of 
        //elements
        if (array.Length % 2 == 0)
            right = new EDGE[midPoint];
        //if array has an odd number of elements, the right array will have one more element than left
        else
            right = new EDGE[midPoint + 1];
        //populate left array
        for (var i = 0; i < midPoint; i++)
            left[i] = array[i];
        //populate right array   
        var x = 0;
        //We start our index from the midpoint, as we have already populated the left array from 0 to midpont
        for (var i = midPoint; i < array.Length; i++)
        {
            right[x] = array[i];
            x++;
        }

        //Recursively sort the left array
        left = MergeSortEdges(left);
        //Recursively sort the right array
        right = MergeSortEdges(right);
        //Merge our two sorted arrays
        result = Merge(left, right);
        return result;
    }

    //This method will be responsible for combining our two sorted arrays into one giant array
    private static EDGE[] Merge(EDGE[] left, EDGE[] right)
    {
        var resultLength = right.Length + left.Length;
        var result = new EDGE[resultLength];
        //
        int indexLeft = 0, indexRight = 0, indexResult = 0;
        //while either array still has an element
        while (indexLeft < left.Length || indexRight < right.Length)
            //if both arrays have elements
            if (indexLeft < left.Length && indexRight < right.Length)
            {
                //If item on left array is less than item on right array, add that item to the result array 
                if (left[indexLeft].EdgeWeight() <= right[indexRight].EdgeWeight())
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                // else the item in the right array wll be added to the results array
                else
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            //if only the left array still has elements, add all its items to the results array
            else if (indexLeft < left.Length)
            {
                result[indexResult] = left[indexLeft];
                indexLeft++;
                indexResult++;
            }
            //if only the right array still has elements, add all its items to the results array
            else if (indexRight < right.Length)
            {
                result[indexResult] = right[indexRight];
                indexRight++;
                indexResult++;
            }

        return result;
    }
}