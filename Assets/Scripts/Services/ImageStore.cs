using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IImageStore
    {
        Task<byte[]> LoadImage(string imageId);
    }
    
    public class ImageStore : IImageStore
    {
        public Task<byte[]> LoadImage(string imageId)
        {
            return Task.Run(() => Encoding.UTF8.GetBytes(imageId));
        }
    }
}