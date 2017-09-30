using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Service.ArticleSer;

namespace BLL.Test
{
    [TestClass]
    public class UnitTest1
    {
        public IArticleService _articleSeervice;

        public UnitTest1()
        {
            _articleSeervice = new ArticleService();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var result = _articleSeervice.UpdateByDelete(2, x => x.IsDeleted);
            Console.WriteLine(result);
        }
    }
}
