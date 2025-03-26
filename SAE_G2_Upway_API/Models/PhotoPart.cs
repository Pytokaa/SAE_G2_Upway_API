namespace SAE_G2_Upway_API.Models.EntityFramework
{
    public partial class Photo
    {
        public Photo(int id, string url, string description)
        {
            IdPhoto = id;
            Url = url;
            Description = description;
        }
        public Photo(int id) 
        {
            IdPhoto = id;
            Url = "https://live.staticflickr.com/4033/4627009247_c259e8d75f.jpg";
            Description = "Orangutan riding a bike";
        }
    }
}
