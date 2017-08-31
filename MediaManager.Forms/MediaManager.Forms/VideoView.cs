using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.Implementations;
using Xamarin.Forms;

namespace Plugin.MediaManager.Forms
{
    public class VideoView : View
    {
        /// <summary>
        ///     Sets the aspect mode of the current video view
        /// </summary>
        public static readonly BindableProperty AspectModeProperty =
            BindableProperty.Create(nameof(VideoView),
                typeof(VideoAspectMode),
                typeof(VideoView),
                VideoAspectMode.AspectFill,
                propertyChanged: OnAspectModeChanged);

        /// <summary>
        ///     Sets the source url for the video to be played
        /// </summary>
        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create(nameof(VideoView),
                typeof(string),
                typeof(VideoView),
                "",
                propertyChanged: OnSourceChanged);

        /// <summary>
        ///     Sets the aspect mode of the current video view
        /// </summary>
        public static readonly BindableProperty ClosedCaptionProperty =
            BindableProperty.Create(nameof(VideoView),
                typeof(string),
                typeof(VideoView),
                "",
                propertyChanged: OnClosedCaptionChanged);

        public VideoAspectMode AspectMode
        {
            get { return (VideoAspectMode)GetValue(AspectModeProperty); }
            set { SetValue(AspectModeProperty, value); }
        }

        public string Source
        {
            get { return (string) GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public string ClosedCaption
        {
            get { return (string)GetValue(ClosedCaptionProperty); }
            set { SetValue(ClosedCaptionProperty, value); }
        }

        private static void OnAspectModeChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            CrossMediaManager.Current.VideoPlayer.AspectMode = ((VideoAspectMode) newvalue);
        }
        
        private static void OnSourceChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var video = new MediaFile
            {
                Url = (string)newvalue,
                Type = MediaFileType.Video
            };
            
            //Auto play by adding video to the queue and then play
            CrossMediaManager.Current.Play(video);
        }

        private static void OnClosedCaptionChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            CrossMediaManager.Current.VideoPlayer.ClosedCaption = (string)newvalue;
        }
    }
}