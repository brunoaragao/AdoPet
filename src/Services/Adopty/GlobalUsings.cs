global using System.Reflection;

global using Adopty.Application.Handlers;
global using Adopty.Application.Middlewares;
global using Adopty.Application.Requests;
global using Adopty.Application.Responses;
global using Adopty.Domain.AggregateModels.AdopterAggregates;
global using Adopty.Domain.AggregateModels.AdoptionAggregates;
global using Adopty.Domain.AggregateModels.PetAggregates;
global using Adopty.Domain.AggregateModels.ShelterAggregates;
global using Adopty.Domain.SeedWork;
global using Adopty.Infrastructure.Data;
global using Adopty.Infrastructure.Data.Repositories;

global using FluentValidation;

global using Identity.Contracts;

global using MassTransit;
global using MassTransit.Mediator;

global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;

global using Serilog;
global using Serilog.Events;
