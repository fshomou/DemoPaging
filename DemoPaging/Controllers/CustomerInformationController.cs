using DemoPaging.EFModel;
using DemoPaging.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace DemoPaging.Controllers
{
    [RoutePrefix("api/CustomerInformation")]
    public class CustomerInformationController : ApiController
    {
        /// <summary>
        /// Constructor for Creating instance of CustomerDBEntities 
        /// </summary>
        CustomerDBEntities _context;
        public CustomerInformationController()
        {
            _context = new EFModel.CustomerDBEntities();
            _context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }




        //https://www.c-sharpcorner.com/article/how-to-do-paging-with-asp-net-web-api/

        //[HttpGet]
        //public IHttpActionResult Customer([FromUri]PagingParameterModel pagingparametermodel)
        //{

        //    // Return List of Customer
        //    var source = (from customer in _context.CustomerTBs.
        //                    OrderBy(a => a.Country)
        //                  select customer).AsQueryable();


        //    // Get's No of Rows Count 
        //    int count = source.Count();

        //    // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1
        //    int CurrentPage = pagingparametermodel.pageNumber;

        //    // Parameter is passed from Query string if it is null then it default Value will be pageSize:20
        //    int PageSize = pagingparametermodel.pageSize;

        //    // Display TotalCount to Records to User
        //    int TotalCount = count;

        //    // Calculating Totalpage by Dividing (No of Records / Pagesize)
        //    int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

        //    // Returns List of Customer after applying Paging 
        //    var items = source.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

        //    // if CurrentPage is greater than 1 means it has previousPage
        //    var previousPage = CurrentPage > 1 ? "Yes" : "No";

        //    // if TotalPages is greater than CurrentPage means it has nextPage
        //    var nextPage = CurrentPage < TotalPages ? "Yes" : "No";

        //    // Object which we are going to send in header 
        //    var paginationMetadata = new
        //    {
        //        totalCount = TotalCount,
        //        pageSize = PageSize,
        //        currentPage = CurrentPage,
        //        totalPages = TotalPages,
        //        previousPage,
        //        nextPage
        //    };

        //    var cookie = new HttpCookie("session-id", "12345");
        //    cookie.Domain = Request.RequestUri.Host;
        //    cookie.Path = "/";
        //    // Setting Header
        //    HttpContext.Current.Response.Headers.Add("Paging-Headers", JsonConvert.SerializeObject(paginationMetadata));
        //    HttpContext.Current.Response.AppendCookie(cookie);
        //    // Returing List of Customers Collections
        //    return Ok(items);

        //}


        // https://www.dotnetcurry.com/ShowArticle.aspx?ID=394
        [HttpGet]
        public IHttpActionResult Customer2([FromUri]PagingParameterModel pagingparametermodel)
        {


            var source = (from customer in _context.CustomerTBs.OrderBy(a => a.Country) select customer)
                           .Skip((pagingparametermodel.pageNumber - 1) * pagingparametermodel.pageSize)
                           .Take(pagingparametermodel.pageSize)
                           .ToList();

            int count = (from customer in _context.CustomerTBs select customer).Count();


            // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1
            int CurrentPage = pagingparametermodel.pageNumber;

            // Parameter is passed from Query string if it is null then it default Value will be pageSize:20
            int PageSize = pagingparametermodel.pageSize;

            // Display TotalCount to Records to User
            int TotalCount = count;

            // Calculating Totalpage by Dividing (No of Records / Pagesize)
            int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            // Returns List of Customer after applying Paging 
            var items = source;

            // if CurrentPage is greater than 1 means it has previousPage
            var previousPage = CurrentPage > 1 ? "Yes" : "No";

            // if TotalPages is greater than CurrentPage means it has nextPage
            var nextPage = CurrentPage < TotalPages ? "Yes" : "No";

            // Object which we are going to send in header 
            var paginationMetadata = new
            {
                totalCount = TotalCount,
                pageSize = PageSize,
                currentPage = CurrentPage,
                totalPages = TotalPages,
                previousPage,
                nextPage
            };

            var cookie = new HttpCookie("session-id", "12345");
            cookie.Domain = Request.RequestUri.Host;
            cookie.Path = "/";
            // Setting Header
            HttpContext.Current.Response.Headers.Add("Paging-Headers", JsonConvert.SerializeObject(paginationMetadata));
            HttpContext.Current.Response.AppendCookie(cookie);
            // Returing List of Customers Collections
            return Ok(items);

        }
    }
}
