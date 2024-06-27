using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;
/*Array is set up with a contiguous block of memory. The computer keeps track of the beginning memory address example 1010 and if you make the size of the
array 5 elements that means you would have a block looking like this [1010][1011][1012][1013][1014]. So if you would try to add to that block for example
1015 the system would look at that as the next block available and throw an out of bounce error. */

public class Program
  {
/*Because an array is a contigous block of memory and the reference variable to the start of that block is stored in the reference variable
the reading of an array is very fast because it gets that variable lets say 1068 and let say you are looking for element 1 it adds one 1068 and is 
able to find that element very fast. In most cases reading from an array because it takes 1 step is big O(1)*/
     static string Reading(string[] arr, int index)
    {
        try
        {
            return arr[index];
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Error: Index is out of range.");
            return null;
        }
    }

//Searching is big O(n). Because you have to look through each elemennt until you find the value of the element. 
//Example if array is 5 elements and you are searching for the last element in the array you have to search big o(5)
      static int Searching(string[] arr, string search)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == search)
            {
                return i;
            }
        }
        return -1; // Not found
    }
    /*Inserting into an array Best case o(1) and worst case o(n+1) n being the number of steps to move the elements down and 1 being the insertion
    . This is determined if you insert at the end and nothing needs to be moved down
    o(1) and if you have to move all the items down then you move the down how many spots and then you have one more step of inserting the element
    The below algorithm checks the IsElementEMpty and if so adds to that spot so that is one step and if it isn't empty it then shift them down and then
    adds to that spot.*/    

    static string[] Insert(string[] arr, string value, int index){
    if (index < 0 || index >= arr.Length)
    {
        throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
    }
        
           if (IsElementEmpty(arr[index]))
    {
        arr[index] = value; // Insert the new value at index
    }
    else
    {
        // Shift elements to the right starting from index
        for (int i = arr.Length - 1; i > index; i--)
        {
            arr[i] = arr[i - 1];
        }
        arr[index] = value; // Insert the new value at index
    }

    return arr;
    /*Deleting Best case for deleting is o(1), where no elements have to get moved and worst case is o(n), n being the number of steps to shift. 
    The below checks if the index is greater or = 0 and less then the array. It then sets the index to null and calls the RemoveEmptyElements function
    to shift the elements if needed*/
}    static string[] IndexToDelete(string[] arr, int index){
               

               if(index >=0 && arr.Length > index){
                arr[index]= null;
                arr = RemoveEmptyElements(arr);
               }
        
        return arr;
    }

     // bool to check if elements are empty
    static bool IsElementEmpty(string arr){
        
            if(string.IsNullOrEmpty(arr)){
                 return true;
            }
        
        return false;

    }

/*********************************************************************************************
RemoveEmptyElements check to see if the element of the array being passed is empty and if not it addes the item to the temp array. This removes the empty
elements in the array and shifts them to the end. You could also do this with an array list to reduce the size of the array but I also want to be able to
add to this array. For this program I am writing this with the intention of the person knowing how big they need the array.
RemoveEmptyElement does the following: [1][2][][4][5]-->[1][2][4][5][]
*/
    static string[] RemoveEmptyElements(string[] arr){

        string[] arr2 = new string[arr.Length];
        int count=0;

         for(int i = 0; i < arr.Length; i++){
             
            if (!IsElementEmpty(arr[i])){
                arr2[count]=arr[i];
                count ++;


            }
         }
        return arr2;
    }
    
    static void Main(string[] args)
    {
      string[] cars = new string[5];

       cars[0]="Mustang";
       cars[1]="Corvette";
       cars[2]="Charger";
       cars[4]= "Prizm";
      
      int t= Searching(cars,"im");
      Console.WriteLine("t->{0}",t);
       bool x= IsElementEmpty(cars[1+2]);


       Console.WriteLine("test->{0}",x);

      cars= RemoveEmptyElements(cars);
      for(int i=0;i<cars.Length;i++){
        Console.WriteLine(cars[i]);
         Console.WriteLine(i);
      }
     int indexToDelete = 1;

        // Call method to delete element at index
        cars = IndexToDelete(cars, indexToDelete);
        cars =Insert(cars,"Accord",1);

        // Print the modified array
        Console.WriteLine("Array after deletion:");
        foreach (var item in cars)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("***********************************String Array Menu***************************************");

        // Print menu options with a pattern
        for (int i = 1; i <= 5; i++)
        {
            if(i == 1){
            Console.WriteLine($"{i}. Option {i} - Insert");
            }
            if(i == 2){
            Console.WriteLine($"{i}. Option {i} - Delete");  
            }
            if (i == 3){
            Console.WriteLine($"{i}. Option {i} - Read");     
            }
            if (i ==4){
            Console.WriteLine($"{i}. Option {i} - Search");  
            }
        }
       
        Console.WriteLine("\n0. Exit");
       
        // Wait for user input
        Console.Write("\nEnter your choice: ");
        string input = Console.ReadLine();

        // Process user input
        int choice;
        if (int.TryParse(input, out choice))
        {
switch (choice)
{
    case 0:
        Console.WriteLine("Exiting...");
        break;
    case 1:
        try
        {
            Console.WriteLine("String to Insert:");
            string insert = Console.ReadLine();
            Console.WriteLine("What element would you like to insert into:");
            int element = Convert.ToInt32(Console.ReadLine());
            cars = Insert(cars, insert, element);

            Console.WriteLine("Array after Insert:");
            foreach (var item in cars)
            {
                Console.WriteLine(item);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
        break;
    case 2:
        try
        {
            Console.WriteLine("What element would you like to delete:");
            int del = Convert.ToInt32(Console.ReadLine());
            cars = IndexToDelete(cars, del);

            Console.WriteLine("Array after Delete:");
            foreach (var item in cars)
            {
                Console.WriteLine(item);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
        break;
    case 3:
        try
        {
            Console.WriteLine("What element would you like to Read:");
            int ele = Convert.ToInt32(Console.ReadLine());

            string read = Reading(cars, ele);

            Console.WriteLine($"Array Read Results => {read}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
        break;
    case 4:
        Console.WriteLine("What string would you like to search:");
        string sewrd = Console.ReadLine();
        int search = Searching(cars, sewrd);
        if (search == -1)
        {
            sewrd = "Not Found";
        }
        Console.WriteLine($"{search} at {sewrd}");
        break;
  

    case 5:
                    Console.WriteLine($"You selected Option {choice}.");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
        
    }
    }