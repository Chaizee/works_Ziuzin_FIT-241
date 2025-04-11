class Array<T>
{
    int Lenght { get; set; }
    int Index { get; set; }
    const int defaultLenght = 5;
    T[] arr;


    public Array()
    {
        arr = new T[defaultLenght];
        Lenght = defaultLenght;
    }
    public Array(int lenght)
    {
        if (lenght < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        arr = new T[lenght];
        Lenght = lenght;
    }

    public void addInArray(T value)
    {
        if (Index >= Lenght)
        {
            Resize();
        }
        arr[Index] = value;
        Index++;
    }

    public void Resize()
    {
        int newLenght = Lenght * 2;
        T[] newArr = new T[newLenght];

        for (int i = 0; i < Lenght; i++)
        {
            newArr[i] = arr[i];
        }
        Lenght = newLenght;
        arr = newArr;
    }

    public void deleteByIndex(int index)
    {
        if (index >= Lenght || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        for (int i = index; i < index - 1; i++)
        {
            arr[i] = arr[i + 1];
        }
        arr[index - 1] = default;
        index--;
    }

    public T searchByIndex(int index)
    {
        if (index >= Lenght || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        return arr[index];
    }
}