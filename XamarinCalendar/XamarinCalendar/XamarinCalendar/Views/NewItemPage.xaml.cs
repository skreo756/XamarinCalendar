using Android;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinCalendar.Models;

namespace XamarinCalendar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
       
        public Event Item { get; set; }
      //  public DateTime DateDebut = { get => date; set => date = value; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Event
            {
                Text = " ",
                Description = " ",
                Debut = DateTime.Today,
                Fin = DateTime.Today,
                HeureDebut = new TimeSpan(),
                HeureFin = new TimeSpan()
            };

            BindingContext = this;
        }

      


        async void PressMeButton_Clicked(object sender, EventArgs e)
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);

            if (status != PermissionStatus.Granted)
            {
                Console.WriteLine("PAS DE PERMISSIONS");


                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
                {
                    await DisplayAlert("Camera Permission", "Allow SavR to access your camera", "OK");
                }
                

                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera);
                status = results[Permission.Camera];
            }

            if (status == PermissionStatus.Granted)
            {
                Console.WriteLine("PERMISSION ACCORDEE");
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
                {

                    await CrossMedia.Current.Initialize();

                    // Supply media options for saving our photo after it's taken.
                    var mediaOptions = new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        Directory = "Receipts",
                        Name = $"{DateTime.UtcNow}.jpg"
                        
                    };



                    // Take a photo of the business receipt.
                    var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        CompressionQuality = 92,
                        PhotoSize = PhotoSize.Custom,
                        CustomPhotoSize = 90
                    });

                    if (file == null)
                        return;

                    await DisplayAlert("File Location", file.Path, "OK");
                    this.Item.Image = file.Path;
                }
            }     
        }

        async void Save_Clicked(object sender, EventArgs e)
        {

            this.Item.Fin = this.Item.Fin.Add(this.Item.HeureFin);
            this.Item.Debut = this.Item.Debut.Add(this.Item.HeureDebut);
            this.Item.Image = this.Item.Image;

            Console.WriteLine(this.Item.Image);


            DataBase.InsertEvent(Item);

            //  MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }
    }
}