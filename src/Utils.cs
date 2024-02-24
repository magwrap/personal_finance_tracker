namespace Tracker
{
    class Utils
    {
        public static string GetInput(string prompt)
        {
            string? input;

            do
            {
                if (!String.IsNullOrEmpty(prompt))
                {
                    Console.Write(prompt + " ");
                }
                Console.WriteLine("\U000027A4");
            }
            while (string.IsNullOrEmpty(input = Console.ReadLine()));

            input = input.ToString().Normalize().ToLower().Trim();

            return input;
        }

        public static void Clear()
        {
            Console.ResetColor();
            Console.Clear();
        }

        public static ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public static void MoveCursorUp(int val = 1)
        {
            try
            {

                Console.CursorTop -= val;
            }
            catch
            {
                Console.WriteLine("Can't move cursor up!");
            }
        }

        public static void MoveCursorDown(int val = 1)
        {
            try
            {

                Console.CursorTop += val;
            }
            catch
            {
                Console.WriteLine("Can't move cursor down!");
            }
        }

        public static void MoveCursorLeft(int val)
        {
            try
            {

                Console.CursorLeft -= val;
            }
            catch
            {
                Console.WriteLine("Can't move cursor left!");
            }
        }

        public static void MoveCursorRight(int val)
        {
            try
            {
                Console.CursorLeft += val;
            }
            catch
            {
                Console.WriteLine("Can't move cursor right!");
            }
        }


        public static int GetUserOption(string[] options, string text = "Choose an option:")
        {
            int selectedOption = 0;

            Console.WriteLine(text);


            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(
                  $"{(i == selectedOption ? "\U000027A4 " : " ")} {options[i]}"
                );
            }

            MoveCursorUp(options.Length);

            while (true)
            {
                var key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow when selectedOption > 0:
                        Console.Write($"\r {options[selectedOption]}".PadRight(10));
                        MoveCursorUp();
                        selectedOption = Math.Max(0, selectedOption - 1);
                        Console.Write($"\r\U000027A4 {options[selectedOption]}".PadRight(10));

                        break;

                    case ConsoleKey.DownArrow when selectedOption < options.Length - 1:
                        Console.Write($"\r {options[selectedOption]}".PadRight(10));
                        MoveCursorDown();
                        selectedOption = Math.Min(options.Length - 1, selectedOption + 1);
                        Console.Write($"\r\U000027A4 {options[selectedOption]}".PadRight(10));

                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        // Console.Write($"You chose: {options[selectedOption]}".PadRight(11));
                        return selectedOption;
                }
            }
        }

        public static void GetEnterConfirmation()
        {
            while (true)
            {
                Console.WriteLine("Press ENTER to continue:");
                var key = Console.ReadKey().Key;

                if (key == ConsoleKey.Enter) return;
            }

        }

    }
}
