// -- IMPORTS

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using FLOW;

// -- TYPES

using Element = UnityEngine.UIElements.VisualElement;

// ~~

namespace GAME
{
    [ RequireComponent( typeof( UIDocument ) ) ]
    public class HOME_INTERFACE : INTERFACE
    {
        // -- ATTRIBUTES

        public static HOME_INTERFACE
            Instance;
        public Element
            ScreenElement;
        public DRAG_VIEW
            DragView;
        public Element
            DragViewStripElement;
        public SLIDER
            Slider;

        // -- OPERATIONS

        public void Awake(
            )
        {
            Instance = this;
        }

        // ~~

        public void CreateVideo(
            Element parent_element,
            string video_file_path
            )
        {
            Button
                pause_video_button,
                play_video_button;
            VIDEO
                video;

            video = parent_element.Create<VIDEO>( "video" );
            video.SetParentGameObject( gameObject );
            video.SetVideo( video_file_path, true );

            pause_video_button = video.Create<Button>( "pause-video-button" );
            pause_video_button.clicked += () => video.Player.Pause();

            play_video_button = video.Create<Button>( "play-video-button" );
            play_video_button.clicked += () => video.Player.Play();
        }

        // ~~

        public void CreateDragView(
            Element parent_element
            )
        {
            DragView = ScreenElement.Create<DRAG_VIEW>( "drag-view" );
            DragView.IsHorizontal = true;

            DragViewStripElement = DragView.Create<Element>( "drag-view-strip" );

            CreateVideo( DragViewStripElement, Application.dataPath + "/Resources/Videos/Nature1.mp4" );
            CreateVideo( DragViewStripElement, Application.dataPath + "/Resources/Videos/Nature2.mp4" );
            CreateVideo( DragViewStripElement, Application.dataPath + "/Resources/Videos/Waterfall1.mp4" );
            CreateVideo( DragViewStripElement, Application.dataPath + "/Resources/Videos/Waterfall2.mp4" );
        }

        // ~~

        public void CreateSlider(
            Element parent_element
            )
        {
            Slider = parent_element.Create<SLIDER>( "slider" );
            Slider.SetMinimumValue( 0.0f );
            Slider.SetMaximumValue( 100.0f );
            Slider.SetValue( 0.0f );
            Slider.HandleValueChangedAction += value => Debug.Log( "Changed value : " + value );
            Slider.HandleValueMovedAction += value => Debug.Log( "Moved value : " + value );

            Slider.SetValue( 50.0f );
        }

        // ~~

        public override void BuildDocument(
            )
        {
            ScreenElement = Element.Create<Element>( "home-screen" );

            CreateDragView( Element );
            CreateSlider( Element );
        }

        // ~~

        public override void ResizeDocument(
            )
        {
            base.ResizeDocument();

            Element.SetHeight( "video", 200 * Pixel );
            Element.SetWidth( "video", Width / 4 );
        }
    }
}

