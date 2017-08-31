using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Xamarin.Forms;

namespace MediaForms
{
    public partial class MediaFormsPage : ContentPage
    {
        private IPlaybackController PlaybackController => CrossMediaManager.Current.PlaybackController;

        public MediaFormsPage()
        {
            InitializeComponent();

            CrossMediaManager.Current.PlayingChanged += (sender, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ProgressBar.Progress = e.Progress;
                    Duration.Text = "" + e.Duration.TotalSeconds + " seconds";
                });
            };            
        }

        protected override void OnAppearing()
        {
            videoView.Source = "http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4";

            //videoView.ClosedCaption = "https://aggmediedemo.blob.core.windows.net/asset-0b0d95c8-4be9-4224-b857-67459db2e130/testvideo7_aud_SpReco.vtt?sv=2015-07-08&sr=c&si=7edabd80-0952-460d-9569-97d41dbd7657&sig=9th9fdX%2F7lHfHpPHCNpPtq4BiLpqVbIYUP8h6xtjLU4%3D&se=2017-09-24T14%3A20%3A20Z";
            //videoView.Source = "https://aggmediedemo.blob.core.windows.net/asset-095945fb-2759-453e-9f4b-80c4c4013f6c/testvideo7_320x180_380.mp4?sv=2015-07-08&sr=c&si=701af2ff-b115-4046-b9de-79eecc6e7719&sig=8NJUUvPpSRjL%2BazFa7XYeW1imLGHe47tJg7QiyU9BEY%3D&se=2017-09-24T14%3A19%3A04Z";
        }

        void PlayClicked(object sender, System.EventArgs e)
        {            
            PlaybackController.Play();
        }

        void PauseClicked(object sender, System.EventArgs e)
        {
            PlaybackController.Pause();
        }

        void StopClicked(object sender, System.EventArgs e)
        {
            PlaybackController.Stop();
        }
    }
}
