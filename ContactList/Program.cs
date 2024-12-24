using Business.Interfaces;
using Business.Repositories;
using Business.Services;
using ConsoleApp_Main.Dialogs;
using Microsoft.Extensions.DependencyInjection;

var serviceProider = new ServiceCollection()
    .AddSingleton<IFileService>(new FileService("Data", "contacts.json"))
    .AddSingleton<IContactRepository, ContactRepository>()
    .AddSingleton<IContactService, ContactService>()
    .AddTransient<MenuDialog>()
    .BuildServiceProvider();

var menuDialog = serviceProider.GetRequiredService<MenuDialog>();
menuDialog.MainMenu();