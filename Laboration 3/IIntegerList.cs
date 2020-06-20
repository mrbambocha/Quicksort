///<summary>///IIntegerList
///IIntegerList är en abstrakt datatyp som består av vars värden är sammanhållna
///i en linjär följd. Den ena änden utgör listans topp och den andra listans botten.
public interface IIntegerList
{
    ///<summary>///
    ///Add value to top of list
    void Push(int number);

    ///<summary>///
    ///Fet and removes a value at top of list
    int Pop();

    ///<summary>///
    ///Fetch and removes a value at bottom of list
   
    int Shift();

    ///<summary>///
    ///Sorts list in ascending order, 0, 1, 2, 3... 999
    void SortAscending();

    ///<summary>///
    ///Sorts list in descending order, 999, 998, 997, 996... 0
    void SortDescending();
    
    ///<summary>///
    ///Return List as array
    int[] ToArray();
}