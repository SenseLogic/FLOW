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
            VideoListPanelElement;
        public Element
            VideoListStripElement,
            GridViewPanelElement;

        // -- OPERATIONS

        public void Awake(
            )
        {
            Instance = this;
        }

        // ~~

        public void CreateVideoView(
            string video_file_path
            )
        {
            Button
                pause_video_button,
                play_video_button;
            VIDEO_VIEW
                video_view;

            video_view = VideoListStripElement.Create<VIDEO_VIEW>( "video-view" );
            video_view.SetParentGameObject( gameObject );
            video_view.SetVideo( video_file_path, true );

            pause_video_button = video_view.Create<Button>( "pause-video-button" );
            pause_video_button.clicked += () => video_view.Pause();

            play_video_button = video_view.Create<Button>( "play-video-button" );
            play_video_button.clicked += () => video_view.Play();
        }

        // ~~

        public void CreateVideoListPanel(
            )
        {
            VideoListPanelElement = ScreenElement.Create<DRAG_VIEW>( "list-view-panel" );
            VideoListPanelElement.IsHorizontal = true;

            VideoListStripElement = VideoListPanelElement.Create<Element>( "list-view-strip" );

            CreateVideoView( Application.dataPath + "/Resources/Videos/Nature1.mp4" );
            CreateVideoView( Application.dataPath + "/Resources/Videos/Nature2.mp4" );
            CreateVideoView( Application.dataPath + "/Resources/Videos/Waterfall1.mp4" );
            CreateVideoView( Application.dataPath + "/Resources/Videos/Waterfall2.mp4" );
        }

        // ~~

        public override void BuildDocument(
            )
        {
            ScreenElement = Element.Create<Element>( "home-screen" );

            CreateVideoListPanel();
        }

        // ~~

        public override void ResizeDocument(
            )
        {
            base.ResizeDocument();

            Element.SetHeight( "video-view", 200 * Pixel );
            Element.SetWidth( "video-view", Width / 4 );
        }
    }
}

