using Azure.Storage.Blobs;
using System;
using System.IO;
using WebApplication.Models;

namespace WebApplication.Blob
{
    public class BlobHandler : IBlobHandler
    {
        private BlobServiceClient _blobServiceClient;

        public BlobHandler(string connectionString)
        {
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public async void SaveToContainer(NoticiaModel model, string nomeArquivo)
        {
            string blobContainerName = "img-noticias";

            BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);

            using (var ms = new MemoryStream())
            {
                model.ArquivoImagem.CopyTo(ms);

                ms.Position = 0;

                await blobContainerClient.UploadBlobAsync(nomeArquivo, ms);
            }

            string imgUri = $"{blobContainerClient.Uri.AbsoluteUri}/{nomeArquivo}";
        }
    }
}
