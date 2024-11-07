using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class MergeSort : ISortAlgorithm
{
    public int[] Sort(int[] arr)
    {
        if (arr.Length <= 1) return (int[])arr.Clone();
        int mid = arr.Length / 2;
        int[] left = Sort(arr[..mid]);
        int[] right = Sort(arr[mid..]);
        return Merge(left, right);
    }

    private int[] Merge(int[] left, int[] right)
    {
        int[] result = new int[left.Length + right.Length];
        int i = 0, j = 0, k = 0;
        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
                result[k++] = left[i++];
            else
                result[k++] = right[j++];
        }
        while (i < left.Length) result[k++] = left[i++];
        while (j < right.Length) result[k++] = right[j++];
        return result;
    }
}
