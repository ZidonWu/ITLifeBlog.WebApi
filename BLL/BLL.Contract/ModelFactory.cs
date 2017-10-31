using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contract
{
    public class ModelFactory
    {
        public ModelFactory()
        {

        }

        public AccountModel Create(Account account)
        {
            return new AccountModel()
            {
                Id = account.Id,
                Name = account.Name,
                RoleModel = new RoleModel()
                {
                    Id = account.RoleId,
                    Name = account.Role.Name
                }
            };
        }

        //public ArticleModel Create(Article article)
        //{
        //    return new ArticleModel()
        //    {
        //        Id = article.Id,
        //        Title = article.Title,
        //        Description = article.Description,
        //        Content = article.Content,
        //        CreateTime = article.CreateTime,
        //        CommentNum = article.CommentNum,
        //        IsDeleted = article.IsDeleted,
        //        IsPublish = article.IsPublish,
        //        LastUpdateTime = article.LastUpdateTime,
        //        ReadNum = article.ReadNum,
        //        Stars = article.Stars,
        //        AccountModel = new AccountModel()
        //        {
        //            Id = article.Account.Id,
        //            Name = article.Account.Name,
        //            RoleModel = new RoleModel()
        //            {
        //                Id = article.Account.Role.Id,
        //                Name = article.Account.Role.Name
        //            }
        //        }
        //    };
        //}
    }
}
