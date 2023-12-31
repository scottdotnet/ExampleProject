﻿using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Caching.Memory;
using System.Data;
using System.Data.Common;

namespace ExampleProject.Server.Infrastructure.Persistance.Interceptors;

internal sealed class CacheDataInterceptor : DbCommandInterceptor
{
    private readonly IMemoryCache _cache;

    public CacheDataInterceptor(IMemoryCache cache)
        => _cache = cache;

    public override async ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result,
        CancellationToken cancellationToken = default)
    {
        if (_cache.TryGetValue(command.CommandText, out DataTable dataTable))
        {
            command.CommandText = "-- Cache";
            result = InterceptionResult<DbDataReader>.SuppressWithResult(dataTable.CreateDataReader());
        }

        return await new ValueTask<InterceptionResult<DbDataReader>>(result);
    }

    public override async ValueTask<DbDataReader> ReaderExecutedAsync(
            DbCommand command,
            CommandExecutedEventData eventData,
            DbDataReader result,
            CancellationToken cancellationToken = default)
    {
        var cache = _cache.GetOrCreate(command.CommandText, e =>
        {
            var dt = new DataTable { };

            try { dt.Load(result); }
            catch { }

            return dt;
        });

        return await new ValueTask<DbDataReader>(cache.CreateDataReader());
    }
}
