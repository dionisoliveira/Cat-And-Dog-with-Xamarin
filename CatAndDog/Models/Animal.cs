using Xamarin.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

public class Animal :INotifyPropertyChanged
{

    #region private
    private string url;
    private ImageSource image;
    public string Id { get; set; }
    #endregion


    #region Properties
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


    public ImageSource Image
    {
        get
        {
            return image;
        }
        set
        {
            SetProperty(ref image, value); 
        }
    }
    #endregion

    #region Method


    /// <summary>
    /// Get image animal async
    /// </summary>
    /// <returns>The image.</returns>
    /// <param name="uri">URI.</param>
    private async Task LoadImage(string uri)
    {
        try
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync(uri);
            if (result.IsSuccessStatusCode)
            {
                var imagem = await result.Content.ReadAsByteArrayAsync();
                Device.BeginInvokeOnMainThread(() =>
                {
                    Image = ImageSource.FromStream(() => new MemoryStream(imagem));
                });
            }
            else
            {
                Image =await Task.FromResult<ImageSource>(null);
            }
        }
        catch(Exception e)
        {
            Image = await Task.FromResult<ImageSource>(null);
        }
    }

    #endregion

    #region INotifyPropertyChanged

    protected bool SetProperty<T>(ref T backingStore, T value,
        [CallerMemberName]string propertyName = "",
        Action onChanged = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;

        backingStore = value;
        onChanged?.Invoke();
        OnPropertyChanged(propertyName);
        return true;
    }


    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        var changed = PropertyChanged;
        if (changed == null)
            return;

        changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion


}
