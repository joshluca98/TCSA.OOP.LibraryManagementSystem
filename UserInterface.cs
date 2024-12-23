using Spectre.Console;
using STUDY.OOP.LibraryManagement.Controllers;
using TCSA.OOP.LibraryManagementSystem.Controllers;
using static TCSA.OOP.LibraryManagementSystem.Enums;

namespace TCSA.OOP.LibraryManagementSystem;

internal class UserInterface
{
    private readonly BookController bookController = new();
    private readonly MagazineController magazineController = new();
    private readonly NewspaperController newspaperController = new();

    internal void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            var actionChoice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuAction>()
                .Title("What do you want to do next?")
                .AddChoices(Enum.GetValues<MenuAction>()));
            
            var itemTypeChoice = AnsiConsole.Prompt(
                new SelectionPrompt<ItemType>()
                .Title("Select the type of item:")
                .AddChoices(Enum.GetValues<ItemType>()));

            switch (actionChoice)
            {
                case MenuAction.ViewItems:
                    ViewItems(itemTypeChoice);
                    break;
                case MenuAction.AddItem:
                    AddItem(itemTypeChoice);
                    break;
                case MenuAction.DeleteItem:
                    DeleteItem(itemTypeChoice);
                    break;
            }
        }
    }

    private void ViewItems(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Book:
                bookController.ViewItems();
                break;
            case ItemType.Magazine:
                magazineController.ViewItems();
                break;
            case ItemType.Newspaper:
                newspaperController.ViewItems();
                break;
        }
    }

    private void AddItem(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Book:
                bookController.AddItem();
                break;
            case ItemType.Magazine:
                magazineController.AddItem();
                break;
            case ItemType.Newspaper:
                newspaperController.AddItem();
                break;
        }
    }

    private void DeleteItem(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Book:
                bookController.DeleteItem();
                break;
            case ItemType.Magazine:
                magazineController.DeleteItem();
                break;
            case ItemType.Newspaper:
                newspaperController.DeleteItem();
                break;
        }
    }
}