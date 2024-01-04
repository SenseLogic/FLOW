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
    public class TEST_SCREEN : SCREEN
    {
        // -- ATTRIBUTES

        public static TEST_SCREEN
            Instance;
        public Element
            ScreenPanelElement,
            ListViewPanelElement,
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
                pause_video_button_element,
                play_video_button_element;
            VIDEO_VIEW
                video_view_element;

            video_view_element = ListViewPanelElement.Create<VIDEO_VIEW>( "video-view" );
            video_view_element.SetParentGameObject( gameObject );
            video_view_element.SetVideo( video_file_path, true );

            pause_video_button_element = video_view_element.Create<Button>( "pause-video-button" );
            pause_video_button_element.clicked += () => video_view_element.Pause();

            play_video_button_element = video_view_element.Create<Button>( "play-video-button" );
            play_video_button_element.clicked += () => video_view_element.Play();
        }

        // ~~

        public void CreateListViewPanel(
            )
        {
            ListViewPanelElement = ScreenPanelElement.Create<Element>( "list-view-panel" );

            CreateVideoView( Application.dataPath + "/Resources/Videos/Nature1.mp4" );
            CreateVideoView( Application.dataPath + "/Resources/Videos/Nature2.mp4" );
            CreateVideoView( Application.dataPath + "/Resources/Videos/Waterfall1.mp4" );
            CreateVideoView( Application.dataPath + "/Resources/Videos/Waterfall2.mp4" );
        }

        // ~~

        public void CreateGridViewPanel(
            )
        {
            GridViewPanelElement = ScreenPanelElement.Create<Element>( "grid-view-panel" );
        }

        // ~~

        public override void BuildDocument(
            )
        {
            ScreenPanelElement = DocumentElement.Create<Element>( "screen-panel" );

            CreateListViewPanel();
            CreateGridViewPanel();
        }

        // ~~

        public override void ResizeDocument(
            )
        {
            base.ResizeDocument();

            SetHeight( "video-view", 200 * DocumentPixel );
            SetWidth( "video-view", 200 * DocumentPixel );
            SetBottom( "play-video-button", 5 * DocumentPixel );
            SetLeft( "play-video-button", 5 * DocumentPixel );
            SetHeight( "play-video-button", 100 * DocumentPixel );
            SetWidth( "play-video-button", 100 * DocumentPixel );
            SetBottom( "pause-video-button", 5 * DocumentPixel );
            SetRight( "pause-video-button", 5 * DocumentPixel );
            SetHeight( "pause-video-button", 40 * DocumentPixel );
            SetWidth( "pause-video-button", 40 * DocumentPixel );
        }
    }
}

