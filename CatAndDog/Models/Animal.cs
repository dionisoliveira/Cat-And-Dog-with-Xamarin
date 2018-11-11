using Xamarin.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.IO;

public class Animal
{

    #region private
    private string url;
    #endregion

    public string Id { get; set; }
    public string Url
    {
        get
        {
            return url;
        }
        set
        {
            url = value;
            Task.Run(async () =>
            {
                await LoadImage(url);
            });
        }
    }


    public ImageSource Image;


    private async Task LoadImage(string uri)
    {
        
            HttpClient client = new HttpClient();
            var result = await client.GetAsync(uri);
            if(result.IsSuccessStatusCode)
            {
                var imagem = await result.Content.ReadAsByteArrayAsync();
                Device.BeginInvokeOnMainThread(() =>
                {
                    Image = ImageSource.FromStream(() => new MemoryStream(imagem));
                });
            }
          
       
          
        
    }


}
