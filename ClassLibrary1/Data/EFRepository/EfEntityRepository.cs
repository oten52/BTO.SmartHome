using BTO.SmartHomeData.Data.Context;
using BTO.SmartHomeModel.Dtos;
using BTO.SmartHomeModel.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace DonusumAykome.WebAPI.Data
{
    public class EfEntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, new()
    {
        public ResultItem<TEntity> Edit(TEntity ent)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();

            try
            {
                PropertyInfo Is_Tarih = ent.GetType().GetProperty("EditDate");
                if (Is_Tarih != null)
                    Is_Tarih.SetValue(ent, DateTime.Now);

                PropertyInfo IsDelete = ent.GetType().GetProperty("IsDelete");
                if (IsDelete != null)
                    IsDelete.SetValue(ent, true);


                using (var cnt = new BTOSmartHomeContext())
                {
                    EntityEntry<TEntity> addEntity = cnt.Entry(ent);

                    IEnumerable<PropertyEntry> lst = cnt.Entry(ent).Properties;

                    string pKey = PrimaryKey_Name(addEntity);

                    foreach (var i in lst)
                    {
                        if (i.CurrentValue != null && i.Metadata.Name != pKey)
                        {
                            i.IsModified = true;
                        }
                    }

                    cnt.SaveChanges();

                    m.Object = addEntity.Entity;
                    cnt.Database.CloseConnection();
                }

                m.Status = enState.Success;
                m.Message = "Updated";
            }
            catch (Exception ex)
            {
                m.Status = enState.Success;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
            }


            return m;
        }
        public ResultItem<TEntity> Add(TEntity ent)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();



            try
            {
                PropertyInfo Is_Tarih = ent.GetType().GetProperty("CreateDate");
                if (Is_Tarih != null)
                    Is_Tarih.SetValue(ent, DateTime.Now);


                PropertyInfo IsDelete = ent.GetType().GetProperty("IsDelete");
                if (IsDelete != null)
                    IsDelete.SetValue(ent, true);

                using (var cnt = new BTOSmartHomeContext())
                {
                    var addEntity = cnt.Entry(ent);
                    addEntity.State = EntityState.Added;
                    cnt.SaveChanges();

                    m.Object = addEntity.Entity;
                }

                m.Status = enState.Success;
                m.Message = "Saved";
            }
            catch (Exception ex)
            {
                m.Status = enState.Faild;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
            }


            return m;
        }
        public async Task<ResultItem<TEntity>> AsyncAdd(TEntity ent, bool IsException = false)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();



            try
            {
                PropertyInfo Is_Tarih = ent.GetType().GetProperty("CreateDate");
                if (Is_Tarih != null)
                    Is_Tarih.SetValue(ent, DateTime.Now);


                PropertyInfo IsDelete = ent.GetType().GetProperty("IsDelete");
                if (IsDelete != null)
                    IsDelete.SetValue(ent, true);

                using (var cnt = new BTOSmartHomeContext())
                {
                    var addEntity = await cnt.AddAsync(ent);
                    await cnt.SaveChangesAsync();
                    m.Object = addEntity.Entity;
                }

                m.Status = enState.Success;
                m.Message = "Saved";
            }
            catch (Exception ex)
            {
                m.Status = enState.Faild;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
            }


            return m;
        }
        public ResultItem<TEntity> AddFilter(TEntity ent, Expression<Func<TEntity, bool>> filtre = null)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();

            try
            {

                if (filtre != null)
                {
                    using (var cnt = new BTOSmartHomeContext())
                    {
                        var ns = cnt.Set<TEntity>();

                        m.Object = ns.SingleOrDefault(filtre);

                    }
                }

                if (m.Object == null)
                {
                    PropertyInfo Is_Tarih = ent.GetType().GetProperty("CreateDate");
                    if (Is_Tarih != null)
                        Is_Tarih.SetValue(ent, DateTime.Now);

                    PropertyInfo IsDelete = ent.GetType().GetProperty("IsDelete");
                    if (IsDelete != null)
                        IsDelete.SetValue(ent, true);

                    using (var cnt = new BTOSmartHomeContext())
                    {
                        var addEntity = cnt.Entry(ent);
                        addEntity.State = EntityState.Added;
                        cnt.SaveChanges();

                        m.Object = addEntity.Entity;
                        cnt.Database.CloseConnection();

                    }

                    m.Status = enState.Success;
                    m.Message = "Saved";
                }
                else
                {
                    m.Status = enState.Faild;
                    m.Message = "The record is repeated!";
                }


            }
            catch (Exception ex)
            {
                m.Status = enState.Faild;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
            }

            return m;
        }
        public ResultItem<TEntity> Get(Expression<Func<TEntity, bool>> filtre = null)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();


            try
            {
                using (var cnt = new BTOSmartHomeContext())
                {
                    var ns = cnt.Set<TEntity>();

                    m.Object = ns.FirstOrDefault(filtre);
                    cnt.Database.CloseConnection();

                }

                m.Status = m.Object != null ? enState.Success : enState.NotFound;

                m.Message = "Show record";

            }
            catch (Exception ex)
            {
                m.Status = enState.Faild;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;

            }

            return m;
        }
        public async Task<ResultItem<TEntity>> AsyncGet(Expression<Func<TEntity, bool>> filtre = null)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();


            try
            {
                using (var cnt = new BTOSmartHomeContext())
                {
                    var ns = cnt.Set<TEntity>();

                    m.Object = await ns.FirstOrDefaultAsync(filtre);
                    cnt.Database.CloseConnection();

                }

                m.Status = m.Object != null? enState.Success: enState.NotFound;

                m.Message = "Show record";

            }
            catch (Exception ex)
            {
                m.Status = enState.Faild;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;

            }

            return m;
        }
        public ResultItem<TEntity> UpdateRange(List<TEntity> ent)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();

            try
            {
                foreach (var item in ent)
                {

                    PropertyInfo Is_Tarih = item.GetType().GetProperty("EditDate");
                    if (Is_Tarih != null)
                        Is_Tarih.SetValue(item, DateTime.Now);



                }

                using (var cnt = new BTOSmartHomeContext())
                {
                    cnt.UpdateRange(ent);
                    cnt.SaveChanges();
                    cnt.Database.CloseConnection();

                }

                m.Status = m.List != null ? enState.Success : enState.NotFound;
                m.Message = "Updated Records";
            }
            catch (Exception ex)
            {
                m.Status = enState.Faild;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            return m;
        }
        public ResultItem<TEntity> AddRange(List<TEntity> ent)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();

            try
            {
                foreach (var item in ent)
                {

                    PropertyInfo Is_Tarih = item.GetType().GetProperty("CreateDate");
                    if (Is_Tarih != null)
                        Is_Tarih.SetValue(item, DateTime.Now);


                    PropertyInfo IsDelete = item.GetType().GetProperty("IsDelete");
                    if (IsDelete != null)
                        IsDelete.SetValue(item, true);

                }

                using (var cnt = new BTOSmartHomeContext())
                {
                    cnt.AddRange(ent);
                    cnt.SaveChanges();
                    cnt.Database.CloseConnection();

                }

                m.Status = m.List != null ? enState.Success : enState.NotFound;

                m.Message = "Saved records";
            }
            catch (Exception ex)
            {
                m.Status = enState.Faild;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
            }

            return m;
        }
        public ResultItem<TEntity> GetRelational(Expression<Func<TEntity, bool>> filtre = null)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();

            try
            {
                using (var cnt = new BTOSmartHomeContext())
                {
                    IQueryable<TEntity> ns = cnt.Set<TEntity>();

                    Type tip = typeof(TEntity);

                    PropertyInfo[] pi = tip.GetProperties();

                    foreach (var i in pi)
                    {
                        ForeignKeyAttribute fka = i.GetCustomAttribute<ForeignKeyAttribute>();

                        if (fka != null)
                        {
                            ns = ns.Include(fka.Name);
                        }

                    }

                    m.Object = ns.SingleOrDefault(filtre);


                    cnt.Database.CloseConnection();

                }

                m.Status = m.List != null &&m.List.Count>0? enState.Success : enState.NotFound;

                m.Message = "Show records";

            }
            catch (Exception ex)
            {
                m.Status = enState.Faild;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
            }


            return m;
        }

        public ResultItem<TEntity> Delete(Expression<Func<TEntity, bool>> filtre = null, bool isSingle = true)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();

            try
            {

                using (var cnt = new BTOSmartHomeContext())
                {
                    if (isSingle)
                    {

                        var ent = Get(filtre);
                        if (ent.Status == enState.Success)
                        {
                            PropertyInfo IsDelete = ent.GetType().GetProperty("IsDelete");

                            if (IsDelete != null)
                                IsDelete.SetValue(ent, false);

                            var addEntity = cnt.Entry(ent);
                            addEntity.State = EntityState.Modified;
                            cnt.SaveChanges();

                            cnt.Database.CloseConnection();

                            m.Status = enState.Success;
                            m.Message = "Removed Record";
                        }
                        else
                        {
                            m.Status = enState.Faild;
                            m.Message = "Not Found Record";
                        }
                    }
                    else
                    {
                        var ent = GetList(filtre);

                        if (ent.Status == enState.Success)
                        {
                            foreach (var item in ent.List)
                            {


                                PropertyInfo IsDelete = item.GetType().GetProperty("IsDelete");

                                if (IsDelete != null)
                                    IsDelete.SetValue(item, false);

                            }
                            cnt.UpdateRange(ent.List);
                            cnt.SaveChanges();
                            cnt.Database.CloseConnection();

                            m.Status = enState.Success;
                            m.Message = "Removed Records";
                        }
                        else
                        {
                            m.Status = enState.Faild;
                            m.Message = "Not Found Records";
                        }

                    }

                }


            }
            catch (Exception ex)
            {
                m.Status = enState.Faild;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
            }

            return m;
        }
       
        public ResultItem<TEntity> GetList(Expression<Func<TEntity, bool>> filtre = null)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();
            try
            {
                using (var cnt = new BTOSmartHomeContext())
                {
                    var ns = cnt.Set<TEntity>();

                    if (filtre == null)
                        m.List = ns.ToList();
                    else
                        m.List = ns.Where(filtre).ToList();

                    cnt.Database.CloseConnection();

                }

                m.Status = m.List != null && m.List.Count > 0 ? enState.Success : enState.NotFound;

                m.Message = "Return Records";
            }
            catch (Exception ex)
            {
                m.Status = enState.Faild;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
            }

            return m;
        }
        public async Task<ResultItem<TEntity>> AsyncGetList(Expression<Func<TEntity, bool>> filtre = null)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();
            try
            {
                using (var cnt = new BTOSmartHomeContext())
                {
                    var ns = cnt.Set<TEntity>();

                    if (filtre == null)
                        m.List = await ns.ToListAsync();
                    else
                        m.List = await ns.Where(filtre).ToListAsync();

                    await cnt.Database.CloseConnectionAsync();

                }

                m.Status = m.List != null && m.List.Count > 0 ? enState.Success : enState.NotFound;
                m.Message = "Return Records";
            }
            catch (Exception ex)
            {
                m.Status = enState.Faild;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
            }

            return m;
        }




        public int Get_KayitID_FromCnt(BTOSmartHomeContext _cnt, TEntity ent)
        {
            int ID = 0;
            string msj = "";

            try
            {
                EntityEntry<TEntity> _entry = _cnt.Entry(ent);
                var idName = _entry.Metadata.FindPrimaryKey().Properties.Select(x => x.Name).Single();
                ID = (int)ent.GetType().GetProperty(idName).GetValue(ent);
            }
            catch (Exception ex)
            {
                msj = ex.Message;
            }

            return ID;
        }
        public string PrimaryKey_Name(EntityEntry<TEntity> _entry)
        {
            var idName = _entry.Metadata.FindPrimaryKey().Properties.Select(x => x.Name).Single();
            return idName;
        }

    }
}
