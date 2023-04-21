// Dotnet namespaces
global using System;

// Models
global using DartCounter.Models;

// MonogDB
global using MongoDB.Bson;
global using MongoDB.Bson.Serialization.Attributes;
global using MongoDB.Driver;

// Microsoft
global using Microsoft.Extensions.Options;

// Configuration
global using DartCounter.Configuration;

// DataContext
global using DartCounter.DataContext;

// Repositories
global using DartCounter.Repositories;

// Services
global using DartCounter.Services;

// Validators
global using DartCounter.Validators;
global using FluentValidation;

// Keyvault
global using Azure.Identity;
global using Azure.Security.KeyVault.Secrets;
global using Azure.Core;