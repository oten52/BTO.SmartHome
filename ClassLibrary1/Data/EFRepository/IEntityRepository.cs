using BTO.SmartHomeModel.Dtos;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq.Expressions;

namespace DonusumAykome.WebAPI.Data
{
    public interface IEntityRepository<T> where T : class, new()
    {
        ResultItem<T> Get(Expression<Func<T, bool>> filtre = null);
        ResultItem<T> GetList(Expression<Func<T, bool>> filtre = null);
        ResultItem<T> Add(T ent);
        ResultItem<T> AddFilter(T ent, Expression<Func<T, bool>> filtre = null);
        ResultItem<T> Edit(T ent);
        ResultItem<T> Delete(Expression<Func<T, bool>> filtre = null, bool isSingle=true);
    }
}
