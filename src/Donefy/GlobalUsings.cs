#region System
global using System.Text.Json.Serialization;
#endregion

#region Microsoft
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Design;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
#endregion

#region External Packages
global using FluentValidation;
#endregion

#region Donefy
global using Donefy.Src.Core.Domain.Shared.Results.Messages;
global using Donefy.Src.Core.Domain.Shared.Results.Status;
global using Donefy.Src.Core.Domain.Shared.Results.Operations;
global using Donefy.Src.Core.Domain.Shared.Paginations;
global using Donefy.Src.Core.Domain.Shared.Exceptions;
global using Donefy.Src.Core.Domain.Entities.Base;
global using Donefy.Src.Core.Domain.Entities;
global using Donefy.Src.Core.Domain.ValueObjects;
global using Donefy.Src.Core.Domain.Interfaces;
global using Donefy.Src.Core.Infrastructure.Data.Context;
global using Donefy.Src.Core.Infrastructure.Data.Repositories;
global using Donefy.Src.Core.Infrastructure.Data.Connection;
global using Donefy.Src.Core.Infrastructure.Data.UoW;
global using Donefy.Src.Core.Infrastructure.Modules;
global using Donefy.Src.Core.Application.Interfaces.Facades;
global using Donefy.Src.Core.Application.Facades;
global using Donefy.Src.Core.Application.Interfaces.CQRS;
global using Donefy.Src.Core.Application.UseCases.Categories.Commands.Create;
global using Donefy.Src.Core.Application.UseCases.Categories.Commands.Delete;
global using Donefy.Src.Core.Application.UseCases.Categories.Commands.Update;
global using Donefy.Src.Core.Application.UseCases.Categories.Queries.GetAll;
global using Donefy.Src.Core.Application.UseCases.Categories.Queries.GetById;
#endregion