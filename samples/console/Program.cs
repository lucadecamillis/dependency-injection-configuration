using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samples.Lib.Impl;
using Samples.Lib.Interfaces;
using LdC.DependencyInjection.Configuration;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
    .Build();

IServiceCollection services = new ServiceCollection();

services.FromConfiguration(configuration);

IServiceProvider serviceProvider = services.BuildServiceProvider();

var service = serviceProvider.GetRequiredService<IService>();

Console.WriteLine("Service created");

var context = serviceProvider.GetRequiredService<Context>();

Console.WriteLine("Context created");

var generics = serviceProvider.GetRequiredService<IGenericService<string>>();

Console.WriteLine("Generics created");