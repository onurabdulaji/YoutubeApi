using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApiSln.Application.Interfaces.Repositories;
using YoutubeApiSln.Application.Interfaces.UnitOfWorks;
using YoutubeApiSln.Persistence.Context;
using YoutubeApiSln.Persistence.Repositories;

namespace YoutubeApiSln.Persistence.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext dbContext;

    public UnitOfWork(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async ValueTask DisposeAsync() => await dbContext.DisposeAsync().ConfigureAwait(false); // Configure burada 

    public int Save() => dbContext.SaveChanges();

    public async Task<int> SaveAsync() => await dbContext.SaveChangesAsync();

    IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext);

    IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(dbContext);

}


/// <summary>
/// DisposeAsync İçin ConfigureAwait(false) Kullanımı
/// public async ValueTask DisposeAsync() => await dbContext.DisposeAsync().ConfigureAwait(false);
/// Save() Metodunu Kullanırken Dikkatli Ol
///Asenkron kod yazıyorsan, SaveAsync() kullanmalısın.
///Eğer Save() kullanıyorsan, bu DbContext'in thread-safe olmamasına neden olabilir.
///Eğer birden fazla thread'in çalıştığı bir senaryon varsa, sadece SaveAsync() kullanmayı düşünebilirsin.
/// <summary>
