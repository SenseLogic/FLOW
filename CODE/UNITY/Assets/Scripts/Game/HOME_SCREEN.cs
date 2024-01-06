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
    public class HOME_SCREEN : SCREEN
    {
        // -- ATTRIBUTES

        public static HOME_SCREEN
            Instance;
        public Element
            HomeScreenElement;
        public DRAG_VIEW
            ListViewPanelElement;
        public Element
            ListViewStripElement,
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

            video_view_element = ListViewStripElement.Create<VIDEO_VIEW>( "video-view" );
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
            ListViewPanelElement = HomeScreenElement.Create<DRAG_VIEW>( "list-view-panel" );
            ListViewPanelElement.IsHorizontal = true;

            ListViewStripElement = ListViewPanelElement.Create<Element>( "list-view-strip" );

            CreateVideoView( Application.dataPath + "/Resources/Videos/Nature1.mp4" );
            CreateVideoView( Application.dataPath + "/Resources/Videos/Nature2.mp4" );
            CreateVideoView( Application.dataPath + "/Resources/Videos/Waterfall1.mp4" );
            CreateVideoView( Application.dataPath + "/Resources/Videos/Waterfall2.mp4" );
        }

        // ~~

        public void CreateGridViewPanel(
            )
        {
            GridViewPanelElement = HomeScreenElement.Create<Element>( "grid-view-panel" );
        }

        // ~~

        public override void BuildDocument(
            )
        {
            HomeScreenElement = Element.Create<Element>( "home-screen" );

            CreateListViewPanel();
            CreateGridViewPanel();
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

