namespace AlgAndDS.Algorithms;

public static class SortingAlgorithms
{
    public static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        bool swapped;

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    swapped = true;
                }
            }
            
            if(!swapped)
                break;
        }
    }

    public static void SelectionSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                    minIndex = j;
            }

            if (minIndex != i)
                (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]);
        }
    }

    public static void InsertionSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 1; i < n; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = key;
        }
    }

    public static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (right + left) / 2;
            
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }
    }

    public static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        for (int i = 0; i < n1; i++) 
            leftArray[i] = arr[left + i];
        for (int i = 0; i < n2; i++)
            rightArray[i] = arr[mid + i + 1];

        int i1 = 0, i2 = 0, k = left;

        while (i1 < n1 && i2 < n2)
        {
            if (leftArray[i1] <= rightArray[i2])
                arr[k++] = leftArray[i1++];
            else
                arr[k++] = rightArray[i2++];
        }

        while (i1 < n1) 
            arr[k++] = leftArray[i1++];

        while (i2 < n2) 
            arr[k++] = rightArray[i2++];
    }
}