// Importing System libraries to run basic commands.

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

// Importing extra libraries.

using System.Xml;

// Namespace stores all files in one solution which can be refered elsewhere in the project. 

namespace Assignment_A2_Notepad
{
    // Primary class.

    internal class Program
    {
        // Retrieves documents folder in Windows, and looks for a folder called "Notes"; if it does not exist, the program will create the folder.

        static string noteDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Notes\";

        // Primary method called when program opens.

        static void Main(string[] args)

        {

            // Displays file directory name.

            Console.Write(Directory.GetDirectoryRoot(noteDir));

            // Storing user input as a string, for a variable called "command". 

            string command = Console.ReadLine();

            // Switch checks entered command and read as lowercase. Then checks against list.

            switch (command.ToLower())
            {
                // Create a new note

                case "new":

                    @new();

                    Main(null);
                    break;

                case "-n":

                    @new();

                    Main(null);
                    break;

                // Edit an existing note.

                case "edit":

                    edit();

                    Main(null);
                    break;

                case "-e":

                    edit();

                    Main(null);
                    break;

                // Read an existing file contents.

                case "read":

                    read();

                    Main(null);
                    break;

                case "-r":

                    read();

                    Main(null);
                    break;

                // Delete an existing note.

                case "delete":

                    delete();

                    Main(null);
                    break;

                case "-d":

                    delete();

                    Main(null);
                    break;

                // Show all notes in terminal.

                case "show all notes":

                    showAllNotes();

                    Main(null);
                    break;

                case "-a":

                    showAllNotes();

                    Main(null);
                    break;

                // Print working directory.

                case "directory":

                    directory();

                    Main(null);
                    break;

                case "-dir":

                    directory();

                    Main(null);
                    break;

                // Clear terminal screen.

                case "clear screen":

                    clearScreen();

                    Main(null);
                    break;

                case "-c":

                    clearScreen();

                    Main(null);
                    break;

                // Terminate the program.

                case "exit":

                    exit();

                    Main(null);
                    break;

                case "-x":

                    exit();

                    Main(null);
                    break;

                default:

                    help();

                    // Executes Main method.

                    Main(null);

                    // Ends case being checked.

                    break;
            }
        }

        private static void help()
        {
            // Prints description of each command and ASCII text displaying "Notepad.v2"

            Console.SetCursorPosition(Console.CursorLeft + 0, Console.CursorTop + 1);
            Console.WriteLine(" /$$   /$$             /$$                                         /$$                   /$$$$$$ " + "\n" + "| $$$ | $$            | $$                                        | $$                  /$$__  $$" + "\n" + "| $$$$| $$  /$$$$$$  /$$$$$$    /$$$$$$   /$$$$$$   /$$$$$$   /$$$$$$$       /$$    /$$|__/  \\ $$" + "\n" + "| $$ $$ $$ /$$__  $$|_  $$_/   /$$__  $$ /$$__  $$ |____  $$ /$$__  $$      |  $$  /$$/  /$$$$$$/" + "\n" + "| $$  $$$$| $$  \\ $$  | $$    | $$$$$$$$| $$  \\ $$  /$$$$$$$| $$  | $$       \\  $$/$$/  /$$____/ " + "\n" + "| $$\\  $$$| $$  | $$  | $$ /$$| $$_____/| $$  | $$ /$$__  $$| $$  | $$        \\  $$$/  | $$      " + "\n" + "| $$ \\  $$|  $$$$$$/  |  $$$$/|  $$$$$$$| $$$$$$$/|  $$$$$$$|  $$$$$$$         \\  $//$$| $$$$$$$$" + "\n" + "|__/  \\__/ \\______/    \\___/   \\_______/| $$____/  \\_______/ \\_______/          \\_/|__/|________/" + "\n" + "                                        | $$                                                     " + "\n" + "                                        | $$                                                     " + "\n" + "                                        |__/                                                     " + "\n");

            Console.WriteLine("New (-n) // Create a new note");
            Console.WriteLine("Edit (-e) // Edit an existing note");
            Console.WriteLine("Read (-r) // Open a note in read only");
            Console.WriteLine("Delete (-d) // Delete an existing note");
            Console.WriteLine("Show All Notes (-a) // Print file names of existing notes");
            Console.WriteLine("Directory (-dir) // Print location of saved notes");
            Console.WriteLine("Clear Screen (-c) // Clear terminal screen");
            Console.WriteLine("Exit  // (-x) Terminate Notepad application");

            // If user enters "help" or enters anything else, the program will run the default option in the switch.

            Console.WriteLine("Help // Print these commands");
            Console.SetCursorPosition(Console.CursorLeft + 0, Console.CursorTop + 1);
            Console.WriteLine("Please run the [Directory] command for first time use.");
            Console.SetCursorPosition(Console.CursorLeft + 0, Console.CursorTop + 1);
        }

        private static void showAllNotes()
        {
            // Setting location equal to directory name.

            string noteLocation = noteDir;
            DirectoryInfo dir = new DirectoryInfo(noteLocation);

            // Checks to see if directory exists.

            if (Directory.Exists(noteLocation))
            {
                // Creating an array to hold existing file names in current directory.

                FileInfo[] files = dir.GetFiles("*.xml");

                // Counts the number of files in folder.

                if (files.Count() != 0)
                {
                    Console.SetCursorPosition(Console.CursorLeft + 0, Console.CursorTop + 2);
                    Console.WriteLine("  ___                            ___  " + "\n" + " (o o)                          (o o) " + "\n" + "(  V  ) Contents of Directory: (  V  )" + "\n" + "--m-m----------------------------m-m--" + "\n");

                    // Prints names of files in folder.

                    foreach (var item in files)
                    {
                        Console.WriteLine(" " + item.Name);
                    }
                    Console.WriteLine(Environment.NewLine);
                }
                else
                {
                    Console.WriteLine("There are no files to be displayed");
                }
            }
            else
            {
                Console.WriteLine("Directory does not exist ~~ directory location created");

                // If directory doesnt exist, it creates a new directory.

                Directory.CreateDirectory(noteDir);
                Console.WriteLine("Directory: " + noteDir + " has been created");
            }
        }

