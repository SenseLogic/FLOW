// -- IMPORTS

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Flow;

// -- TYPES

using Element = UnityEngine.UIElements.VisualElement;

// ~~

namespace GAME
{
    [ RequireComponent( typeof( UIDocument ) ) ]
    public class TEST_SCREEN : ResponsiveDocument
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

        public override void HandleDocumentSizeEvent(
            )
        {
            base.HandleDocumentSizeEvent();

            DocumentElement.EnableInClassList( "aspect-ratio-below-9-16", DocumentRatio <= 0.57f );
            DocumentElement.EnableInClassList( "aspect-ratio-below-2-3", DocumentRatio <= 0.67f );
            DocumentElement.EnableInClassList( "aspect-ratio-below-3-4", DocumentRatio <= 0.75f );
            DocumentElement.EnableInClassList( "aspect-ratio-below-1", DocumentRatio <= 1.0f );
            DocumentElement.EnableInClassList( "aspect-ratio-above-1", DocumentRatio >= 1.0f );
            DocumentElement.EnableInClassList( "aspect-ratio-above-4-3", DocumentRatio >= 1.33f );
            DocumentElement.EnableInClassList( "aspect-ratio-above-3-2", DocumentRatio <= 1.5f );
            DocumentElement.EnableInClassList( "aspect-ratio-above-16-9", DocumentRatio >= 1.77f );
        }

        // ~~

        public void CreateVideoView(
            string video_file_path
            )
        {
            Button
                pause_video_button_element,
                play_video_button_element;
            VideoView
                video_view_element;

            video_view_element = ListViewPanelElement.Create<VideoView>( "video-view" );
            video_view_element.SetVideo( video_file_path, true );

            play_video_button_element = video_view_element.Create<Button>( "play-video-button" );
            play_video_button_element.clicked += () => video_view_element.Play();

            pause_video_button_element = video_view_element.Create<Button>( "pause-video-button" );
            pause_video_button_element.clicked += () => video_view_element.Pause();
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

        public void CreateScreenPanel(
            )
        {
            ScreenPanelElement = DocumentElement.Create<Element>( "screen-panel" );

            CreateListViewPanel();
            CreateGridViewPanel();
        }

        // ~~

        new public void OnEnable(
            )
        {
            base.OnEnable();

            CreateScreenPanel();
        }
    }
}
