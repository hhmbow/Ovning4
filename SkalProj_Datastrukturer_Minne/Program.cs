using System.Collections;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        //FRÅGOR:
        /*  1- Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess 
grundläggande funktion
        Stacken:

Används för att hantera lokala variabler och metodanrop.
Snabb och effektiv med begränsad livslängd för variabler.
Heapen:

Används för att lagra objekt med dynamisk livslängd.
Kräver manuell eller automatisk minneshantering (garbage collection).
Används för större datamängder och objekt som behöver längre livslängd.
        void StackExample()
{
    int a = 5;  Variabeln 'a' lagras på stacken
    int b = 10;  Variabeln 'b' lagras på stacken
    int result = a + b; Variabeln 'result' lagras på stacken
}

        class HeapExample
{
    int[] array;  Objektet 'array' lagras på heapen eftersom det är en instansvariabel

    public HeapExample()
    {
        array = new int[1000];  Allokera minne på heapen för en array med 1000 heltal
    }
}


        2-  Vad är Value Types respektive Reference Types och vad skiljer dem åt? 
        Värdestyper (Value Types):

Lagrar själva värdet direkt.
Kopieras vid tilldelning.
Exempel: int, float, char, structs.
        int a = 5;
int b = a; Värdet av 'a' kopieras till 'b'
b = 10; Ändringen i 'b' påverkar inte värdet av 'a'


Referenstyper (Reference Types):
Lagrar en referens till värdet.
Delar samma data vid tilldelning.
Exempel: klasser, objekt, strängar.
Skillnaden ligger i hur de lagrar och hanterar data: 
värdestyper lagrar värdet direkt medan referenstyper lagrar en referens till data.

        int[] arr1 = { 1, 2, 3 };
int[] arr2 = arr1;  'arr1' refererar nu till samma array som 'arr1'
arr2[0] = 5;  Ändringen i 'arr2' påverkar också 'arr1'

         Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, den 
andra returnerar 4, varför?  
        Ändringen i 'y.Myvalue' påverkar också 'x.MyValue' 
         * */


        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {


            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                      + "\n5. Reverse Text"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                        ReverseText();
                        break;

                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            List<string> theList = new List<string>();

            while (true)
            {
                Console.WriteLine("Enter + to add or - to remove (e.g., +Adam or -Adam):");
                string input = Console.ReadLine()!;

                if (input.Length < 2)
                {
                    Console.WriteLine("Please provide input in the format: +/-Value");
                    continue;
                }

                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Added '{value}' to the list.");
                        Console.WriteLine($"List Count: {theList.Count}, Capacity: {theList.Capacity}");
                        break;

                    case '-':
                        if (theList.Remove(value))
                        {
                            Console.WriteLine($"Removed '{value}' from the list.");
                            Console.WriteLine($"List Count: {theList.Count}, Capacity: {theList.Capacity}");
                        }
                        else
                        {
                            Console.WriteLine($"'{value}' not found in the list.");
                        }
                        break;

                    default:
                        Console.WriteLine("Please use only '+' or '-' to add or remove.");
                        break;


                        /* 2 När ökar listans kapacitet? (Alltså den underliggande arrayens storlek) 
                         * Listans kapacitet ökar när antalet element i listan når dess aktuella kapacitet och ytterligare element ska läggas till.
                         * Vanligtvis fördubblas listans kapacitet när det inte finns tillräckligt med plats för att lägga till ett nytt element.
                         * 
                         3.       Med hur mycket ökar kapaciteten?
                        Vanligtvis fördubblas listans kapacitet när det inte finns tillräckligt med plats för att lägga till ett nytt element.
                        
                         4.       Varför ökar inte listans kapacitet i samma takt som element läggs till? 
                        Att fördubbla kapaciteten när det behövs ger en balans mellan prestanda och minnesanvändning.
                        Att öka kapaciteten vid varje enskilt elementtillskott skulle vara ineffektivt och leda till onödig minnesallokering.

                5.       Minskar kapaciteten när element tas bort ur listan? 
                        Nej, listans kapacitet minskar inte automatiskt när element tas bort ur listan. 
                        Kapaciteten förblir oförändrad tills du manuellt minskar den om det behövs för att spara minne.

                6.       När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
                        Det kan vara fördelaktigt att använda en egendefinierad array istället för en lista när du vet exakt antal element du behöver
                        och när du inte behöver lägga till eller ta bort element från mitten av listan. Egendefinierade
                        arrayer ger dig mer kontroll över minnesallokeringen och är effektiva när storleken är känd och konstant.

                                         * */
                }
                Console.WriteLine("Press Enter to continue or type 'e' to exit:");
                string exitInput = Console.ReadLine()!;
                if (exitInput != null && exitInput.ToLower() == "e")
                    break;
            }



        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        /// 

        static void ExamineQueue()
        {
            Queue queue = new Queue();

            while (true)
            {
                Console.WriteLine("Enter e: 'enqueue' to add an item or d: 'dequeue' to remove an item:");
                string input = Console.ReadLine()!;

                switch (input.ToLower())
                {
                    case "e":
                        Console.WriteLine("Enter the item to enqueue:");
                        string item = Console.ReadLine()!;
                        queue.Enqueue(item);
                        Console.WriteLine($"Item '{item}' enqueued.");
                        PrintQueue(queue);
                        break;

                    case "d":
                        if (queue.Count > 0)
                        {
                            object dequeuedItem = queue.Dequeue()!;
                            Console.WriteLine($"Item '{dequeuedItem}' dequeued.");
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty, cannot dequeue.");
                        }
                        PrintQueue(queue);
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please enter 'enqueue' or 'dequeue'.");
                        break;
                }
                Console.WriteLine("Press Enter to continue or type 'e' to exit:");
                string exitInput = Console.ReadLine()!;
                if (exitInput.ToLower() == "e")
                    break;


            }
            static void PrintQueue(Queue queue)
            {
                Console.WriteLine("Current Queue:");
                foreach (var item in queue)
                {
                    Console.WriteLine(item);
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>


        static void ExamineStack()
        {

            Stack stack = new Stack();
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            while (true)
            {
                Console.WriteLine("Enter 'push' to add an item or 'pop' to remove an item:");
                string input = Console.ReadLine()!;

                switch (input.ToLower())
                {
                    case "push":
                        Console.WriteLine("Enter the item to push:");
                        string itemToPush = Console.ReadLine()!;
                        stack.Push(itemToPush);
                        Console.WriteLine($"Item '{itemToPush}' pushed.");
                        PrintStack(stack);
                        break;

                    case "pop":
                        if (stack.Count > 0)
                        {
                            object poppedItem = stack.Pop()!;
                            Console.WriteLine($"Item '{poppedItem}' popped.");
                        }
                        else
                        {
                            Console.WriteLine("Stack is empty, cannot pop.");
                        }
                        PrintStack(stack);
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please enter 'push' or 'pop'.");
                        break;
                }

                Console.WriteLine("Press Enter to continue or type 'exit' to exit:");
                string exitInput = Console.ReadLine()!;
                if (exitInput.ToLower() == "exit")
                    break;


                /*
                 1. Simulera ännu en gång ICA-kön på papper. Denna gång med en stack. Varför är det 
                    inte så smart att använda en stack i det här fallet? 
                Eftersom vi vill att den första kunden som kommer ska vara den första som betjänas
                 */

            }
        }

        static void PrintStack(Stack stack)
        {
            Console.WriteLine("Current Stack:");
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }

        static void ReverseText()
        {
            Console.WriteLine("Enter the text you want to reverse:");
            string input = Console.ReadLine()!;

            // Create a stack to reverse the text
            Stack<char> charStack = new Stack<char>();

            // Push each character onto the stack
            foreach (char c in input)
            {
                charStack.Push(c);
            }

            // Pop each character from the stack to print the reversed text
            Console.Write("Reversed Text: ");
            while (charStack.Count > 0)
            {
                Console.Write(charStack.Pop());
            }
            Console.WriteLine();
        }




        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Console.WriteLine("Enter a string containing parentheses:");
            string input = Console.ReadLine()!;

            // Create a stack 
            Stack<char> stack = new Stack<char>();

            bool isValid = true;

            // Iterate through
            foreach (char c in input)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    // If the character is an opening parenthesis, push it onto the stack
                    stack.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    // If the character is a closing parenthesis
                    // Check if the stack is empty or the top of the stack does not match the current closing parenthesis
                    if (stack.Count == 0 || !IsMatchingPair(stack.Pop(), c))
                    {
                        isValid = false;
                        break;
                    }
                }

            }
            // Check if there are any remaining opening parentheses in the stack
            if (isValid && stack.Count == 0)
            {
                Console.WriteLine("Parentheses are correctly balanced.");
            }
            else
            {
                Console.WriteLine("Parentheses are incorrectly balanced.");
            }

        }
        //  method to check if a pair of parentheses are matching
        static bool IsMatchingPair(char opening, char closing)
        {
            return (opening == '(' && closing == ')') ||
                   (opening == '{' && closing == '}') ||
                   (opening == '[' && closing == ']');
        }


    }
}

