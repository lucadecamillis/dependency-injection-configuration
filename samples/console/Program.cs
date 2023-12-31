﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samples.Lib.Impl;
using Samples.Lib.Interfaces;
using LdC.DependencyInjection.Configuration;
using Samples.Lib.Factories;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
    .Build();

IServiceCollection services = new ServiceCollection();

services.AddTransient<IComplexService>(ComplexServiceFactory.Create);

services.FromConfiguration(configuration);

IServiceProvider serviceProvider = services.BuildServiceProvider();

var service = serviceProvider.GetRequiredService<IService>();

Console.WriteLine("Service created");

var context = serviceProvider.GetRequiredService<Context>();

Console.WriteLine("Context created");

var generics = serviceProvider.GetRequiredService<IGenericService<string>>();

Console.WriteLine("Generics created");

var complex = serviceProvider.GetRequiredService<IComplexService>();

Console.WriteLine("Complex created");