using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Naheed_Scrapper_2
{
    public class CloudinaryUploader
    {
        private static readonly Cloudinary _cloudinary;

        static CloudinaryUploader()
        {
            // Configure Cloudinary credentials
            var account = new Account(
                "dxraueg3l",    // Replace with your Cloudinary cloud name
                "744562373298889",       // Replace with your Cloudinary API key
                "kc6N0Mg9_djpE4utwsEyd2CJRkM"     // Replace with your Cloudinary API secret
            );
            _cloudinary = new Cloudinary(account);
        }

        public static async Task<string> UploadImageToCloudinary(string imagePath, string folderName, string publicId)
        {
            retryUpload:
            try
            {
                if (!File.Exists(imagePath))
                {
                    Console.WriteLine($"File not found: {imagePath}");
                    return "FNF";
                }

                // Create the upload parameters
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(imagePath),
                    Folder = folderName,
                    PublicId = publicId,
                    Overwrite = true
                };

                
                // Perform the upload
                var uploadResult = await Task.Run(() => _cloudinary.Upload(uploadParams));

                if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine($"Successfully uploaded: {uploadResult.Url}");
                    return uploadResult.Url+""; // Return the URL of the uploaded image
                }
                else
                {//0_Emborg French Fries Straight 1000Gm
                    Console.WriteLine($"Upload failed: {uploadResult.Error.Message}");
                    goto retryUpload;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading image: {ex.Message}");
                goto retryUpload;
            }
        }

        // Example Usage
        public static async Task Main(string[] args)
        {
            string imagePath = @"C:\path\to\your\image.jpg"; // Replace with the path to your image
            string folderName = "products"; // Optional: specify a folder in Cloudinary
            string publicId = Path.GetFileNameWithoutExtension(imagePath); // Use image name without extension

            await UploadImageToCloudinary(imagePath, folderName, publicId);
        }
    }
}
