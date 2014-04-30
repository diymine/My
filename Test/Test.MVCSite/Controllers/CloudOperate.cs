using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using Test.MVCSite.Models;

namespace Test.MVCSite.Controllers
{
    public class CloudOperate
    {
        const string StorageConnctionString = "Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString";
        public CloudStorageAccount StorageAccount { get; set; }
        public CloudOperate()
        {
            StorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting(StorageConnctionString));
        }

        public CloudBlobClient BlobClient
        {
            get
            {
                CloudBlobClient blobClient = StorageAccount.CreateCloudBlobClient();
                return blobClient;
            }
        }

        public CloudQueueClient QueueClient
        {
            get
            {
                CloudQueueClient queueClient = StorageAccount.CreateCloudQueueClient();
                return queueClient;
            }
        }

        public CloudTableClient TableClient
        {
            get
            {
                CloudTableClient tableClient = StorageAccount.CreateCloudTableClient();
                return tableClient;
            }
        }

        public CloudBlobContainer GetBlobContainer(string container)
        {
            CloudBlobContainer blobContainer = BlobClient.GetContainerReference(container);
            blobContainer.CreateIfNotExists(new BlobRequestOptions() { }, new OperationContext() { });
            return blobContainer;
        }

        public void SaveBlob(string container,string blobName,Stream stream)
        {
            CloudBlobContainer blobContainer = GetBlobContainer(container);
            blobContainer.SetPermissions(
            new BlobContainerPermissions
            {
                PublicAccess =
                    BlobContainerPublicAccessType.Blob
            }); 
            CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(blobName);
            
            blockBlob.UploadFromStream(stream,null,null,new OperationContext(){});
        }

        public IEnumerable<T> ListBlob<T>(string container) where  T : IListBlobItem
        {
            CloudBlobContainer blobContainer = GetBlobContainer(container);
            var blobItem = blobContainer.ListBlobs().OfType<T>();
            return blobItem;
        }

        public MemoryStream DownloadBlob(string container,string blobName)
        {
            CloudBlobContainer blobContainer = GetBlobContainer(container);
            CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(blobName);
            var stream = new MemoryStream();
            blockBlob.DownloadToStream(stream);
            return stream;
        }

        public bool DeleteBlob(string container, string blobName)
        {
            CloudBlobContainer blobContainer = GetBlobContainer(container);
            CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(blobName);
            return blockBlob.DeleteIfExists();
        }

        public CloudTable GetCloudTable(string tableName)
        {
            CloudTable table = TableClient.GetTableReference(tableName);
            table.CreateIfNotExists();
            return table;
        }

        public TableResult SaveOrUpdateEntity<T>(T entity,string tableName = null) where T : TableEntity
        {
            CloudTable table = GetCloudTable(tableName);
            // Create the TableOperation that inserts the customer entity.
            TableOperation insertOperation = TableOperation.InsertOrReplace(entity);
            // Execute the insert operation.
            return table.Execute(insertOperation);
        }

        public IList<TableResult> BatchAddEntity<T>(IEnumerable<T> list, string tableName = null) where T : TableEntity
        {
            CloudTable table = GetCloudTable(tableName);
            // Create the TableOperation that inserts the customer entity.
            var batchOperation = new TableBatchOperation();
            foreach (var item in list)
            {
                batchOperation.Insert(item);
            }
            // Execute the insert operation.
            return table.ExecuteBatch(batchOperation);
        }

        //public IEnumerable<T> QueryEntity<T>(string tableName = null) where T : TableEntity
        //{
        //    CloudTable table = GetCloudTable(tableName);
        //    // Construct the query operation for all customer entities where PartitionKey="Smith".
        //    TableQuery<T> query = new TableQuery<T>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Smith"));
        //    return table.ExecuteQuery<T>(query);
        //}

        //public TableResult SaveEntity<T>(string tableName, IEnumerable<T> entities) where T : TableEntity
        //{
        //    CloudTable table = GetCloudTable(tableName);
        //    // Create the batch operation.
        //    var batchOperation = new TableBatchOperation();
        //   // batchOperation.i
        //    // Create the TableOperation that inserts the customer entity.
        //    TableOperation insertOperation = TableOperation.InsertOrReplace(entity);
        //    // Execute the insert operation.
        //    return table.Execute(insertOperation);
        //}

    }
}