        private static void exit()
        {
            // Exit the program

            Environment.Exit(0);
        }

        private static void clearScreen()
        {
            // Clear console screen

            Console.Clear();
        }

        private static void directory()
        {
            // Open working directory in File Explorer. Create new one if it doesn't exist

            if (Directory.Exists(noteDir)) 
            {
                Process.Start("explorer.exe", noteDir);
            }
            else
            {
                Console.WriteLine("\n" + "Directory does not exist ~~ directory created");
                Directory.CreateDirectory(noteDir);
                Console.WriteLine("Directory: " + noteDir + " has been created" + "\n");
            }
        }

        private static void delete()
        {
            // Asks user to enter file name to delete.

            Console.WriteLine("Please enter file name:");
            string deleteFileName = Console.ReadLine() + ".xml";

            // Confirmation of deletion.

            if (File.Exists(noteDir + deleteFileName))
            {
                // Prompts user confirmation message

                Console.WriteLine(Environment.NewLine + "Are you sure you would like to delete:" + "\n" + "\n" + deleteFileName + "\n" + "\n" + "YES / NO in BLOCK CAPITALS");
                string confrimation = Console.ReadLine();

                // If the user would like to delete the file, they must enter YES.

                if (confrimation == "YES")
                {
                    try
                    {
                        File.Delete(noteDir + deleteFileName);
                        Console.WriteLine("File has been successfully deleted");
                    }
                    catch (Exception ex)
                    {
                        // If the file is unable to be deleted, it will display a message.

                        Console.WriteLine("File has not been deleted ERROR: " + ex);
                    }
                }

                // If the user would like to cancel the deletion, it will just repeat .

                else if (confrimation == "NO")
                {
                    Console.WriteLine("File has note been deleted.");
                    Main(null);
                }

                // If anything else is entered, an error message will be displayed.

                else
                {
                    Console.WriteLine("ERROR: Command is unrecognised");
                }
            }
            else
            {
                Console.WriteLine("ERROR: File does not exist");
            }
        }

        private static void read()
        {
            // Asks user to enter file name of existing note.

            Console.WriteLine("Please enter file name:");
            Console.SetCursorPosition(Console.CursorLeft + 0, Console.CursorTop + 1);
            string readFileName = Console.ReadLine();

            // Checks to see if file exists.

            if (File.Exists(noteDir + readFileName))
            {
                XmlDocument readDoc = new XmlDocument();
                readDoc.Load(noteDir + readFileName);

                Console.WriteLine(readDoc.SelectSingleNode("//Body").InnerText);
                Console.WriteLine("\n");

            }
            else
            {
                Console.WriteLine("ERROR: File could not be found");
            }
        }

        private static void edit()
        {
            // Program asks user for existing file name.

            Console.WriteLine("Please enter file name:");
            string openFileName = Console.ReadLine() + ".xml";

            // Checks to see if the file exists.

            if (File.Exists(noteDir + openFileName))
            {
                // Import Xml functions.

                XmlDocument doc = new XmlDocument();

                // Checks if program can load the note.

                try
                {
                    doc.Load(noteDir + openFileName);

                    // Setting the docuument to write text in the body of a Xml file.
                    Console.SetCursorPosition(Console.CursorLeft + 0, Console.CursorTop + 1);
                    Console.Write(doc.SelectSingleNode("//Body").InnerText);

                    Console.WriteLine("\n" + "\n");
                    Console.WriteLine("Please enter the new text here:");
                    Console.WriteLine("To abort, type CANCEL.");
                    Console.SetCursorPosition(Console.CursorLeft + 0, Console.CursorTop + 1);

                    // Reading users' text for edited note

                    string readInput = Console.ReadLine();

                    if (readInput.ToUpper() == "CANCEL")
                    {
                        Main(null);
                    }
                    else
                    {
                        string newText = doc.SelectSingleNode("//Body").InnerText = readInput;
                        doc.Save(noteDir + openFileName);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Note could not be saved due to unexpected error: " + ex.Message);

                }
            }
            else
            {
                Console.WriteLine("ERROR: File could not be found");
            }
        }

        private static void @new()
        {
            // Program asks the user to enter text, and user input is stored as a string.

            Console.WriteLine("Please enter the body of the note." + "\n" + "To save this document, press the ENTER key." + "\n");
            string userInput = Console.ReadLine();

            //  Creating settings for Xml file.

            XmlWriterSettings settings = new XmlWriterSettings();

            // Xml files settings, which allows the Xml file to be read and written correctly.

            settings.CheckCharacters = false;
            settings.ConformanceLevel = ConformanceLevel.Auto;
            settings.Indent = true;

            // Creates file name using system date.

            string fileName = DateTime.Now.ToString("dd-MM-yy'_'HH-mm") + ".xml";

            // Assigning note to save in specified directory, with file name.

            using (XmlWriter newNote = XmlWriter.Create(noteDir + fileName, settings))
            {
                newNote.WriteStartDocument();
                newNote.WriteStartElement("Note");
                newNote.WriteElementString("Body", userInput);
                newNote.WriteEndElement();

                newNote.Flush();
                newNote.Close();
            }
        }
    }
}
