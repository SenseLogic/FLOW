// -- IMPORTS

using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

// -- TYPES

public class VIDEO_VIEW : VisualElement, IDisposable
{
    // -- ATTRIBUTES

    public string
        FilePath;
    public bool
        IsPlayed,
        IsLooping;
    public float
        Width,
        Height,
        AspectRatio;
    public VideoPlayer
        Player_;
    public RenderTexture
        RenderTexture_;
    public IMGUIContainer
        Container;
    public bool
        IsDisposed;

    // -- CONSTRUCTORS

    public VIDEO_VIEW(
        )
    {
        Player_ = null;
        RenderTexture_ = null;
        Container = null;
        IsDisposed = false;

        style.overflow = Overflow.Hidden;
    }

    // -- DESTRUCTOR

    ~VIDEO_VIEW(
        )
    {
        ReleaseResources( false );
    }

    // -- OPERATIONS

    public void RenderVideo(
        )
    {
        float
            container_height,
            container_width,
            video_height,
            video_x_offset,
            video_y_offset,
            video_width;

        container_width = resolvedStyle.width;
        container_height = resolvedStyle.height;

        video_width = container_height * AspectRatio;
        video_height = container_height;
        video_x_offset = ( video_width - container_width ) * -0.5f;
        video_y_offset = -21.0f;

        Container.style.translate = new Translate( video_x_offset, video_y_offset, 0 );

        if ( RenderTexture_ != null )
        {
            GUI.DrawTexture( new Rect( 0, 0, video_width, video_height ), RenderTexture_ );
        }
    }

    // ~~

    public void SetVideo(
        string file_path,
        bool is_played = false,
        bool is_looping = true,
        int width = 1920,
        int height = 1080
        )
    {
        FilePath = file_path;
        IsPlayed = is_played;
        IsLooping = is_looping;
        Width = width;
        Height = height;
        AspectRatio = Width / Height;

        if ( Player_ == null )
        {
            Player_ = new GameObject( "VideoPlayer" ).AddComponent<VideoPlayer>();
            Player_.source = VideoSource.Url;
            Player_.url = FilePath;
            Player_.playOnAwake = IsPlayed;
            Player_.isLooping = IsLooping;

            RenderTexture_ = new RenderTexture( width, height, 24 );
            Player_.targetTexture = RenderTexture_;

            Container = new IMGUIContainer( RenderVideo );

            /*
            Container.style.position = Position.Absolute;
            Container.style.left = 0;
            Container.style.top = 0;
            Container.style.width = new Length( 100, LengthUnit.Percent );
            Container.style.height = new Length( 100, LengthUnit.Percent );
            Container.style.unityBackgroundImageTintColor = Color.clear;
            */

            Container.style.position = Position.Absolute;
            Container.style.left = 0;
            Container.style.right = 0;
            Container.style.top = 0;
            Container.style.bottom = 0;
            Container.style.transformOrigin = new TransformOrigin( 0, 0 );

            Add( Container );
        }
        else
        {
            Player_.source = VideoSource.Url;
        }
    }

    // ~~

    public void Play(
        )
    {
        if ( Player_ != null )
        {
            Player_.Play();
        }
    }

    // ~~

    public void Pause(
        )
    {
        if ( Player_ != null )
        {
            Player_.Pause();
        }
    }

    // ~~

    public void SetTime( double seconds )
    {
        if ( Player_ != null )
        {
            Player_.time = seconds;
        }
    }

    // ~~

    public void Dispose(
        )
    {
        ReleaseResources( true );
        GC.SuppressFinalize( this );
    }

    // ~~

    public void ReleaseResources(
        bool is_disposing
        )
    {
        if ( !IsDisposed )
        {
            if ( is_disposing )
            {
                if ( RenderTexture_ != null )
                {
                    RenderTexture_.Release();
                    RenderTexture_ = null;
                }
            }

            if ( Player_ != null )
            {
                GameObject.Destroy( Player_.gameObject );
                Player_ = null;
            }

            IsDisposed = true;
        }
    }
}
