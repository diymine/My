using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.WindowsAzure.Storage.Blob;
using Test.MVCSite.Models;
using Microsoft.WindowsAzure.Storage.Table;

namespace Test.MVCSite.Controllers
{
    public class TestAzureController : Controller
    {
        //
        // GET: /Test/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string SavePic()
        {
            var operate = new CloudOperate();
            Stream stream = System.IO.File.OpenRead(this.Server.MapPath(@"~/Content/bootstrap.css"));
            operate.SaveBlob("testcontainer", "bootstrapblob", stream);
            return "Success";
        }

        public ActionResult ListData()
        {
            var operate = new CloudOperate();
            var blobList = operate.ListBlob<CloudBlockBlob>("testcontainer");
            ViewBag.BlobList = blobList;
            return View();
        }

        public string ViewBlobContent()
        {
            var operate = new CloudOperate();
            MemoryStream stream = operate.DownloadBlob("testcontainer", "bootstrapblob");
            return System.Text.Encoding.Default.GetString(stream.GetBuffer());
        }

        public string DeleteBlob()
        {
            var operate = new CloudOperate();
            operate.DeleteBlob("testcontainer", "bootstrapblob");
            return "success";
        }

        public string InsertEntity()
        {
            var customer1 = new CustomerEntity() { ETag = "*", PartitionKey = "1", RowKey = "1", Email = "Walter@contoso.com", PhoneNumber = "425-555-0101" };
            var operate = new CloudOperate();
            TableResult result = operate.SaveOrUpdateEntity<CustomerEntity>( customer1,"CustomerEntity");
            return result.Result.ToString();
        }

        public ActionResult ListEntity()
        {
            var operate = new CloudOperate();
            operate.QueryEntity<CustomerEntity>()
        }
    }
}