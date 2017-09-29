using BLL.Service.AccountSer;
using BLL.Service.AlbumSer;
using BLL.Service.ArticleCommentSer;
using BLL.Service.ArticleSer;
using BLL.Service.CategorySer;
using BLL.Service.MessageSer;
using BLL.Service.MoodCommentSer;
using BLL.Service.MoodSer;
using BLL.Service.RoleSer;
using BLL.Service.UserSer;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace UI.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<IArticleService, ArticleService>();
            container.RegisterType<IAlbumService, AlbumService>();
            container.RegisterType<IArticleCommentService, ArticleCommentService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IMessageService, MessageService>();
            container.RegisterType<IMoodService, MoodService>();
            container.RegisterType<IMoodCommentService, MoodCommentService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IUserService, UserService>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}