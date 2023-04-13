global using System.Reflection;

global using AdoPet.Libraries.SeedWork;
global using AdoPet.Services.PetAdoption.Api.Behaviors;
global using AdoPet.Services.PetAdoption.Application.Behaviors;
global using AdoPet.Services.PetAdoption.Application.Commands;
global using AdoPet.Services.PetAdoption.Application.Dtos;
global using AdoPet.Services.PetAdoption.Application.Errors;
global using AdoPet.Services.PetAdoption.Application.Queries;
global using AdoPet.Services.PetAdoption.Domain.AggregateModels.AdopterAggregates;
global using AdoPet.Services.PetAdoption.Infrastructure.Data;
global using AdoPet.Services.PetAdoption.Infrastructure.Data.Repositories;

global using FluentResults;

global using FluentValidation;

global using MediatR;

global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.Infrastructure;
global using Microsoft.EntityFrameworkCore;