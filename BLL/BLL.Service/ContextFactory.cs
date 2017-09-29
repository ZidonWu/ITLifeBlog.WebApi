using DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ContextFactory
    {
        /// <summary>
        /// 获取当前线程的数据上下文
        /// </summary>
        /// <returns>数据上下文</returns>
        public static ITLifeBlogDbContext CurrentContext()
        {
            ITLifeBlogDbContext dbContext = CallContext.GetData("ITLifeBlogDbContext") as ITLifeBlogDbContext;
            if (dbContext == null)
            {
                dbContext = new ITLifeBlogDbContext();
                CallContext.SetData("ITLifeBlogDbContext", dbContext);
            }
            return dbContext;

        }
    }
}
